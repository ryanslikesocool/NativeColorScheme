//
//  DarkDetector.h
//  DarkDetector
//
//  Created by Ryan Boyer on 8/31/20.
//

#include "DarkDetectorMacOS.h"

extern "C" {
    bool _IsDarkModeEnabled() {
        if (@available(macOS 11.0, *)) {
            if([NSApplication.sharedApplication.effectiveAppearance.name.lowercaseString rangeOfString:@"dark"].location != NSNotFound) {
                return true;
            }
        }
    
        return false;
    }
}
