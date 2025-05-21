#if IOS
using UIKit;
using Microsoft.Maui.Controls.Platform;

namespace Halei.KeyboardKit.iOS.Extensions;

public static class EntryExtensions
{
    public static void FocusWithKeyboard(this Entry entry)
    {
        if (entry.Handler?.PlatformView is UITextField tf)
        {
            tf.BecomeFirstResponder();
        }
    }
}
#endif