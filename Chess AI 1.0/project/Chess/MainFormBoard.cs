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
    public partial class MainForm : Form, UIBoard
    {
        const int PADDING = 10;
        const string DATA_PATH = @"/data/png/";

        private PictureBox[][] Board;
        Graphics graphics = new Graphics(System.Windows.Forms.Application.StartupPath+DATA_PATH);
        private Label[] LabelRow;
        private Label[] LabelCol;
        //Board BackColor
        private Color BoardBackColorDark = Color.FromArgb(147, 61, 0);// Color.Black;
        private Color BoardBackColorLight = Color.FromArgb(232, 208, 170); //Color.White;

        private void CreateBoard()
        {
            // create the board pieces
            Board = new PictureBox[8][];
            LabelRow = new Label[8];
            LabelCol = new Label[8];
            for (int i = 0; i < 8; i++)
            {
                Board[i] = new PictureBox[8];
                for (int j = 0; j < 8; j++)
                {
                    Board[i][j] = new PictureBox();
                    Board[i][j].Parent = this.splitView.Panel1;
                    Board[i][j].Click += BoardClick;
                    Board[i][j].BackColor = ((j + i) % 2 == 0) ? BoardBackColorDark : BoardBackColorLight;
                    Board[i][j].SizeMode = PictureBoxSizeMode.StretchImage;                    
                }
                LabelRow[i] = new Label();
                LabelRow[i].Parent = this.splitView.Panel1;
                LabelCol[i] = new Label();
                LabelCol[i].Parent = this.splitView.Panel1;
            }

            // align the board
            ResizeBoard(null, null);
        }

        private void ResizeBoard(object sender, EventArgs e)
        {
            // make sure board is initialized
            if (Board == null || Board[0] == null || Board[0][0] == null) return;

            // smallest of height or width
            int val = Math.Min(this.splitView.Panel1.Height - PADDING * 4, this.splitView.Panel1.Width - PADDING * 2);

            // 8 x 8 grid
            int width = val / 8;
            int height = val / 8;

            // center padding/spacing like { margin: auto auto; }
            int left = (this.splitView.Panel1.Width - val) / 2;
            int top = (this.splitView.Panel1.Height - val) / 2;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Board[i][j].Left = j * width + left;
                    Board[i][j].Top = val - (i + 1) * height + top;
                    Board[i][j].Width = width;
                    Board[i][j].Height = height;
                }                
                LabelRow[i].Text = (i+1).ToString();
                LabelRow[i].Left = left - PADDING;
                LabelRow[i].Top = val - (i + 1) * height + top;
                LabelRow[i].Height = height;
                LabelRow[i].Width = PADDING;
                LabelRow[i].TextAlign = ContentAlignment.MiddleLeft;

                LabelCol[i].Text = ((char)(65+i)).ToString();
                LabelCol[i].Left = i * width + left;
                LabelCol[i].Top = 8 * height + top+5;
                LabelCol[i].Height = PADDING;
                LabelCol[i].Width = width;
                LabelCol[i].TextAlign = ContentAlignment.TopCenter;

            }
        }

        private void SetPiece(Piece piece, Player player, int letter, int number)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetPiece(piece, player, letter, number)));
                return;
            }

            // out of bounds
            if (letter < 0 || letter > 7 || number < 0 || number > 7)
                return; // throw new IndexOutOfRangeException("Chess board letter or number out of range");

            // clear tile
            if (piece == Piece.NONE)
            {
                Board[number][letter].Image = null;
                Board[number][letter].Invalidate();
                return;
            }

            // update our render
            Board[number][letter].Image = graphics.Pieces[player][piece];
            Board[number][letter].Invalidate();
        }

        private void BoardClick(object sender, EventArgs e)
        {
            if (chess != null && !m_checkmate)
            {
                // clear board
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        Board[i][j].BackColor = ((i + j) % 2 == 0) ? BoardBackColorDark : BoardBackColorLight;

                for (int i = 0; i < 8; i++)
                {
                    int k = Array.IndexOf(Board[i], sender);
                    if (k > -1)
                    {
                        // draw highlighting
                        
                            List<position_t> moves = chess.Select(new position_t(k, i));
                            foreach (position_t move in moves)
                            {
                                if ((chess.Board.Grid[move.number][move.letter].player != chess.Turn
                                    && chess.Board.Grid[move.number][move.letter].piece != Piece.NONE)
                                    || LegalMoveSet.isEnPassant(chess.Board, new move_t(chess.Selection, move)))
                                {
                                    // attack
                                    Board[move.number][move.letter].BackColor = Color.Red;
                                }
                                else
                                {
                                    // move
                                    Board[move.number][move.letter].BackColor = Color.Yellow;
                                }
                            }                       
                    }
                }
            }
        }
    }
}
