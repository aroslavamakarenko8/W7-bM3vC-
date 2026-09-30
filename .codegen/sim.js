// Faithful port of RouteGenerator + the spawner's grace rule + the director's
// clock, used to prove the rule C.5 / C.11 claims before anything ships.
function mkRng(seed) {
  let s = (seed >>> 0) || 1;
  return {
    next(n) { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s % n; },
    dbl() { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; },
  };
}

const LANES = 3, KINDS = 4;
const W_SOLO = 35, W_PAIR = 30, W_GUARD = 25;
const SLIDE = 0.16, SLACK = 12, SPAWN_MARGIN = 0.6, CART_DEPTH = 0.61;
const STREAK_EVERY = 5, STREAK_BONUS = 2.5, STRIKES = 3;

const ROUTES = [
  { cap: 'GREEN LINE', crates: 26, speed: 3.2, interval: 1.35, clock: 100, grace: 0.30, hFrom: 5, hMax: 1 },
  { cap: 'AMBER LINE', crates: 32, speed: 3.8, interval: 1.15, clock: 105, grace: 0.22, hFrom: 3, hMax: 2 },
  { cap: 'RED LINE', crates: 38, speed: 4.4, interval: 1.00, clock: 110, grace: 0.15, hFrom: 1, hMax: 2 },
];

function chain(len, rng) {
  const c = [];
  for (let i = 0; i < len; i++) {
    let pick = rng.next(KINDS);
    if (i >= 2 && c[i - 1] === pick && c[i - 2] === pick) pick = (pick + 1 + rng.next(KINDS - 1)) % KINDS;
    c.push(pick);
  }
  return c;
}

function row(index, cfg, rng) {
  const r = { wanted: -1, decoy: -1, offset: 1, haz: [], hv: 0, marker: 0 };
  r.marker = rng.next(5) === 0 ? (rng.next(2) === 0 ? -1 : 1) : 0;
  r.hv = rng.next(2);
  const roll = rng.next(100);
  const hz = index >= cfg.hFrom;

  if (roll < W_SOLO) {
    const lane = rng.next(LANES);
    if (rng.next(100) < 70) r.wanted = lane;
    else { r.decoy = lane; r.offset = 1 + rng.next(KINDS - 1); }
    return r;
  }
  if (roll < W_SOLO + W_PAIR) {
    const w = rng.next(LANES);
    r.wanted = w;
    r.decoy = (w + 1 + rng.next(LANES - 1)) % LANES;
    r.offset = 1 + rng.next(KINDS - 1);
    return r;
  }
  if (roll < W_SOLO + W_PAIR + W_GUARD) {
    const lane = rng.next(LANES);
    if (rng.next(100) < 60) r.wanted = lane;
    else { r.decoy = lane; r.offset = 1 + rng.next(KINDS - 1); }
    if (hz) r.haz = [(lane + 1 + rng.next(LANES - 1)) % LANES];
    return r;
  }
  if (hz) {
    const f = rng.next(LANES);
    if (cfg.hMax >= 2 && rng.next(100) < 35) r.haz = [f, (f + 1 + rng.next(LANES - 1)) % LANES];
    else r.haz = [f];
  }
  return r;
}

function draw(cfg, rng) {
  const seq = chain(cfg.crates, rng);
  const n = Math.ceil(cfg.clock / cfg.interval) + 6;
  const rows = [];
  for (let i = 0; i < n; i++) rows.push(row(i, cfg, rng));
  return { seq, rows };
}

const blocks = (r, lane) => r.haz.indexOf(lane) >= 0;
function safeLane(r, cur) {
  if (!blocks(r, cur) && r.decoy !== cur) return cur;
  for (let i = 0; i < LANES; i++) if (!blocks(r, i) && r.decoy !== i) return i;
  for (let i = 0; i < LANES; i++) if (!blocks(r, i)) return i;
  return cur;
}

function isClearable(plan, cfg, fall) {
  const budget = cfg.clock - SLACK;
  let lane = 1, delivered = 0;
  for (let i = 0; i < plan.rows.length; i++) {
    const r = plan.rows[i];
    const arrival = i * cfg.interval + fall;
    const target = r.wanted >= 0 ? r.wanted : safeLane(r, lane);
    if (Math.abs(target - lane) * SLIDE > fall) continue;
    lane = target;
    if (r.wanted === lane && !blocks(r, lane)) delivered++;
    if (delivered >= plan.seq.length) { plan.rows_used = i + 1; plan.secs = arrival; return arrival <= budget; }
  }
  return false;
}

function build(routeIndex, attempt, fall) {
  const cfg = ROUTES[routeIndex];
  const seed = (routeIndex * 7919) ^ (attempt * 104729);
  const rng = mkRng(seed);
  for (let i = 0; i < 20; i++) {
    const cand = draw(cfg, rng);
    if (isClearable(cand, cfg, fall)) return { plan: cand, seed, tries: i + 1, fallback: false };
  }
  return { plan: draw(cfg, rng), seed, tries: 20, fallback: true };
}

