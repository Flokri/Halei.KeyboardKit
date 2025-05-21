using Halei.KeyboardKit.iOS.Interfaces;

namespace Halei.KeyboardKit.iOS.Services;

public class NullKeyboardVisibilityService : IKeyboardVisibilityService
{
    public void Subscribe(Action<double> onChanged) {}
    public void Unsubscribe() {}
}