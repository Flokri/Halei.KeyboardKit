using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE0130
namespace Halei.KeyboardKit
#pragma warning restore IDE0130
{
    public delegate void KeyboardEventHandler(object sender, KeyboardEventArgs e);

    public class KeyboardEventArgs : EventArgs
    {
        internal KeyboardEventArgs(double keyboardHeight)
        {
            KeyboardHeight = keyboardHeight;
        }

        public double KeyboardHeight { get; }
    }
}
