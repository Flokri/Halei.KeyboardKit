namespace Halei.KeyboardKit.Interfaces;

public interface IKeyboardVisibilityService
{
    event Action KeyboardDidShow;
    event Action<double> KeyboardShown;
    event Action KeyboardHidden;
}