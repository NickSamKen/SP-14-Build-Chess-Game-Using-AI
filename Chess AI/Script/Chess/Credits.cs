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
    public partial class Credits : Form
    {
        Thread th;
        /// <summary>
        /// Credit form.
        /// </summary>
        public Credits()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openStartForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openStartForm(object ob)
        {
            Application.Run(new StartScreen());
        }

        private void AaranDailey_Click(object sender, EventArgs e)
        {
            label1.Text = "Team lead, Lead Documentarian, quality tester, \nand designer";
        }

        private void NicholasKennel_Click(object sender, EventArgs e)
        {
            label1.Text = "\n\n\n\nUI designer, Assistant Documentarian, and Implementer";
        }

        private void HaigeZhu_Click(object sender, EventArgs e)
        {
            label1.Text = "\n\n\n\n\n\n\nAI designer and implementer";
        }
    }
}
