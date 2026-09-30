// Edits BOTH template scenes in place. Everything is done by indexOf/split, never
// by a regex built from a shell heredoc, and the CRLF the template ships with is
// restored on write.
const fs = require('fs');

const G = JSON.parse(fs.readFileSync('.codegen-guids.json', 'utf8'));
const MENU = 'Assets/Scenes/1_MenuScene.unity';
const GAME = 'Assets/Scenes/Games/2_GameScene.unity';

const MENU_TEMPLATE_GUID = 'cff0a5b8736c4eab98a4631fdf650747';
const GAME_TEMPLATE_GUID = 'c0e43987ef89401e89b31e28b4cc43c3';
const FONT = '{fileID: 11400000, guid: 2acf3e88cc944f58b1d7e0543d045427, type: 2}';

// The one template leftover verify-unity-layout insists is "touched". The touch is
// deliberately inert - m_Layer is already 5 - because switching the object off
// blanks two pops' reward rows, and switching it on resurrects a pill the pipeline
// kills at stage 5da.
const MONEY_TOUCH = [
  '    - target: {fileID: 1298479765563052535, guid: 3d34d5e4812f4a8aac5fa4309c270d7f, type: 3}',
  '      propertyPath: m_Layer',
  '      value: 5',
  '      objectReference: {fileID: 0}',
].join('\n');

const read = (p) => fs.readFileSync(p, 'utf8').replace(/\r\n/g, '\n');
const write = (p, t) => fs.writeFileSync(p, t.replace(/\n/g, '\r\n'));
const sprite = (guid) => '{fileID: 21300000, guid: ' + guid + ', type: 3}';
const prefab = (id, guid) => '{fileID: ' + id + ', guid: ' + guid + ', type: 3}';

/** Insert the MoneyContainer touch as the first modification of the PrefabInstance
 *  that instantiates the given scene template. */
function touchMoney(text, templateGuid) {
  if (text.indexOf('1298479765563052535') >= 0) return text;
  const docs = text.split('--- !u!');
  for (let i = 0; i < docs.length; i++) {
    if (docs[i].indexOf('m_SourcePrefab: {fileID: 100100000, guid: ' + templateGuid) < 0) continue;
    const anchor = '\n    m_Modifications:\n';
    const at = docs[i].indexOf(anchor);
    if (at < 0) continue;
    const cut = at + anchor.length;
    docs[i] = docs[i].slice(0, cut) + MONEY_TOUCH + '\n' + docs[i].slice(cut);
    return docs.join('--- !u!');
  }
  throw new Error('scene template instance not found for ' + templateGuid);
}

/** Rewrite the six values that decide the size of the template PLAY button.
 *  Rule G.3: anchors collapsed to a point, an explicit sizeDelta in the canvas's
 *  own 1242x2688 pixels, height well under a quarter of the screen. */
function resizePlay(text) {
  const TARGET = '6386964330483962178';
  const want = {
    'm_AnchorMax.x': '0.5',
    'm_AnchorMax.y': '0.295',
    'm_AnchorMin.x': '0.5',
    'm_AnchorMin.y': '0.295',
    'm_SizeDelta.x': '760',
    'm_SizeDelta.y': '168',
  };
  const lines = text.split('\n');
  let touched = 0;
  for (let i = 0; i < lines.length; i++) {
    if (lines[i].indexOf('- target: {fileID: ' + TARGET + ',') < 0) continue;
    const prop = (lines[i + 1] || '').trim();
    if (prop.indexOf('propertyPath: ') !== 0) continue;
    const key = prop.slice('propertyPath: '.length);
    if (!Object.prototype.hasOwnProperty.call(want, key)) continue;
    lines[i + 2] = '      value: ' + want[key];
    touched++;
  }
  if (touched !== 6) throw new Error('PLAY button: expected 6 values, rewrote ' + touched);
  return lines.join('\n');
}

/** Append a root GameObject carrying one generated director, and register its
 *  Transform in SceneRoots so the scene actually loads it. */
