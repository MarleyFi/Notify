using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notify.Properties;

namespace Notify
{
    public partial class FrmVariables : Form
    {
        public FrmVariables()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Size = new System.Drawing.Size(500, 200);
            Icon = Resources.Variable;
            Name = "Variables";
            Text = "Available variables";
            SetupVariables();
        }

        private static DataStore dataStore = FrmNotify.dataStore;

        /// <summary>
        /// Oberflächenkomponente für das Auflisten aller verfügbaren Variablen
        /// </summary>
        private ListBox listBoxVariables = new ListBox()
        {
            Size = new System.Drawing.Size(500, 200),
        };

        /// <summary>
        /// Baut den Inhalt der Form FrmVariables
        /// </summary>
        private void SetupVariables()
        {
            this.Controls.Clear();
            List<string> content = new List<string>();
            for (int i = 0; i < dataStore.Variables.Length; i++)
            {
                content.Add(string.Format("{0} - {1}: >{2}<", dataStore.Variables[i], dataStore.VariablesDesc[i], dataStore.GetVariable(dataStore.Variables[i])));
            }
            this.Controls.Add(listBoxVariables);
            listBoxVariables.DataSource = content;
            this.Controls[0].MouseDown += ListBox_MouseDown;
        }

                /// <summary>
        /// Baut das ContextMenu für FrmVariables
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip BuildVariablesContextMenu()
        {
            dataStore.var = Supporter.ExtraxtParams(listBoxVariables.SelectedItem.ToString());
            //ToolStripMenuItem insertAtCursor = new ToolStripMenuItem("Insert", Resources.Rename24);
            //insertAtCursor.Click += InsertAtCursor_Click;
            ToolStripMenuItem copyToClipboard = new ToolStripMenuItem("Copy", Resources.Clipboard24);
            copyToClipboard.Click += CopyToClipboard_Click;
            ContextMenuStrip menu = new ContextMenuStrip();
            //menu.Items.Add(insertAtCursor);
            menu.Items.Add(copyToClipboard);
            return menu;
        }

        /// <summary>
        /// Öffnet das ContextMenü an der Cursor-Position
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                BuildVariablesContextMenu().Show(Cursor.Position);
        }

        /// <summary>
        /// Kopiert die ausgewählte Variable in die Zwischenablage
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void CopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dataStore.var + Environment.NewLine);
        }

        ///// <summary>
        ///// Fügt die ausgewählte Variable an die aktuelle Cursor-Positon im Body-Textfeld
        ///// </summary>
        ///// <param name="sender">Sender.</param>
        ///// <param name="e">E.</param>
        //private void InsertAtCursor_Click(object sender, EventArgs e)
        //{
        //    richTextBoxBody.Text = richTextBoxBody.Text.Insert(richTextBoxBody.SelectionStart, dataStore.var);
        //}

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            //switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            //{
            //    case DialogResult.No:
            //        e.Cancel = true;
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
