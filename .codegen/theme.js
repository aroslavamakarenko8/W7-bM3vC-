// Themes the shared chrome: BASE_PANEL (one edit that repaints every panel, pop
// and button), BASE_BUTTON's colour block, the splash LoadingSlider, and the TMP
// font material. Line-addressed edits are keyed to the layer NAME resolved from
// the YAML, never to a bare line number.
const fs = require('fs');

const P = (r, g, b, a) => '{r: ' + r + ', g: ' + g + ', b: ' + b + ', a: ' + a + '}';

// #171A22 graphite / #0E1017 deep / #1E2330 surface / #F5C442 amber
// #37B8CC cyan / #E94B3D alarm / #FFF1D6 cream / #0B0D13 ink
const BASE = [0.09019608, 0.10196079, 0.13333334];
const DEEP = [0.05490196, 0.0627451, 0.09019608];
const SURFACE = [0.11764706, 0.13725491, 0.1882353];
const AMBER = [0.9607843, 0.76862746, 0.25882354];
const CYAN = [0.21568628, 0.72156864, 0.8];
const ALARM = [0.9137255, 0.29411766, 0.23921569];
const CREAM = [1, 0.94509804, 0.8392157];
const INK = [0.043137256, 0.050980393, 0.07450981];

const col = (c, a) => P(c[0], c[1], c[2], a);

function docs(text) {
  const lines = text.split('\n');
  const re = /^--- !u!(\d+) &(\d+)/;
  const out = [];
  let cur = null;
  lines.forEach((l, i) => {
    const m = l.match(re);
    if (m) {
      cur = { cls: +m[1], id: m[2], lines: [] };
      out.push(cur);
    } else if (cur) {
      cur.lines.push(i);
    }
  });
  return { lines, out };
}

/** name of the GameObject a component document belongs to */
function nameMap(text) {
  const { lines, out } = docs(text);
  const names = new Map();
  for (const d of out) {
    if (d.cls !== 1) continue;
    const at = d.lines.find((i) => lines[i].indexOf('  m_Name: ') === 0);
    names.set(d.id, at === undefined ? '?' : lines[at].slice(10).trim());
  }
  return { lines, out, names };
}

/** Apply { layerName: { field: value } } to every matching component. */
function paint(path, plan) {
  let text = fs.readFileSync(path, 'utf8').replace(/\r\n/g, '\n');
  const { lines, out, names } = nameMap(text);
  let hits = 0;

  for (const d of out) {
    const goLine = d.lines.find((i) => lines[i].indexOf('  m_GameObject: {fileID: ') === 0);
    if (goLine === undefined) continue;
    const goId = lines[goLine].match(/(\d+)/)[1];
    const name = names.get(goId);
    const rules = plan[name];
    if (!rules) continue;

    for (const [field, value] of Object.entries(rules)) {
      const key = '  ' + field + ': ';
      const at = d.lines.find((i) => lines[i].indexOf(key) === 0);
      if (at === undefined) continue;
      lines[at] = key + value;
      hits++;
    }
  }

  fs.writeFileSync(path, lines.join('\n').replace(/\n/g, '\r\n'));
  return hits;
}

// ── BASE_PANEL: the NEON archetype ───────────────────────────────────────────
// The card the player actually sees is Border/FillColor sitting over
// FillRoundess; ShadowFill is full size behind both, so painting it amber turns
// it into a frame ring once Border/FillColor's rect is pulled in to the inset.
// Fade is the Button's own target graphic and is never recoloured - the Button
// overwrites it at runtime.
const PANEL = 'Assets/Prefabs/_SMPL/_BASE/_FUNDAMENTAL/BASE_PANEL/BASE_PANEL.prefab';
const panelPlan = {
  'FillGradient (0)': { m_Color: col(CYAN, 0.16), m_PixelsPerUnitMultiplier: '4.6' },
  BackgroundColor: { m_Color: col(BASE, 0.95) },
  BackgroundRoundness: { m_Color: col(AMBER, 1), m_PixelsPerUnitMultiplier: '4.6' },
  Border: { m_Color: col(AMBER, 0.92), m_PixelsPerUnitMultiplier: '5.2' },
  FillRoundess: { m_Color: col(DEEP, 0.9), m_PixelsPerUnitMultiplier: '5.2' },
  BackgroundGradient: { m_Color: col(DEEP, 0.6) },
  FillGradient: { m_Color: col(CYAN, 0.22), m_PixelsPerUnitMultiplier: '4.6' },
  ShadowFill: { m_Color: col(AMBER, 0.95) },
  ShadowFade: { m_Color: col(AMBER, 0.3), m_PixelsPerUnitMultiplier: '4.6' },
  ImageFill: { m_Color: col(CREAM, 0.1), m_PixelsPerUnitMultiplier: '2.2' },
  Icon: { m_Color: col(CREAM, 1) },
  'FillGradient (1)': { m_Color: col(ALARM, 0.12), m_PixelsPerUnitMultiplier: '4.6' },
  Fade: { m_PixelsPerUnitMultiplier: '4.6' },
};
console.log('BASE_PANEL fields painted:', paint(PANEL, panelPlan));

