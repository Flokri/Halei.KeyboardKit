namespace Halei.KeyboardKit.iOS.Interfaces;

public interface IKeyboardVisibilityService
{
    void Subscribe(Action<double> onHeightChanged);
}