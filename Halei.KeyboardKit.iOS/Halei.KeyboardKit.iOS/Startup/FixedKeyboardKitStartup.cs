using Halei.KeyboardKit.iOS.Interfaces;
using Halei.KeyboardKit.iOS.Services;

namespace Halei.KeyboardKit.iOS.Startup;

public static class FixedKeyboardKitStartup
{
    public static MauiAppBuilder UseFixedKeyboardKit(this MauiAppBuilder builder)
    {
#if IOS
    builder.Services.AddSingleton<IKeyboardVisibilityService, KeyboardVisibilityService>();
#else
        builder.Services.AddSingleton<IKeyboardVisibilityService, NullKeyboardVisibilityService>();
#endif
        return builder;
    }
}