// FillColor appears twice: the inner one over FillRoundess, and the outer card
// over Border. Both get the palette, and the card's rect is pulled to {0,0} so
// the amber ShadowFill shows around it as a ring.
{
  let text = fs.readFileSync(PANEL, 'utf8').replace(/\r\n/g, '\n');
  let lines = text.split('\n');
  // the inner FillColor's Image colour (white a0.239) and the card's (white a0.647)
  const swaps = [
    ['  m_Color: {r: 1, g: 1, b: 1, a: 0.23921569}', '  m_Color: ' + col(SURFACE, 1)],
    ['  m_Color: {r: 1, g: 1, b: 1, a: 0.64705884}', '  m_Color: ' + col(BASE, 1)],
    ['  m_SizeDelta: {x: 20, y: 20}', '  m_SizeDelta: {x: 0, y: 0}'],
  ];
  let done = 0;
  for (const [from, to] of swaps) {
    const at = lines.indexOf(from);
    if (at >= 0) {
      lines[at] = to;
      done++;
    }
  }
  fs.writeFileSync(PANEL, lines.join('\n').replace(/\n/g, '\r\n'));
  console.log('BASE_PANEL card layers:', done, 'of', swaps.length);
}

// ── BASE_BUTTON: press and disabled states in the palette ────────────────────
{
  const BTN = 'Assets/Prefabs/_SMPL/_BASE/BASE_BUTTON/BASE_BUTTON.prefab';
  let text = fs.readFileSync(BTN, 'utf8').replace(/\r\n/g, '\n');
  const swaps = [
    ['    m_PressedColor: {r: 1, g: 1, b: 1, a: 0.2509804}', '    m_PressedColor: ' + col(AMBER, 0.32)],
    ['    m_SelectedColor: {r: 1, g: 1, b: 1, a: 0.2509804}', '    m_SelectedColor: ' + col(CYAN, 0.28)],
    ['    m_DisabledColor: {r: 0.5169811, g: 0.5169811, b: 0.5169811, a: 0.5019608}',
      '    m_DisabledColor: ' + col(SURFACE, 0.6)],
    ['    m_FadeDuration: 0.1', '    m_FadeDuration: 0.06'],
  ];
  let lines = text.split('\n');
  let done = 0;
  for (const [from, to] of swaps) {
    const at = lines.indexOf(from);
    if (at >= 0) {
      lines[at] = to;
      done++;
    }
  }
  fs.writeFileSync(BTN, lines.join('\n').replace(/\n/g, '\r\n'));
  console.log('BASE_BUTTON states:', done, 'of', swaps.length);
}

// ── LoadingSlider: the splash bar has to be visible ──────────────────────────
// It ships with a white fill and a track at alpha 0.004, i.e. nothing at all.
{
  const SL = 'Assets/Prefabs/_SMPL/UserInterface/Sliders/LoadingSlider.prefab';
  let text = fs.readFileSync(SL, 'utf8').replace(/\r\n/g, '\n');
  let lines = text.split('\n');
  const swaps = [
    ['  m_Color: {r: 1, g: 1, b: 1, a: 1}', '  m_Color: ' + col(AMBER, 1)],
    ['  m_Color: {r: 1, g: 1, b: 1, a: 0.003921569}', '  m_Color: ' + col(DEEP, 0.92)],
  ];
  let done = 0;
  for (const [from, to] of swaps) {
    const at = lines.indexOf(from);
    if (at >= 0) {
      lines[at] = to;
      done++;
    }
  }
  fs.writeFileSync(SL, lines.join('\n').replace(/\n/g, '\r\n'));
  console.log('LoadingSlider layers:', done, 'of', swaps.length);
}

// ── font material ────────────────────────────────────────────────────────────
// Only the material block is touched. The atlas, the glyph table and the sizing
// floats belong to the art stage and are left exactly as they are.
{
  const F = 'Assets/TextMesh Pro/Resources/Font Materials/font SDF.asset';
  let text = fs.readFileSync(F, 'utf8').replace(/\r\n/g, '\n');
  let lines = text.split('\n');

  // Without OUTLINE_ON in the keyword list TMP draws no outline at all, whatever
  // the width says.
  const kw = lines.findIndex((l) => l.trim() === 'm_ValidKeywords:');
  if (kw >= 0 && text.indexOf('- OUTLINE_ON') < 0) lines.splice(kw + 1, 0, '  - OUTLINE_ON');

  const floats = {
    _FaceDilate: '0.44',
    _OutlineWidth: '0.46',
    _UnderlaySoftness: '0.16',
    _UnderlayOffsetX: '0.5',
    _UnderlayOffsetY: '-0.5',
  };
  const colours = {
    _FaceColor: col(CREAM, 1),
    _OutlineColor: col(INK, 1),
    _UnderlayColor: col(INK, 0.55),
    _GlowColor: col(AMBER, 1),
  };

  let done = 0;
  for (let i = 0; i < lines.length; i++) {
    const t = lines[i].trim();
    for (const [k, v] of Object.entries(floats)) {
      if (t.indexOf('- ' + k + ': ') === 0) {
        lines[i] = lines[i].slice(0, lines[i].indexOf('- ')) + '- ' + k + ': ' + v;
        done++;
      }
    }
    for (const [k, v] of Object.entries(colours)) {
      if (t.indexOf('- ' + k + ': ') === 0) {
        lines[i] = lines[i].slice(0, lines[i].indexOf('- ')) + '- ' + k + ': ' + v;
        done++;
      }
    }
  }
  fs.writeFileSync(F, lines.join('\n').replace(/\n/g, '\r\n'));
  console.log('font SDF material fields:', done);
}
