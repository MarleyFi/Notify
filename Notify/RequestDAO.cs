using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    class RequestDAO
    {
        public string status { get; set; }

        public string request { get; set; }

        public bool GetStatus()
        {
            if(this.status.Equals("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
