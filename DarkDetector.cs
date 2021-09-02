#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
using System.Runtime.InteropServices;
#endif

public static class DarkDetector
{
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    [DllImport("DarkDetectorMacOS")]
#elif UNITY_IOS
    /// Instead of "DarkDetectorIOS" like I would have preferred, it seems that "__Internal" is required
    [DllImport("__Internal")]
#endif
    private static extern bool _IsDarkModeEnabled();

    public static bool IsDarkModeEnabled()
    {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
        /// Return the value retrieved from the native plugin
        return _IsDarkModeEnabled();
#else
        /// Return dark theme = false (light theme) if the plugin is not supported on a platform
        return false;
#endif
    }
}