# NativeColorScheme
System color scheme detection in Unity for macOS and iOS.

## Requirements
### Runtime
- macOS 11+
- iOS 14+
- tvOS 14+

---

### Editor
- macOS 11+, Unity 2020.3+

## Installation (Unity Package Manager)
- Select "Add package from git URL..." from the plus menu in the package manager window.
- Paste the package's git url.
```
https://github.com/ryanslikesocool/NativeColorScheme.git
```

## Usage
### C#
```cs
using NativeColorScheme;

static class Somewhere {
	static Color GetColorForColorScheme() => ColorSchemeUtil.Current switch {
		ColorScheme.Light => Color.white,
		ColorScheme.Dark => Color.black,
		_ => Color.magenta
	};
}
```
Unsupported platforms or OS versions will return `null`.

---

### Editor
Using the Unity editor on macOS, the plugin will automatically detect the system's color scheme and change the editor accordingly.\
The preference can be set to `System`, `Light`, or `Dark` from the `Window/Color Scheme` menu.