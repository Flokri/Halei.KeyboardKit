#if IOS
using UIKit;
using Microsoft.Maui.Platform;
using Halei.KeyboardKit.Interfaces;

namespace Halei.KeyboardKit.Utils;

public class FixedKeyboardPresenter : IPagePresenter
{
    private UIViewController? _hostController;

    public void Show(Page page)
    {
        var mauiContext = Application.Current.Windows.FirstOrDefault()?.Handler?.MauiContext;
        if (mauiContext is null)
            throw new InvalidOperationException("MauiContext is not available");

        var handler = page.ToHandler(mauiContext);
        var nativeView = handler.PlatformView;
        if (nativeView is null)
            throw new InvalidOperationException("Could not render page to native view");

        var vc = new UIViewController();
        vc.View!.BackgroundColor = UIColor.White;

        nativeView.Frame = UIScreen.MainScreen.Bounds;
        nativeView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
        vc.View!.AddSubview(nativeView);

        vc.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
        vc.AutomaticallyAdjustsScrollViewInsets = false;
        vc.EdgesForExtendedLayout = UIRectEdge.All;

        UIApplication.SharedApplication.KeyWindow!.RootViewController?
            .PresentViewController(vc, true, null);
        
        if (page is IPagePresented lifecycle)
            lifecycle.OnPresented();
    }

    public void Dismiss(Page page)
    {
        _hostController?.DismissViewController(animated: true, completionHandler: null);
        _hostController = null;
    }
}
#endif