// The live run: the spawner applies grace against the cart's CURRENT lane, then
// the row meets the cart and the director scores it.
function run(routeIndex, attempt, mode) {
  const cfg = ROUTES[routeIndex];
  const halfH = 5, spawnY = halfH + SPAWN_MARGIN, cartY = -halfH * CART_DEPTH;
  const fall = (spawnY - cartY) / cfg.speed;
  const built = build(routeIndex, attempt, fall);
  const plan = built.plan;
  const grng = mkRng((built.seed ^ 0x5f3a) >>> 0);

  let delivered = 0, wrong = 0, crash = 0, strikes = 0, streak = 0;
  let cartLane = 1;          // lane at the moment a row is DROPPED
  let budget = cfg.clock;    // line clock, topped up by streaks

  // Rows are dropped one interval apart and met `fall` seconds later. The driver
  // reacts at drop time (it can see the row coming), so drop-lane == meet-lane.
  const inflight = [];
  for (let i = 0; i < plan.rows.length; i++) {
    const p = plan.rows[i];
    // cartLane is where the driver is STANDING when this row is dropped: it is the
    // lane it moved to for the previous row, because the previous row has not met
    // the cart yet. The grace rule is applied against that lane, and only then does
    // the driver react and slide to wherever the crate actually landed.
    let wanted = p.wanted, decoy = p.decoy;
    let haz = p.haz.filter((h) => h !== cartLane);
    if (decoy === cartLane) decoy = -1;

    if (wanted >= 0) {
      const gift = grng.dbl() < cfg.grace;
      if (gift) { wanted = cartLane; haz = haz.filter((h) => h !== cartLane); }
      else if (wanted === cartLane) {
        for (let off = 1; off <= 2; off++) {
          const cand = (cartLane + off) % LANES;
          if (cand !== decoy) { wanted = cand; break; }
        }
        haz = haz.filter((h) => h !== wanted);
      }
    }

    let meetLane = cartLane;
    if (mode === 'greedy') meetLane = wanted >= 0 ? wanted : safeLane({ haz, decoy }, cartLane);
    inflight.push({ wanted, decoy, haz, lane: meetLane, at: i * cfg.interval + fall });
    cartLane = meetLane;
  }

  for (const r of inflight) {
    if (r.at > budget) break;
    const lane = r.lane;
    if (r.haz.indexOf(lane) >= 0) { crash++; strikes++; streak = 0; }
    else if (r.wanted === lane) {
      delivered++; streak++;
      if (streak % STREAK_EVERY === 0) budget = Math.min(cfg.clock + 0, budget + STREAK_BONUS);
    } else if (r.decoy === lane) { wrong++; strikes++; streak = 0; }

    if (strikes >= STRIKES) return { end: 'strikes', t: r.at, delivered, wrong, crash, tries: built.tries, fallback: built.fallback };
    if (delivered >= plan.seq.length) return { end: 'win', t: r.at, delivered, wrong, crash, tries: built.tries, fallback: built.fallback };
  }
  return { end: 'timeout', t: budget, delivered, wrong, crash, tries: built.tries, fallback: built.fallback };
}

for (let r = 0; r < ROUTES.length; r++) {
  let fb = 0, tries = 0;
  let pWin = 0, pStrike = 0, pTime = 0, pMinT = 1e9, pDeliv = 0;
  let gWin = 0, gMaxT = 0, gMinT = 1e9;
  const N = 200;
  for (let a = 1; a <= N; a++) {
    const p = run(r, a, 'passive');
    if (p.fallback) fb++;
    tries += p.tries;
    if (p.end === 'win') pWin++;
    else if (p.end === 'strikes') { pStrike++; pMinT = Math.min(pMinT, p.t); }
    else pTime++;
    pDeliv += p.delivered;

    const g = run(r, a, 'greedy');
    if (g.end === 'win') { gWin++; gMaxT = Math.max(gMaxT, g.t); gMinT = Math.min(gMinT, g.t); }
  }
  console.log(`route ${r} (${ROUTES[r].cap}, ${ROUTES[r].crates} crates, clock ${ROUTES[r].clock}s)`);
  console.log(`  generator: fallbacks ${fb}/${N}, avg draws ${(tries / N).toFixed(2)}`);
  console.log(`  passive  : win ${pWin}  strike-out ${pStrike}  ran the clock ${pTime}  avg delivered ${(pDeliv / N).toFixed(1)}`);
  console.log(`  greedy   : win ${gWin}/${N}  in ${gMinT.toFixed(1)}-${gMaxT.toFixed(1)}s`);
}
