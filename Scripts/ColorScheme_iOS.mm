#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern "C" {
    int getCurrentColorScheme_iOS() {
        if (@available(iOS 13.0, *)) {
			return (int)[[UITraitCollection currentTraitCollection] userInterfaceStyle];
        }

        return 0;
    }
}
