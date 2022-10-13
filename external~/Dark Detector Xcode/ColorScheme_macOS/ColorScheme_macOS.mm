#import <AppKit/AppKit.h>
#import <Foundation/Foundation.h>

extern "C" {
int getCurrentColorScheme_macOS() {
    if (@available(macOS 11.0, *)) {
        if (NSApplication.sharedApplication.effectiveAppearance.name == NSAppearanceNameAqua
            || NSApplication.sharedApplication.effectiveAppearance.name == NSAppearanceNameVibrantLight
            || NSApplication.sharedApplication.effectiveAppearance.name == NSAppearanceNameAccessibilityHighContrastAqua
            || NSApplication.sharedApplication.effectiveAppearance.name == NSAppearanceNameAccessibilityHighContrastVibrantLight) {
            return 1;
        } else if (NSApplication.sharedApplication.effectiveAppearance.name == NSAppearanceNameDarkAqua
                   || NSApplication.sharedApplication.effectiveAppearance.name == NSAppearanceNameVibrantDark
                   || NSApplication.sharedApplication.effectiveAppearance.name == NSAppearanceNameAccessibilityHighContrastDarkAqua
                   || NSApplication.sharedApplication.effectiveAppearance.name == NSAppearanceNameAccessibilityHighContrastVibrantDark) {
            return 2;
        }
    }

    return 0;
}
}
