#if IOS
using Halei.KeyboardKit.iOS.Interfaces;
using Microsoft.Maui.Platform;
using UIKit;

namespace Halei.KeyboardKit.iOS.Utils;

public static class FixedKeyboardPresenter
{
    public static void ShowFixedPage(Page page)
    {
        var vc = new UIViewController();
        var mauiContext = Application.Current?.Windows[0].Handler?.MauiContext;
        if (mauiContext != null)
        {
            var handler = page.ToHandler(mauiContext);
            var nativeView = handler.PlatformView;

            nativeView!.Frame = UIScreen.MainScreen.Bounds;
            nativeView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            vc.View!.AddSubview(nativeView);
        }

        vc.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;

        UIApplication.SharedApplication.KeyWindow?.RootViewController?
            .PresentViewController(vc, true, null);

        if (page is IManualLifecyclePage lifecycle)
            lifecycle.OnPresented();
    }
}
#endif