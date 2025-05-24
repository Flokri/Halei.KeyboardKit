#if IOS
using UIKit;
using Halei.KeyboardKit.Interfaces;

namespace Halei.KeyboardKit.Services;

public class KeyboardVisibilityService : IKeyboardVisibilityService
{
    public event Action? KeyboardDidShow;
    public event Action<double>? KeyboardShown;
    public event Action? KeyboardHidden;

    private double _lastHeight;

    public KeyboardVisibilityService()
    {
        UIKeyboard.Notifications.ObserveWillShow((_, args) =>
        {
            var rect = UIKeyboard.FrameEndFromNotification(args.Notification);
            _lastHeight = rect.Height;
            KeyboardShown?.Invoke(_lastHeight);
            
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(300);
                KeyboardDidShow?.Invoke();
            });
        });

        UIKeyboard.Notifications.ObserveWillHide((_, _) =>
        {
            KeyboardHidden?.Invoke();
        });
    }
}
#endif