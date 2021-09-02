#if UNITY_EDITOR_OSX
using UnityEditor;

[InitializeOnLoad]
public class EditorThemeSwitcher
{
    static EditorThemeSwitcher()
    {
        EditorApplication.playModeStateChanged += CheckAndSwitchSkin;
        CheckAndSwitchSkin(PlayModeStateChange.EnteredEditMode);
    }

    static void CheckAndSwitchSkin(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            if (DarkDetector.IsDarkModeEnabled() ^ EditorGUIUtility.isProSkin)
            {
                System.Reflection.Assembly.GetAssembly(typeof(UnityEditorInternal.AssetStore)).GetType("UnityEditorInternal.InternalEditorUtility", true).GetMethod("SwitchSkinAndRepaintAllViews").Invoke(null, null);
            }
        }
    }
}
#endif