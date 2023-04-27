using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Chess
{
    /// <summary>
    /// Start form that will open MainForm.
    /// </summary>
    public partial class StartScreen : Form
    {
        Thread th;
        /// <summary>
        /// Start form that will open MainForm.
        /// </summary>
        public StartScreen()
        {
            InitializeComponent();
        }

        private void ChessGame_Click(object sender, EventArgs e)
        {

        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            //MainForm gameScreen = new MainForm();
            //gameScreen.Show();
            this.Close();
            th = new Thread(openStartForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Credits_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openCreditForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openStartForm(object ob)
        {
            Application.Run(new MainForm());
        }

        private void openCreditForm(object ob)
        {
            Application.Run(new Credits());
        }
    }
}
