namespace Halei.KeyboardKit.iOS.Interfaces;

public interface IKeyboardVisibilityService
{
    event Action<double> KeyboardShown;
    event Action KeyboardHidden;

    void Init();
    void Cleanup();
}