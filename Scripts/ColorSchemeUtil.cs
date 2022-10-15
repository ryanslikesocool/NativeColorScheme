#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace NativeColorScheme {
    public static class ColorSchemeUtil {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        [DllImport("ColorScheme_macOS")]
        private static extern int getCurrentColorScheme_macOS();

        public static ColorScheme CurrentColorScheme => (ColorScheme)getCurrentColorScheme_macOS();
#elif UNITY_IOS || UNITY_TVOS
        [DllImport("__Internal")]
        private static extern int getCurrentColorScheme_iOS();

        public static ColorScheme CurrentColorScheme => (ColorScheme)getCurrentColorScheme_iOS();
#else
        public static ColorScheme CurrentColorScheme => ColorScheme.Unknown;
#endif
    }
}