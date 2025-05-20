namespace Maui.iOS.FixedKeyboardKit.Interfaces;

public interface IKeyboardVisibilityService
{
    event Action<double> KeyboardShown;
    event Action KeyboardHidden;

    void Init();
    void Cleanup();
}