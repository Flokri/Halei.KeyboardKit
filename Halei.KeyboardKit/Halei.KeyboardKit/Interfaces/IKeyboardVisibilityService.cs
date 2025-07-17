namespace Halei.KeyboardKit.Interfaces;

public interface IKeyboardVisibilityService
{
    event KeyboardEventHandler KeyboardShowing;
    event EventHandler KeyboardShown;
    event EventHandler KeyboardHidden;
}