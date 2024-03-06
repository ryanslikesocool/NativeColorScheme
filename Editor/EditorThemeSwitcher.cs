#if UNITY_EDITOR_OSX
using UnityEditor;

namespace NativeColorScheme {
	public static class EditorThemeSwitcher {
		private static System.Reflection.MethodInfo switchSkinMethod;

		public static ColorScheme? DesiredAppearance {
			get => (byte)EditorPrefs.GetInt(SETTING_NAME, 0) switch {
				1 => ColorScheme.Light,
				2 => ColorScheme.Dark,
				_ => null
			};
			set {
				int newValue = value switch {
					ColorScheme.Light => 1,
					ColorScheme.Dark => 2,
					_ => 0
				};
				EditorPrefs.SetInt(SETTING_NAME, newValue);
			}
		}

		[InitializeOnLoadMethod]
		static void Load() {
			switchSkinMethod = System.Reflection.Assembly.GetAssembly(typeof(UnityEditorInternal.AssetStore)).GetType("UnityEditorInternal.InternalEditorUtility", true).GetMethod("SwitchSkinAndRepaintAllViews");

			EditorApplication.update += UpdateColorScheme;
			//EditorApplication.focusChanged += FocusChanged;
			SetColorScheme(DesiredAppearance);
		}

		private static void FocusChanged(bool state)
			=> UpdateColorScheme();

		private static void SetDesiredColorScheme(ColorScheme? colorScheme) {
			DesiredAppearance = colorScheme;
			SetColorScheme(DesiredAppearance, true);
		}

		private static void UpdateColorScheme()
			=> SetColorScheme(DesiredAppearance);

		private static void SetColorScheme(ColorScheme? colorScheme, bool force = false) {
			ColorScheme finalColorScheme = colorScheme ?? ColorSchemeUtil.Current ?? ColorScheme.Light;

			if (finalColorScheme != DesiredAppearance || force) {
				Menu.SetChecked(SYSTEM_PATH, colorScheme == null);
				Menu.SetChecked(LIGHT_PATH, colorScheme == ColorScheme.Light);
				Menu.SetChecked(DARK_PATH, colorScheme == ColorScheme.Dark);

				if (finalColorScheme == ColorScheme.Dark ^ EditorGUIUtility.isProSkin) {
					switchSkinMethod.Invoke(null, null);
				}
			}
		}

		// MARK: - Menu

		[MenuItem(SYSTEM_PATH, priority = 0)]
		private static void SetSystem()
			=> SetDesiredColorScheme(null);

		[MenuItem(LIGHT_PATH, priority = 11)]
		private static void SetLight()
			=> SetDesiredColorScheme(ColorScheme.Light);

		[MenuItem(DARK_PATH, priority = 12)]
		private static void SetDark()
			=> SetDesiredColorScheme(ColorScheme.Dark);

		// MARK: - Constants

		private const string SETTING_NAME = "NativeColorScheme.ColorScheme";

		private const string SYSTEM_PATH = "Window/Color Scheme/System";
		private const string LIGHT_PATH = "Window/Color Scheme/Light";
		private const string DARK_PATH = "Window/Color Scheme/Dark";
	}
}
#endif