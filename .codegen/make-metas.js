// Writes the .meta files for every sprite this game references, plus the
// generated prefabs and their .meta. The PNG bytes arrive later from the art
// stage; the guid written here is the guid that ships.
const fs = require('fs');
const path = require('path');

const G = JSON.parse(fs.readFileSync('.codegen-guids.json', 'utf8'));

const SPRITE_DIR = 'Assets/Art/Sprites';
const PREFAB_DIR = 'Assets/Prefabs/Generated';
fs.mkdirSync(SPRITE_DIR, { recursive: true });
fs.mkdirSync(PREFAB_DIR, { recursive: true });

function spriteMeta(guid, border) {
  return `fileFormatVersion: 2
guid: ${guid}
TextureImporter:
  internalIDToNameTable: []
  externalObjects: {}
  serializedVersion: 13
  mipmaps:
    mipMapMode: 0
    enableMipMap: 0
    sRGBTexture: 1
    linearTexture: 0
    fadeOut: 0
    borderMipMap: 0
    mipMapsPreserveCoverage: 0
    alphaTestReferenceValue: 0.5
    mipMapFadeDistanceStart: 1
    mipMapFadeDistanceEnd: 3
  bumpmap:
    convertToNormalMap: 0
    externalNormalMap: 0
    heightScale: 0.25
    normalMapFilter: 0
    flipGreenChannel: 0
  isReadable: 0
  streamingMipmaps: 0
  streamingMipmapsPriority: 0
  vTOnly: 0
  ignoreMipmapLimit: 0
  grayScaleToAlpha: 0
  generateCubemap: 6
  cubemapConvolution: 0
  seamlessCubemap: 0
  textureFormat: 1
  maxTextureSize: 2048
  textureSettings:
    serializedVersion: 2
    filterMode: 1
    aniso: 1
    mipBias: 0
    wrapU: 1
    wrapV: 1
    wrapW: 1
  nPOTScale: 0
  lightmap: 0
  compressionQuality: 50
  spriteMode: 1
  spriteExtrude: 1
  spriteMeshType: 0
  alignment: 0
  spritePivot: {x: 0.5, y: 0.5}
  spritePixelsToUnits: 100
  spriteBorder: {x: ${border}, y: ${border}, z: ${border}, w: ${border}}
  spriteGenerateFallbackPhysicsShape: 0
  alphaUsage: 1
  alphaIsTransparency: 1
  spriteTessellationDetail: -1
  textureType: 8
  textureShape: 1
  singleChannelComponent: 0
  flipbookRows: 1
  flipbookColumns: 1
  maxTextureSizeSet: 0
  compressionQualitySet: 0
  textureFormatSet: 0
  ignorePngGamma: 0
  applyGammaDecoding: 0
  swizzle: 50462976
  cookieLightType: 0
  platformSettings:
  - serializedVersion: 3
    buildTarget: DefaultTexturePlatform
    maxTextureSize: 2048
    resizeAlgorithm: 0
    textureFormat: -1
    textureCompression: 1
    compressionQuality: 50
    crunchedCompression: 0
    allowsAlphaSplitting: 0
    overridden: 0
    ignorePlatformSupport: 0
    androidETC2FallbackOverride: 0
    forceMaximumCompressionQuality_BC6H_BC7: 0
  spriteSheet:
    serializedVersion: 2
    sprites: []
    outline: []
    customData:
    physicsShape: []
    bones: []
    spriteID: 5e97eb03825dee720800000000000000
    internalID: 0
    vertices: []
    indices:
    edges: []
    weights: []
    secondaryTextures: []
    spriteCustomMetadata:
      entries: []
    nameFileIdTable: {}
  mipmapLimitGroupName:
  pSDRemoveMatte: 0
  userData:
  assetBundleName:
  assetBundleVariant:
`;
}

// name -> [guidKey, nine-slice border in source pixels]
const SPRITES = [
  ['sprite_cart_hero', 'cart_hero', 0],
  ['sprite_crate_amber', 'crate_amber', 0],
  ['sprite_crate_cyan', 'crate_cyan', 0],
  ['sprite_crate_green', 'crate_green', 0],
  ['sprite_crate_red', 'crate_red', 0],
  ['sprite_hazard_barrier', 'hazard_barrier', 0],
  ['sprite_hazard_crate', 'hazard_crate', 0],
  ['sprite_rail_tile', 'rail_tile', 0],
  ['sprite_station_marker', 'station_marker', 0],
  ['sprite_lane_fan', 'lane_fan', 0],
  ['sprite_mark_signal', 'mark_signal', 0],
  ['sprite_tut_swipe', 'tut_swipe', 0],
  ['sprite_tut_order', 'tut_order', 0],
  ['sprite_tut_signal', 'tut_signal', 0],
  ['icon_back', 'icon_back', 0],
  ['icon_pause', 'icon_pause', 0],
  ['icon_close', 'icon_close', 0],
  ['icon_chevron', 'icon_chevron', 0],
  ['sprite_slot_frame', 'slot_frame', 24],
  ['sprite_pip_live', 'pip_live', 0],
  ['sprite_pip_dead', 'pip_dead', 0],
  ['sprite_plate_panel', 'plate_panel', 40],
];

