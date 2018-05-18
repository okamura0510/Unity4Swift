#import <u4s-Swift.h>

@interface Unity4SwiftPlugin : NSObject
@property(nonatomic, retain)Unity4SwiftViewController *vc;
@end

@implementation Unity4SwiftPlugin
- (void)initPlugin:(NSString *)gameObjectName {
    _vc                = [[Unity4SwiftViewController alloc] init];
    _vc.gameObjectName = gameObjectName;
    [UnityGetGLViewController() addChildViewController:_vc];
    [UnityGetGLViewController().view addSubview:_vc.view];
}

- (void)showAlertDialog:(NSString *)title :(NSString *)message :(NSString *)button :(NSString *)onClose {
    [_vc showAlertDialog:title :message :button :onClose];
}
@end

extern "C" {
    static Unity4SwiftPlugin *plugin = [[Unity4SwiftPlugin alloc] init];

    static NSString *toString(char *chars) {
        return [NSString stringWithCString:chars encoding:NSUTF8StringEncoding];
    }

    void initPlugin(char *gameObjectName) {
        [plugin initPlugin:toString(gameObjectName)];
    }
    
    void showAlertDialog(char *title, char *message, char *button, char *onClose) {
        [plugin showAlertDialog:toString(title) :toString(message) :toString(button) :toString(onClose)];
    }
}
