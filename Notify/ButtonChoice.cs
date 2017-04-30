using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notify.Properties;

namespace Notify
{
    class ButtonChoice
    {
        public ButtonChoice(string title, Bitmap infoPicture = null)
        {
            Title = title;
            if (infoPicture != null)
            {
                Picture = infoPicture;
            }
            else
            {
                Picture = Resources.ArrowRightGreen32;
            }
        }

        public string Title;

        public Bitmap Picture;
    }
}
