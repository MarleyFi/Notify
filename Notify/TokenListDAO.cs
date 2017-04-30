using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    public partial class TokenListDAO
    {
        public List<TokenDAO> ApplicationTokens { get; set; }

        public void AddToken(string name, string id)
        {
            ApplicationTokens.Add(new TokenDAO(name, id));
        }

        public void DelToken(int index)
        {
            ApplicationTokens.RemoveAt(index);
        }
    }
}
