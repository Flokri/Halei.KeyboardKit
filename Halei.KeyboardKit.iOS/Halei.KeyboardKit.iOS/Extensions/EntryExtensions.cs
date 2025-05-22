#if IOS || ANDROID

#if ANDROID
using Android.Content;
using Android.Views.InputMethods;
#endif
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
                et.Context?.GetSystemService(Context.InputMethodService) as
                    InputMethodManager;
            
           inputMethodManager.ToggleSoftInput(InputMethodManager.ShowForced, 0);
        }
#endif
    }
}
#endif