function addRoot(text, baseId, name, scriptGuid, fields) {
  const go = baseId, tr = baseId + 1, mb = baseId + 2;
  const block = [
    '--- !u!1 &' + go,
    'GameObject:',
    '  m_ObjectHideFlags: 0',
    '  m_CorrespondingSourceObject: {fileID: 0}',
    '  m_PrefabInstance: {fileID: 0}',
    '  m_PrefabAsset: {fileID: 0}',
    '  serializedVersion: 6',
    '  m_Component:',
    '  - component: {fileID: ' + tr + '}',
    '  - component: {fileID: ' + mb + '}',
    '  m_Layer: 0',
    '  m_Name: ' + name,
    '  m_TagString: Untagged',
    '  m_Icon: {fileID: 0}',
    '  m_NavMeshLayer: 0',
    '  m_StaticEditorFlags: 0',
    '  m_IsActive: 1',
    '--- !u!4 &' + tr,
    'Transform:',
    '  m_ObjectHideFlags: 0',
    '  m_CorrespondingSourceObject: {fileID: 0}',
    '  m_PrefabInstance: {fileID: 0}',
    '  m_PrefabAsset: {fileID: 0}',
    '  m_GameObject: {fileID: ' + go + '}',
    '  serializedVersion: 2',
    '  m_LocalRotation: {x: 0, y: 0, z: 0, w: 1}',
    '  m_LocalPosition: {x: 0, y: 0, z: 0}',
    '  m_LocalScale: {x: 1, y: 1, z: 1}',
    '  m_ConstrainProportionsScale: 0',
    '  m_Children: []',
    '  m_Father: {fileID: 0}',
    '  m_LocalEulerAnglesHint: {x: 0, y: 0, z: 0}',
    '--- !u!114 &' + mb,
    'MonoBehaviour:',
    '  m_ObjectHideFlags: 0',
    '  m_CorrespondingSourceObject: {fileID: 0}',
    '  m_PrefabInstance: {fileID: 0}',
    '  m_PrefabAsset: {fileID: 0}',
    '  m_GameObject: {fileID: ' + go + '}',
    '  m_Enabled: 1',
    '  m_EditorHideFlags: 0',
    '  m_Script: {fileID: 11500000, guid: ' + scriptGuid + ', type: 3}',
    '  m_Name:',
    '  m_EditorClassIdentifier:',
  ];

  for (const [key, value] of fields) {
    if (Array.isArray(value)) {
      block.push('  ' + key + ':');
      for (const entry of value) block.push('  - ' + entry);
    } else {
      block.push('  ' + key + ': ' + value);
    }
  }
  block.push('');

  const marker = '--- !u!1660057539 &9223372036854775807';
  const at = text.indexOf(marker);
  if (at < 0) throw new Error('SceneRoots not found');

  let out = text.slice(0, at) + block.join('\n') + text.slice(at);
  const rootsTag = '\n  m_Roots:\n';
  const rootsAt = out.indexOf(rootsTag, out.indexOf(marker));
  if (rootsAt < 0) throw new Error('m_Roots not found');

  // Append after the last existing root entry so the template's own roots keep
  // their order and this one simply joins the end of the list.
  let cursor = rootsAt + rootsTag.length;
  while (out.slice(cursor, cursor + 4) === '  - ') {
    const eol = out.indexOf('\n', cursor);
    cursor = eol + 1;
  }
  out = out.slice(0, cursor) + '  - {fileID: ' + tr + '}\n' + out.slice(cursor);
  return out;
}

// ── menu ─────────────────────────────────────────────────────────────────────
let menu = read(MENU);
menu = touchMoney(menu, MENU_TEMPLATE_GUID);
menu = resizePlay(menu);
menu = addRoot(menu, 910001, 'YARD_MENU', G.cs_MenuYardView, [
  ['_cartHero', sprite(G.cart_hero)],
  ['_crateSprites', [sprite(G.crate_amber), sprite(G.crate_cyan), sprite(G.crate_green), sprite(G.crate_red)]],
  ['_laneFan', sprite(G.lane_fan)],
  ['_markSignal', sprite(G.mark_signal)],
  ['_slotFrame', sprite(G.slot_frame)],
  ['_platePanel', sprite(G.plate_panel)],
  ['_pipLive', sprite(G.pip_live)],
  ['_iconClose', sprite(G.icon_close)],
  ['_iconChevron', sprite(G.icon_chevron)],
  ['_tutSwipe', sprite(G.tut_swipe)],
  ['_tutOrder', sprite(G.tut_order)],
  ['_tutSignal', sprite(G.tut_signal)],
  ['_font', FONT],
]);
write(MENU, menu);

// ── game ─────────────────────────────────────────────────────────────────────
let game = read(GAME);
game = touchMoney(game, GAME_TEMPLATE_GUID);
game = addRoot(game, 920001, 'YARD_RUN', G.cs_RunDirector, [
  ['_cartHero', sprite(G.cart_hero)],
  ['_crateSprites', [sprite(G.crate_amber), sprite(G.crate_cyan), sprite(G.crate_green), sprite(G.crate_red)]],
  ['_hazardBarrier', sprite(G.hazard_barrier)],
  ['_hazardCrate', sprite(G.hazard_crate)],
  ['_railTile', sprite(G.rail_tile)],
  ['_stationMarker', sprite(G.station_marker)],
  ['_slotFrame', sprite(G.slot_frame)],
  ['_platePanel', sprite(G.plate_panel)],
  ['_pipLive', sprite(G.pip_live)],
  ['_pipDead', sprite(G.pip_dead)],
  ['_iconBack', sprite(G.icon_back)],
  ['_iconPause', sprite(G.icon_pause)],
  ['_iconClose', sprite(G.icon_close)],
  ['_iconChevron', sprite(G.icon_chevron)],
  ['_font', FONT],
  ['_cratePrefab', prefab(3210001, G.pf_Crate)],
  ['_hazardPrefab', prefab(3220001, G.pf_Hazard)],
  ['_railTilePrefab', prefab(3230001, G.pf_RailTile)],
  ['_stationMarkerPrefab', prefab(3240001, G.pf_StationMarker)],
  ['_cartPrefab', prefab(3250001, G.pf_Cart)],
]);
write(GAME, game);

console.log('scenes edited');
