using Halei.KeyboardKit.iOS.Interfaces;
using Halei.KeyboardKit.iOS.Services;
#if IOS
using Halei.KeyboardKit.iOS.Utils;
#endif

namespace Halei.KeyboardKit.iOS.Startup;

public static class FixedKeyboardKitStartup
{
    public static MauiAppBuilder UseFixedKeyboardKit(this MauiAppBuilder builder)
    {
#if IOS
        builder.Services.AddSingleton<IKeyboardVisibilityService, KeyboardVisibilityService>();
        builder.Services.AddSingleton<FixedKeyboardPresenter>();
#endif
#if ANDROID
        builder.Services.AddSingleton<IKeyboardVisibilityService, KeyboardVisibilityService>();
#endif
        return builder;
    }
}