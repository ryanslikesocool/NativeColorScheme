// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace NativeColorScheme {
	public static class ColorSchemeUtil {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
		[DllImport("ColorScheme_macOS")]
		private static extern int getCurrentColorScheme_macOS();

		public static ColorScheme? Current => getCurrentColorScheme_macOS() switch {
			1 => ColorScheme.Light,
			2 => ColorScheme.Dark,
			_ => null
		};
#elif UNITY_IOS || UNITY_TVOS
		[DllImport("__Internal")]
		private static extern int getCurrentColorScheme_iOS();

		public static ColorScheme? Current => getCurrentColorScheme_iOS() switch {
			1 => ColorScheme.Light,
			2 => ColorScheme.Dark,
			_ => null
		};
#else
		public static ColorScheme? Current => null;
#endif
	}
}