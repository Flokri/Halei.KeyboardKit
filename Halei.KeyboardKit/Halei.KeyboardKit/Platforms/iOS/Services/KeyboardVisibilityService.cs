#if IOS
using UIKit;
using Halei.KeyboardKit.Interfaces;

namespace Halei.KeyboardKit.Services;

public partial class KeyboardVisibilityService : IKeyboardVisibilityService
{
    private double _lastHeight;

    public KeyboardVisibilityService()
    {
        UIKeyboard.Notifications.ObserveWillShow((_, args) =>
        {
            var rect = UIKeyboard.FrameEndFromNotification(args.Notification);
            _lastHeight = rect.Height;
            OnKeyboardShowing(_lastHeight);
            
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(300);
                OnKeyboardShown();
            });
        });

        UIKeyboard.Notifications.ObserveWillHide((_, _) =>
        {
            OnKeyboardHidden();
        });
    }
}
#endif