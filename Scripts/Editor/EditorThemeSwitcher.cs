#if UNITY_EDITOR_OSX
using UnityEditor;
using UnityEngine;

namespace NativeColorScheme {
    [InitializeOnLoad]
    public class EditorThemeSwitcher {
        static EditorThemeSwitcher() {
            EditorApplication.playModeStateChanged += CheckAndSwitchSkin;
            CheckAndSwitchSkin(PlayModeStateChange.EnteredEditMode);
        }

        private static void CheckAndSwitchSkin(PlayModeStateChange state) {
            if (state == PlayModeStateChange.EnteredEditMode) {
                if (ColorSchemeUtil.CurrentColorScheme == ColorScheme.Dark ^ EditorGUIUtility.isProSkin) {
                    System.Reflection.Assembly.GetAssembly(typeof(UnityEditorInternal.AssetStore)).GetType("UnityEditorInternal.InternalEditorUtility", true).GetMethod("SwitchSkinAndRepaintAllViews").Invoke(null, null);
                }
            }
        }

        [MenuItem("Tools/Debug/Print Current Color Scheme")]
        private static void PrintCurrentColorScheme() {
            Debug.Log(ColorSchemeUtil.CurrentColorScheme);
        }
    }
}
#endif