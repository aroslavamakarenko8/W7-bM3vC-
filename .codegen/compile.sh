#!/usr/bin/env bash
# Offline signature check for the generated C#. Reads Unity's shipped managed
# assemblies; it never launches the editor.
set -u
PROJ="/c/AndroidWorkspace/projects/SnchikosRodes"
U="/c/Program Files/Unity/Hub/Editor/6000.5.10f1/Editor/Data"
SA="$U/Resources/PackageManager/ProjectTemplates/libcache/com.unity.template.2d-cross-platform-2d-6.1.5/ScriptAssemblies"
DN="/c/AndroidWorkspace/tools/dotnet"
OUT="$PROJ/.codegen"
RSP="$OUT/csc.rsp"

: > "$RSP"
{
  echo "-nostdlib"
  echo "-noconfig"
  echo "-target:library"
  echo "-out:\"$(cygpath -m "$OUT")/generated.dll\""
  echo "-define:B_LOGS"
  echo "-langversion:9.0"
  echo "-nowarn:0169,0414,0649,0067"
} >> "$RSP"

for d in "$DN"/packs/Microsoft.NETCore.App.Ref/*/ref/net8.0/*.dll; do
  [ -f "$d" ] && echo "-r:\"$(cygpath -m "$d")\"" >> "$RSP"
done

find "$U/Managed/UnityEngine" -maxdepth 1 -name '*.dll' | while IFS= read -r f; do
  b="$(basename "$f")"
  case "$b" in
    UnityEditor*|UnityEngine.dll|Unity.Cecil*|nunit*|Mono.*) continue ;;
  esac
  echo "-r:\"$(cygpath -m "$f")\"" >> "$RSP"
done

for b in UnityEngine.UI Unity.TextMeshPro Unity.InputSystem Unity.InputSystem.ForUI; do
  [ -f "$SA/$b.dll" ] && echo "-r:\"$(cygpath -m "$SA/$b.dll")\"" >> "$RSP"
done

echo "-r:\"$(cygpath -m "$PROJ/Assets/Plugins/Demigiant/DOTween/DOTween.dll")\"" >> "$RSP"

find "$PROJ/Assets/Plugins/Demigiant/DOTween/Modules" -name '*.cs' 2>/dev/null | while IFS= read -r f; do
  echo "\"$(cygpath -m "$f")\"" >> "$RSP"
done

find "$PROJ/Assets/Scripts" -name '*.cs' | while IFS= read -r f; do
  echo "\"$(cygpath -m "$f")\"" >> "$RSP"
done

"$DN/dotnet.exe" "$DN/sdk/8.0.425/Roslyn/bincore/csc.dll" "@$(cygpath -m "$RSP")" 2>&1 | sed 's/\r$//'
