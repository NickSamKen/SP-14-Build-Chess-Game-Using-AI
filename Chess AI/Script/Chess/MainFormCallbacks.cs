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
    /// MainForm : WinForm, UIBoard
    /// </summary>
    public partial class MainForm : Form, UIBoard
    {        
        TimeSpan m_whiteTime = new TimeSpan(0);
        TimeSpan m_blackTime = new TimeSpan(0);

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBoard();

            // setup turn indicator
            picTurn.SizeMode = PictureBoxSizeMode.StretchImage;
            picTurn.Image = graphics.TurnIndicator[Player.WHITE];

            // setup initial ai depth            
            AI.DEPTH = 3;

            SetStatus(false, "Choose New Game.");

            // setup menu

            endCurrentGameToolStripMenuItem.Enabled = false;
        }

        private void windowClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
            frmAIseting.Close();
        }

        private void Shutdown(object sender, EventArgs e)
        {
            Stop();
            this.Close();
        }

        private void endGame(object sender, EventArgs e)
        {
            Stop();
        }

        private void NewGame(object sender, EventArgs e)
        {
            ToolStripMenuItem button = (ToolStripMenuItem)sender;
            if (button.Text.StartsWith("New AI vs AI"))
            {
                NewGame(GameMode.BothAuto);
            }
            else if (button.Text.StartsWith("New BlackAI vs Player"))
            {
                NewGame(GameMode.BlackAuto);
            }
            else if (button.Text.StartsWith("New Player vs Player"))
            {
                NewGame(GameMode.Manual);
            }
            else if (button.Text.StartsWith("New WhiteAI vs Player"))
            {
                NewGame(GameMode.WhiteAuto);
            }
        }       

        // ---
        // Player Turn Timer
        // ---
        private void tmrWhite_Tick(object sender, EventArgs e)
        {
            m_whiteTime = m_whiteTime.Add(new TimeSpan(0, 0, 0, 0, tmrWhite.Interval));
            lblWhiteTime.Text = string.Format("{0:d2}:{1:d2}:{2:d2}.{3:d1}", m_whiteTime.Hours, m_whiteTime.Minutes, m_whiteTime.Seconds, m_whiteTime.Milliseconds / 100);
        }

        private void tmrBlack_Tick(object sender, EventArgs e)
        {
            m_blackTime = m_blackTime.Add(new TimeSpan(0, 0, 0, 0, tmrBlack.Interval));
            lblBlackTime.Text = string.Format("{0:d2}:{1:d2}:{2:d2}.{3:d1}", m_blackTime.Hours, m_blackTime.Minutes, m_blackTime.Seconds, m_blackTime.Milliseconds / 100);
        }

        
    }
}
