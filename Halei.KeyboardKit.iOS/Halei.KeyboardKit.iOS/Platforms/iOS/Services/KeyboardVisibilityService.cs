#if IOS
using Foundation;
using UIKit;
using Halei.KeyboardKit.iOS.Interfaces;

namespace Halei.KeyboardKit.iOS.Platforms.iOS.Services;

public class KeyboardVisibilityService : IKeyboardVisibilityService
{
    private Action<double>? _onHeightChanged;
    private NSObject? _showObserver;
    private NSObject? _hideObserver;

    public KeyboardVisibilityService()
    {
        _showObserver = UIKeyboard.Notifications.ObserveWillShow(OnKeyboardShow);
        _hideObserver = UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHide);
    }

    public void Subscribe(Action<double> onHeightChanged)
    {
        _onHeightChanged = onHeightChanged;
    }

    private void OnKeyboardShow(object? sender, UIKeyboardEventArgs args)
    {
        var height = args.FrameEnd.Height;
        _onHeightChanged?.Invoke(height);
    }

    private void OnKeyboardHide(object? sender, UIKeyboardEventArgs args)
    {
        _onHeightChanged?.Invoke(0);
    }
}
#endif