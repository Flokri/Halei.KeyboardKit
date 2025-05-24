#if IOS || ANDROID

#if ANDROID
using Android.Content;
using Android.Views.InputMethods;
#endif
using Microsoft.Maui.Controls;

namespace Halei.KeyboardKit.Extensions;

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
        if (entry.Handler?.PlatformView is Android.Widget.EditText et && et.Context is Context context)
        {
            et.Post(() =>
            {
                et.RequestFocus();
                
                var imm = context.GetSystemService(Context.InputMethodService) as InputMethodManager;
                imm?.ShowSoftInput(et, ShowFlags.Forced);
            });
        }
#endif
    }
}
#endif