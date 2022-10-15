# NativeColorScheme
System color scheme detection in Unity for macOS and iOS (runtime) and macOS (editor).

## Requirements
Color Scheme requires macOS 11 or later, or iOS 14 or later

**Recommended Installation** (Unity Package Manager)
- "Add package from git URL..."
- `https://github.com/ryanslikesocool/NativeColorScheme.git`

**Alternate Installation**
- Get the latest [release](https://github.com/ryanslikesocool/ColorScheme/releases)
- Open with the desired Unity project
- Import into the Plugins folder

## Usage
Get the value from `ColorScheme.ColorSchemeUtil.CurrentColorScheme` from anywhere in your code and use accordingly.\
Unsupported platforms/OS versions will return `ColorScheme.Unknown`.
