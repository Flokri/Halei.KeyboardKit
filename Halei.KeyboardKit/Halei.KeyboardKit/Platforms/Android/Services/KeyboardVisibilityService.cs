using Android.App;
using Halei.KeyboardKit.Interfaces;
using Rect = Android.Graphics.Rect;
using View = Android.Views.View;

namespace Halei.KeyboardKit.Services;

#if ANDROID
public partial class KeyboardVisibilityService : IKeyboardVisibilityService
{
    private readonly Activity _activity;
    private double _lastKeyboardHeight;
    private View? _contentView;
    private int? _previousVisibleHeight;

    public KeyboardVisibilityService()
    {
        _activity = Platform.CurrentActivity ?? throw new InvalidOperationException("No current activity found");

        _contentView = _activity.Window.DecorView.FindViewById(Android.Resource.Id.Content);

        if (_contentView == null)
            throw new InvalidOperationException("Content view not found");

        _contentView.ViewTreeObserver.GlobalLayout += ContentView_GlobalLayout;
    }

    private void ContentView_GlobalLayout(object? sender, EventArgs e)
    {
        Rect windowBounds = new();
        _contentView.GetWindowVisibleDisplayFrame(windowBounds);

        int screenHeight = _contentView.RootView.Height;
        int visibleHeight = windowBounds.Height();

        int heightDiff = screenHeight - visibleHeight;

        if (!_previousVisibleHeight.HasValue)
        {
            _previousVisibleHeight = visibleHeight;
            return;
        }

        const int threshold = 150;

        if (heightDiff > threshold && visibleHeight != _previousVisibleHeight)
        {
            _lastKeyboardHeight = heightDiff / _activity.Resources.DisplayMetrics.Density;
            OnKeyboardShowing(_lastKeyboardHeight);

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(200);
                OnKeyboardShown();
            });
        }
        else if (heightDiff < threshold && visibleHeight != _previousVisibleHeight)
        {
            OnKeyboardHidden();
        }

        _previousVisibleHeight = visibleHeight;
    }

    ~KeyboardVisibilityService()
    {
        if (_contentView != null)
        {
            _contentView.ViewTreeObserver.GlobalLayout -= ContentView_GlobalLayout;
        }
    }
}
#endif
