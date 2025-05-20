using Foundation;
using Maui.iOS.FixedKeyboardKit.Interfaces;
using UIKit;

namespace Maui.iOS.FixedKeyboardKit.Services;

public class KeyboardVisibilityService : IKeyboardVisibilityService
{
    public event Action<double>? KeyboardShown;
    public event Action? KeyboardHidden;

    private NSObject? _showObserver;
    private NSObject? _hideObserver;

    public void Init()
    {
        _showObserver ??= UIKeyboard.Notifications.ObserveWillShow((s, e) =>
        {
            var height = UIKeyboard.FrameEndFromNotification(e.Notification).Height;
            KeyboardShown?.Invoke(height);
        });

        _hideObserver ??= UIKeyboard.Notifications.ObserveWillHide((s, e) =>
        {
            KeyboardHidden?.Invoke();
        });
    }

    public void Cleanup()
    {
        _showObserver?.Dispose();
        _hideObserver?.Dispose();
        _showObserver = null;
        _hideObserver = null;
    }
}