for (const [name, key, border] of SPRITES) {
  fs.writeFileSync(path.join(SPRITE_DIR, name + '.png.meta'), spriteMeta(G[key], border));
}

// ── generated prefabs ────────────────────────────────────────────────────────
function prefabYaml(baseId, name, spriteGuid, order, sizeX, sizeY, colour) {
  const go = baseId;
  const tr = baseId + 1;
  const sr = baseId + 2;
  return `%YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!1 &${go}
GameObject:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  serializedVersion: 6
  m_Component:
  - component: {fileID: ${tr}}
  - component: {fileID: ${sr}}
  m_Layer: 0
  m_Name: ${name}
  m_TagString: Untagged
  m_Icon: {fileID: 0}
  m_NavMeshLayer: 0
  m_StaticEditorFlags: 0
  m_IsActive: 1
--- !u!4 &${tr}
Transform:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: ${go}}
  serializedVersion: 2
  m_LocalRotation: {x: 0, y: 0, z: 0, w: 1}
  m_LocalPosition: {x: 0, y: 0, z: 0}
  m_LocalScale: {x: 1, y: 1, z: 1}
  m_ConstrainProportionsScale: 0
  m_Children: []
  m_Father: {fileID: 0}
  m_LocalEulerAnglesHint: {x: 0, y: 0, z: 0}
--- !u!212 &${sr}
SpriteRenderer:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: ${go}}
  m_Enabled: 1
  m_CastShadows: 0
  m_ReceiveShadows: 0
  m_DynamicOccludee: 1
  m_StaticShadowCaster: 0
  m_MotionVectors: 1
  m_LightProbeUsage: 0
  m_ReflectionProbeUsage: 0
  m_RayTracingMode: 0
  m_RayTraceProcedural: 0
  m_RayTracingAccelStructBuildFlagsOverride: 0
  m_RayTracingAccelStructBuildFlags: 1
  m_SmallMeshCulling: 1
  m_ForceMeshLod: -1
  m_MeshLodSelectionBias: 0
  m_RenderingLayerMask: 1
  m_RendererPriority: 0
  m_Materials:
  - {fileID: 10754, guid: 0000000000000000f000000000000000, type: 0}
  m_StaticBatchInfo:
    firstSubMesh: 0
    subMeshCount: 0
  m_StaticBatchRoot: {fileID: 0}
  m_ProbeAnchor: {fileID: 0}
  m_LightProbeVolumeOverride: {fileID: 0}
  m_ScaleInLightmap: 1
  m_ReceiveGI: 1
  m_PreserveUVs: 0
  m_IgnoreNormalsForChartDetection: 0
  m_ImportantGI: 0
  m_StitchLightmapSeams: 1
  m_SelectedEditorRenderState: 0
  m_MinimumChartSize: 4
  m_AutoUVMaxDistance: 0.5
  m_AutoUVMaxAngle: 89
  m_LightmapParameters: {fileID: 0}
  m_SortingLayerID: 0
  m_SortingLayer: 0
  m_SortingOrder: ${order}
  m_Sprite: {fileID: 21300000, guid: ${spriteGuid}, type: 3}
  m_Color: {r: ${colour[0]}, g: ${colour[1]}, b: ${colour[2]}, a: 1}
  m_FlipX: 0
  m_FlipY: 0
  m_DrawMode: 1
  m_Size: {x: ${sizeX}, y: ${sizeY}}
  m_AdaptiveModeThreshold: 0.5
  m_SpriteTileMode: 0
  m_WasSpriteAssigned: 1
  m_MaskInteraction: 0
  m_SpriteSortPoint: 0
`;
}

function prefabMeta(guid) {
  return `fileFormatVersion: 2
guid: ${guid}
PrefabImporter:
  externalObjects: {}
  userData:
  assetBundleName:
  assetBundleVariant:
`;
}

const WHITE = [1, 1, 1];
// Sizes here are the R1 values the runtime recomputes from the camera; they are
// written so an object is already right-sized the moment it is instantiated.
const PREFABS = [
  [3210001, 'Crate', 'pf_Crate', G.crate_amber, -6, 0.781, 0.781, WHITE],
  [3220001, 'Hazard', 'pf_Hazard', G.hazard_barrier, -7, 0.9, 0.714, WHITE],
  [3230001, 'RailTile', 'pf_RailTile', G.rail_tile, -18, 4.615, 2.4, WHITE],
  [3240001, 'StationMarker', 'pf_StationMarker', G.station_marker, -15, 0.62, 1.24, WHITE],
  [3250001, 'Cart', 'pf_Cart', G.cart_hero, -4, 1.045, 1.045, WHITE],
];

for (const [id, name, key, spriteGuid, order, sx, sy, col] of PREFABS) {
  fs.writeFileSync(path.join(PREFAB_DIR, name + '.prefab'), prefabYaml(id, name, spriteGuid, order, sx, sy, col));
  fs.writeFileSync(path.join(PREFAB_DIR, name + '.prefab.meta'), prefabMeta(G[key]));
}

console.log('sprite metas:', SPRITES.length, ' prefabs:', PREFABS.length);
