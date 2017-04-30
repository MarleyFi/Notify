using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string args)
        {
            msg = args;
        }
        private string msg;
        public string Message
        {
            get { return msg; }
        }
    }
}
