using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halei.KeyboardKit.Services
{
    public partial class KeyboardVisibilityService
    {
        public event KeyboardEventHandler KeyboardShowing;
        public event EventHandler KeyboardShown;
        public event EventHandler KeyboardHidden;

        protected void OnKeyboardShowing(double keyboardHeight) => KeyboardShowing?.Invoke(this, new KeyboardEventArgs(keyboardHeight));

        protected void OnKeyboardShown() => KeyboardShown?.Invoke(this, EventArgs.Empty);

        protected void OnKeyboardHidden() => KeyboardHidden?.Invoke(this, EventArgs.Empty);
    }
}
