using Halei.KeyboardKit.iOS.Interfaces;

namespace Halei.KeyboardKit.iOS.Views;

public abstract class FixedKeyboardPageBase(IKeyboardVisibilityService keyboardService)
    : ContentPage, IManualLifecyclePage
{
    public void OnPresented()
    {
        keyboardService.KeyboardShown += HandleKeyboardShown;
        keyboardService.KeyboardHidden += HandleKeyboardHidden;
        keyboardService.Init();

        OnPresentedCore();
    }

    protected virtual void HandleKeyboardShown(double height) => OnKeyboardShown(height);
    protected virtual void HandleKeyboardHidden() => OnKeyboardHidden();

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        keyboardService.KeyboardShown -= HandleKeyboardShown;
        keyboardService.KeyboardHidden -= HandleKeyboardHidden;
        keyboardService.Cleanup();
    }

    /// <summary>
    /// Called after the keyboard service has been initialized and observers registered.
    /// Use this in your subclass to add startup logic.
    /// </summary>
    protected virtual void OnPresentedCore() { }

    /// <summary>
    /// Called when the keyboard becomes visible.
    /// </summary>
    protected virtual void OnKeyboardShown(double height) { }

    /// <summary>
    /// Called when the keyboard is hidden.
    /// </summary>
    protected virtual void OnKeyboardHidden() { }
}