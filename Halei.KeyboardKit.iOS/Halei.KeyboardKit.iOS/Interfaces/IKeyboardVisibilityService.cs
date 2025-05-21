namespace Halei.KeyboardKit.iOS.Interfaces;

public interface IKeyboardVisibilityService
{
    event Action KeyboardDidShow;
    event Action<double> KeyboardShown;
    event Action KeyboardHidden;
}