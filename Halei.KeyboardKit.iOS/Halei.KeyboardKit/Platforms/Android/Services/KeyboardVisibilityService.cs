using Android.App;
using Halei.KeyboardKit.Interfaces;
using Rect = Android.Graphics.Rect;
using View = Android.Views.View;

namespace Halei.KeyboardKit.Services;

#if ANDROID
public class KeyboardVisibilityService : IKeyboardVisibilityService
{
    public event Action? KeyboardDidShow;
    public event Action<double>? KeyboardShown;
    public event Action? KeyboardHidden;

    private readonly Activity _activity;
    private double _lastKeyboardHeight;
    private View? _rootView;
    private int _previousVisibleHeight;

    public KeyboardVisibilityService()
    {
        _activity = Platform.CurrentActivity ?? throw new InvalidOperationException("No current activity found");

        _rootView = _activity.Window.DecorView.FindViewById(Android.Resource.Id.Content);
        if (_rootView != null)
        {
            _rootView.ViewTreeObserver.GlobalLayout += OnGlobalLayout;
        }
    }

    private void OnGlobalLayout(object? sender, EventArgs e)
    {
        if (_rootView == null) return;

        Rect r = new();
        _rootView.GetWindowVisibleDisplayFrame(r);

        int screenHeight = _rootView.RootView.Height;
        int visibleHeight = r.Height();
        int heightDiff = screenHeight - visibleHeight;

        if (_previousVisibleHeight == 0)
        {
            _previousVisibleHeight = visibleHeight;
            return;
        }

        const int threshold = 150;

        if (heightDiff > threshold && visibleHeight != _previousVisibleHeight)
        {
            _lastKeyboardHeight = heightDiff / _activity.Resources.DisplayMetrics.Density;
            KeyboardShown?.Invoke(_lastKeyboardHeight);

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(200);
                KeyboardDidShow?.Invoke();
            });
        }
        else if (heightDiff < threshold && visibleHeight != _previousVisibleHeight)
        {
            KeyboardHidden?.Invoke();
        }

        _previousVisibleHeight = visibleHeight;
    }

    ~KeyboardVisibilityService()
    {
        if (_rootView != null)
        {
            _rootView.ViewTreeObserver.GlobalLayout -= OnGlobalLayout;
        }
    }
}
#endif
