using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    public partial class TokenDAO
    {
        public TokenDAO(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
        public string name { get; set; }
        public string id { get; set; }
    }
}
