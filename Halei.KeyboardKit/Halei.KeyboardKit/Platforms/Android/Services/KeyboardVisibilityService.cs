using Android.App;
using AndroidX.Core.View;
using Halei.KeyboardKit.Interfaces;
using Rect = Android.Graphics.Rect;
using View = Android.Views.View;

namespace Halei.KeyboardKit.Services;

#if ANDROID
public partial class KeyboardVisibilityService : Java.Lang.Object, IOnApplyWindowInsetsListener, IKeyboardVisibilityService
{
    private readonly Activity _activity;

    public KeyboardVisibilityService()
    {
        _activity = Platform.CurrentActivity ?? throw new Exception("No current activity");
        SetupListener();
    }

    private void SetupListener()
    {
        var rootView = _activity.Window.DecorView;

        ViewCompat.SetOnApplyWindowInsetsListener(rootView, this);
    }

    private bool _isKeyboardVisible;
    public WindowInsetsCompat? OnApplyWindowInsets(View? v, WindowInsetsCompat? insets)
    {
        var imeVisible = insets.IsVisible(WindowInsetsCompat.Type.Ime());
        var imeHeight = insets.GetInsets(WindowInsetsCompat.Type.Ime()).Bottom / _activity.Resources.DisplayMetrics.Density;

        if (imeVisible && !_isKeyboardVisible)
        {
            _isKeyboardVisible = true;
            KeyboardShowing?.Invoke(this, new KeyboardEventArgs(imeHeight));
            KeyboardShown?.Invoke(this, EventArgs.Empty);
        }
        else if (!imeVisible && _isKeyboardVisible)
        {
            _isKeyboardVisible = false;
            KeyboardHidden?.Invoke(this, EventArgs.Empty);
        }

        return insets;
    }
}

#endif