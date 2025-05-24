using Halei.KeyboardKit.Interfaces;

namespace Halei.KeyboardKit.Services;

public class NullKeyboardVisibilityService : IKeyboardVisibilityService
{
    public event Action? KeyboardDidShow
    {
        add { }
        remove { }
    }

    public event Action<double>? KeyboardShown
    {
        add { }
        remove { }
    }

    public event Action? KeyboardHidden
    {
        add { }
        remove { }
    }
}