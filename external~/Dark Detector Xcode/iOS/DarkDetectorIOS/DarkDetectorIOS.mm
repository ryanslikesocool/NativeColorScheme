// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern "C" {
    int _GetCurrentColorScheme() {
        if (@available(iOS 13.0, *)) {
			return [[UITraitCollection current] userInterfaceStyle];
        }
    
        return 1;
    }
}
