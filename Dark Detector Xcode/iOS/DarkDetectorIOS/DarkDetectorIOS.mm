//
//  DarkDetectorIOS.mm
//  DarkDetectorIOS
//
//  Created by Ryan Boyer on 9/1/20.
//

#include "DarkDetectorIOS.h"

extern "C" {
    bool _IsDarkModeEnabled() {
        if (@available(iOS 14.0, *)) {
            if(UIScreen.mainScreen.traitCollection.userInterfaceStyle == UIUserInterfaceStyleDark) {
                return true;
            }
        }
    
        return false;
    }
}
