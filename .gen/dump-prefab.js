// Dumps a Unity prefab/scene as a readable tree: GameObject names, components,
// Image colours / ppu / sprite, RectTransform anchors + sizeDelta.
const fs = require('fs');

const path = process.argv[2];
const text = fs.readFileSync(path, 'utf8').replace(/\r\n/g, '\n');
const docs = text.split('\n--- ');

const gos = new Map();     // fileID -> { name, active, components: [] }
const rects = new Map();   // fileID -> info
const comps = [];          // { cls, fid, goFid, raw }

for (const doc of docs) {
  const head = /^!u!(\d+) &(\d+)/.exec(doc.startsWith('--- ') ? doc.slice(4) : doc);
  if (!head) continue;
  const cls = head[1];
  const fid = head[2];
  const goRef = /m_GameObject: \{fileID: (\d+)\}/.exec(doc);
  if (cls === '1') {
    const nm = /m_Name: (.*)/.exec(doc);
    const act = /m_IsActive: (\d)/.exec(doc);
    const list = [...doc.matchAll(/- component: \{fileID: (\d+)\}/g)].map((m) => m[1]);
    gos.set(fid, { name: nm ? nm[1].trim() : '?', active: act ? act[1] : '?', components: list });
  } else {
    comps.push({ cls, fid, goFid: goRef ? goRef[1] : null, raw: doc });
  }
  if (cls === '224' || cls === '4') {
    const father = /m_Father: \{fileID: (\d+)\}/.exec(doc);
    const kids = [...doc.matchAll(/- \{fileID: (\d+)\}/g)].map((m) => m[1]);
    const sd = /m_SizeDelta: \{x: ([-\d.e]+), y: ([-\d.e]+)\}/.exec(doc);
    const amin = /m_AnchorMin: \{x: ([-\d.e]+), y: ([-\d.e]+)\}/.exec(doc);
    const amax = /m_AnchorMax: \{x: ([-\d.e]+), y: ([-\d.e]+)\}/.exec(doc);
    rects.set(fid, {
      goFid: goRef ? goRef[1] : null,
      father: father ? father[1] : '0',
      kids,
      sizeDelta: sd ? `${sd[1]}x${sd[2]}` : '-',
      anchors: amin && amax ? `${amin[1]},${amin[2]} .. ${amax[1]},${amax[2]}` : '-',
    });
  }
}

const compByFid = new Map(comps.map((c) => [c.fid, c]));

function describe(fid) {
  const c = compByFid.get(fid);
  if (!c) return null;
  if (c.cls === '114') {
    const script = /m_Script: \{fileID: \d+, guid: ([0-9a-f]+)/.exec(c.raw);
    const col = /m_Color: \{r: ([\d.e-]+), g: ([\d.e-]+), b: ([\d.e-]+), a: ([\d.e-]+)\}/.exec(c.raw);
    const ppu = /m_PixelsPerUnitMultiplier: ([\d.]+)/.exec(c.raw);
    const sp = /m_Sprite: \{fileID: (\d+), guid: ([0-9a-f]+)/.exec(c.raw);
    const spNone = /m_Sprite: \{fileID: 0\}/.test(c.raw);
    const eci = /m_EditorClassIdentifier: (.*)/.exec(c.raw);
    const bits = [`MB#${fid}`, `script=${script ? script[1].slice(0, 8) : '?'}`];
    if (eci && eci[1].trim()) bits.push(eci[1].trim());
    if (col) bits.push(`col=${col.slice(1, 5).map((v) => (+v).toFixed(3)).join(',')}`);
    if (ppu) bits.push(`ppu=${ppu[1]}`);
    if (sp) bits.push(`spr=${sp[2].slice(0, 8)}`);
    else if (spNone) bits.push('spr=NONE');
    return bits.join(' ');
  }
  return `u!${c.cls}#${fid}`;
}

function walk(rectFid, depth) {
  const r = rects.get(rectFid);
  if (!r) return;
  const go = gos.get(r.goFid) || { name: '?', active: '?', components: [] };
  const pad = '  '.repeat(depth);
  console.log(`${pad}${go.name}  [go=${r.goFid} rect=${rectFid} active=${go.active}] size=${r.sizeDelta} anch=${r.anchors}`);
  for (const cf of go.components) {
    if (cf === rectFid) continue;
    const d = describe(cf);
    if (d) console.log(`${pad}   . ${d}`);
  }
  for (const k of r.kids) walk(k, depth + 1);
}

const roots = [...rects.entries()].filter(([, r]) => r.father === '0').map(([f]) => f);
for (const root of roots) walk(root, 0);
