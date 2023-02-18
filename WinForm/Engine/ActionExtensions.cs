using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.Engine
{
    public static class ActionExtensions
    {

        public static void InvokeUI<T>(
            this Action action,
            T sender)
            where T : Control
        {

            if (sender.InvokeRequired)
            {
                sender.Invoke(action);
            }
            else
            {
                action();
            }
        }

    }
}
