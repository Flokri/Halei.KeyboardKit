using Halei.KeyboardKit.Interfaces;
using Halei.KeyboardKit.Services;
#if IOS
using Halei.KeyboardKit.Utils;
#endif

namespace Halei.KeyboardKit.Startup;

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