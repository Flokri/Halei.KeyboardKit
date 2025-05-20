using Maui.iOS.FixedKeyboardKit.Interfaces;

#if IOS
using Maui.iOS.FixedKeyboardKit.Services;
#endif

namespace Maui.iOS.FixedKeyboardKit.Startup;

public static class FixedKeyboardKitStartup
{
    public static MauiAppBuilder UseFixedKeyboardKit(this MauiAppBuilder builder)
    {
#if IOS
        builder.Services.AddSingleton<IKeyboardVisibilityService, KeyboardVisibilityService>();
#endif
        return builder;
    }
}