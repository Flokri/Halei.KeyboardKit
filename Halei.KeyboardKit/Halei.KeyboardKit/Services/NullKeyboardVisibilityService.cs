using Halei.KeyboardKit.Interfaces;

namespace Halei.KeyboardKit.Services;

public class NullKeyboardVisibilityService : IKeyboardVisibilityService
{
    public event EventHandler KeyboardShown
    {
        add { }
        remove { }
    }

    public event KeyboardEventHandler KeyboardShowing
    {
        add { }
        remove { }
    }

    public event EventHandler KeyboardHidden
    {
        add { }
        remove { }
    }
}