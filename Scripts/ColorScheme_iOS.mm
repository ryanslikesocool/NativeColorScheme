#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern "C" {
    int getCurrentColorScheme_iOS() {
        if (@available(iOS 13.0, *)) {
			return [[UITraitCollection current] userInterfaceStyle];
        }

        return 0;
    }
}
