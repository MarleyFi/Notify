using System;

namespace Notify
{
    class TextBoxEx : System.Windows.Forms.TextBox
    {
        public TextBoxEx(string text)
        {
            passiveText = text;
            //this.TextChanged += TextBoxEx_TextChanged;
            this.GotFocus += TextBoxEx_GotFocus;
            this.Leave += TextBoxEx_Leave;
            TextBoxEx_Leave(this, null);
        }

        string passiveText;

        private void TextBoxEx_Leave(object sender, EventArgs e)
        {
            if (this.Text == string.Empty)
            {
                Text = passiveText;
            }
            this.ForeColor = System.Drawing.Color.Gray;
        }

        private void TextBoxEx_GotFocus(object sender, EventArgs e)
        {
            if(this.Text == passiveText)
            {
                this.Text = string.Empty;
            }
            this.ForeColor = System.Drawing.Color.Black;
        }
    }
}
