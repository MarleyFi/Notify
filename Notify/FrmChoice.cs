using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Notify.Properties;

namespace Notify
{
    public partial class FrmChoice : Form
    {
        public Button choiceButton1;

        public Button choiceButton2;

        public Button choiceButton3;

        private const int CP_NOCLOSE_BUTTON = 0x200;

        /// <summary>
        /// Initializes a new instance of the <see cref="Notify.FrmChoice"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="infoPicture">Info picture.</param>
        public FrmChoice(string title, Bitmap infoPicture = null)
        {
            InitializeComponent();
            Init();
            labelTitle.Text = title;
            if (infoPicture == null)
            {
                pictureBoxInfo.Image = Resources.Info128;
            }
            else
            {
                pictureBoxInfo.Image = infoPicture;
            }
            
        }

        private void Init()
        {
            choiceButton1 = btn1;
            choiceButton2 = btn2;
            choiceButton3 = btn3;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void FrmChoice_Load(object sender, EventArgs e)
        {

        }

        private void FrmChoice_Shown(object sender, EventArgs e)
        {
            btn1.Visible = !string.IsNullOrEmpty(btn1.Text);
            btn2.Visible = !string.IsNullOrEmpty(btn2.Text);
            btn3.Visible = !string.IsNullOrEmpty(btn3.Text);
        }
    }
}