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
        bool m_aigame = false;
        bool m_checkmate = false;
        bool m_manualBoard = false; // Don't init board on new game
        //int bwplayer = 0;

        FrmAIsetting frmAIseting = new FrmAIsetting();

        Chess chess;
                
        /// <summary>
        /// Stop all current activity / games and reset everything.
        /// </summary>
        private void Stop()
        {
            SetStatus(false, "Please create a New Game first.");

            // stop the ai and reset chess
            AI.STOP = true;
            chess = null;

            // reset turn indicator
            SetTurn(Player.WHITE);

            // reset timers
            tmrWhite.Stop();
            tmrBlack.Stop();
            m_whiteTime = new TimeSpan(0);
            m_blackTime = new TimeSpan(0);
            lblWhiteTime.Text = m_whiteTime.ToString("c");
            lblBlackTime.Text = m_blackTime.ToString("c");

            // clear the board ui and log
            SetBoard(new ChessBoard());
            txtLog.Text = "";

            // reset board status vars
            m_checkmate = false;
            m_aigame = false;

            // reset the menu
            endCurrentGameToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Set up a new game for the specified number of players.
        /// </summary>
        private void NewGame(GameMode gameMode)
        {
            // clean up all of the things first
            if (!m_manualBoard) Stop();

            // create new game for number of players
            m_aigame = (gameMode == GameMode.BothAuto);
            chess = new Chess(this, gameMode, !m_manualBoard);

            // show turn status
            SetTurn(Player.WHITE);
            SetStatus(false, "White's turn");

            // reset timers
            m_whiteTime = new TimeSpan(0);
            m_blackTime = new TimeSpan(0);
            lblWhiteTime.Text = m_whiteTime.ToString("c");
            lblBlackTime.Text = m_blackTime.ToString("c");
            //turn off pause button during enemy team
            /*if(gameMode == GameMode.Manual)
            {
                bwplayer = ;
            }*/
            // show ai difficulty
            if (gameMode != GameMode.Manual && gameMode != GameMode.NotStarted)
            {
                LogMove("AI Difficulty " + AI.DEPTH + "\r\n");
                LogMove("_________________ " );
            }
            
            // start the game
            SetStatus(false, "White's turn");
            if (m_aigame)
            {
                new Thread(chess.AISelect).Start();
            }
            
            if (gameMode==GameMode.WhiteAuto)
            {                
                SetStatus(true, "White's turn");
                new Thread(chess.AISelect).Start();
            }
            tmrWhite.Start();

            // allow stopping the game
            endCurrentGameToolStripMenuItem.Enabled = true;
        }

        public void SetTurn(Player p)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetTurn(p)));
                return;
            }
            // update the turn indicator
            if (chess != null)
            {
                picTurn.Image = graphics.TurnIndicator[chess.Turn];
            }
            else
            {
                picTurn.Image = graphics.TurnIndicator[Player.WHITE];
            }
                // if not creating a board
                if (!m_manualBoard)
            {
                // toggle whos timer is running
                if (p == Player.WHITE)
                {
                    tmrBlack.Stop();
                    tmrWhite.Start();
                }
                else
                {
                    tmrWhite.Stop();
                    tmrBlack.Start();
                }

                // if game over just stop timers
                if (chess != null && (m_checkmate || chess.detectCheckmate()))
                {
                    tmrWhite.Stop();
                    tmrBlack.Stop();
                }
            }
        }

        public void SetBoard(ChessBoard board)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetBoard(board)));
                return;
            }

            // update all tiles on board
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    SetPiece(board.Grid[i][j].piece, board.Grid[i][j].player, j, i);
        }

        public void LogMove(string move)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => LogMove(move)));
                return;
            }

            // reset check indicators
            lblWhiteCheck.Visible = false;
            lblBlackCheck.Visible = false;
            lblWhiteOrBlackChecked.Visible = false;

            // show check indicator
            if (move.Contains("+"))
            {
                lblWhiteCheck.Visible = chess.Turn == Player.BLACK;
                lblBlackCheck.Visible = chess.Turn == Player.WHITE;
                lblWhiteOrBlackChecked.Visible = true;
            }
            txtLog.AppendText(move);
            if (chess.Turn == Player.BLACK)
            {
                txtLog.AppendText(" \t" + lblBlackTime.Text) ;
            }
            if (chess.Turn == Player.WHITE)
            {
                txtLog.AppendText(" \t" + lblWhiteTime.Text);
            }
        }

        public void SetStatus(bool thinking, string message)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetStatus(thinking, message)));
                return;
            }

            // update status text and progress bar
            lblStatus.Text = message;
            if (thinking)
            {
                prgThinking.MarqueeAnimationSpeed = 30;
                prgThinking.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                prgThinking.MarqueeAnimationSpeed = 0;
                prgThinking.Value = 0;
                prgThinking.Style = ProgressBarStyle.Continuous;
            }
        }

        private void difficultyDepthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAIseting.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void splitView_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
