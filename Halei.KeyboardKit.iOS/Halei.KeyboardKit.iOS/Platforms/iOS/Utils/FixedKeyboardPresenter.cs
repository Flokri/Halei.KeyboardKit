#if IOS
using UIKit;
using Microsoft.Maui.Platform;
using Halei.KeyboardKit.iOS.Interfaces;

namespace Halei.KeyboardKit.iOS.Platforms.iOS.Utils;

public static class FixedKeyboardPresenter
{
    private static UIViewController? _hostController;

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
        _hostController = vc;

        UIApplication.SharedApplication.KeyWindow?
            .RootViewController?
            .PresentViewController(vc, true, () =>
            {
                if (page is IPagePresented lifecycle)
                    lifecycle.OnPresented();
            });
    }

    public static void DismissFixedPage()
    {
        _hostController?.DismissViewController(true, null);
        _hostController = null;
    }
}
#endif