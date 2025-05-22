#if IOS || ANDROID
using Microsoft.Maui.Controls;

namespace Halei.KeyboardKit.iOS.Extensions;

public static class EntryExtensions
{
    public static void FocusWithKeyboard(this Entry entry)
    {
#if IOS
        if (entry.Handler?.PlatformView is UIKit.UITextField tf)
        {
            tf.BecomeFirstResponder();
        }
#elif ANDROID
        if (entry.Handler?.PlatformView is Android.Widget.EditText et)
        {
            et.RequestFocus();
            var inputMethodManager =
                et.Context?.GetSystemService(Android.Content.Context.InputMethodService) as
                    Android.Views.InputMethods.InputMethodManager;
            inputMethodManager?.ShowSoftInput(et, Android.Views.InputMethods.ShowFlags.Implicit);
        }
#endif
    }
}
#endif