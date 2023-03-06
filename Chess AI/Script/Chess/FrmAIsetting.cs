using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    /// <summary>
    /// AI setting UI:WinForm
    /// </summary>
    public partial class FrmAIsetting : Form
    {
        /// <summary>
        /// AI setting UI
        /// </summary>
        public FrmAIsetting()
        {
            InitializeComponent();
                      
        }

        private void BtnAIsetting_Click(object sender, EventArgs e)
        {            
            AI.DEPTH = SetDepth();
            AI.piecePawnValue = (int)numPawnValue.Value;
            AI.pieceKnightValue = (int)numKnightValue.Value;
            AI.pieceBishopValue = (int)numBishopValue.Value;
            AI.pieceRookValue = (int)numRookValue.Value;
            AI.pieceQueenValue = (int)numQueenValue.Value;
            MessageBox.Show("Success!");
            this.Visible =false ;
        }
        private int SetDepth()
        {
            int depth = 3;
            if (radioBtnBeginner.Checked) depth = 1;
            if (radioButton1.Checked) depth = 2;
            if (radioButton2.Checked) depth = 3;
            if (radioButton3.Checked) depth = 4;
            if (radioButton4.Checked) depth = 5;
            return depth; ;
        }
        private void getDept()
        {
            switch (AI.DEPTH)
            {
                case 1:
                    radioBtnBeginner.Checked = true;
                    break;
                case 2:
                    radioButton1.Checked = true;
                    break;
                case 3:
                    radioButton2.Checked = true;
                    break;
                case 4:
                    radioButton3.Checked = true;
                    break;
                case 5:
                    radioButton4.Checked = true;
                    break;
            }

        }
        private void getPieceValue()
        {
            numPawnValue.Value=AI.piecePawnValue;
            numKnightValue.Value= AI.pieceKnightValue;
            numBishopValue.Value= AI.pieceBishopValue ;
            numRookValue.Value= AI.pieceRookValue;
            numQueenValue.Value= AI.pieceQueenValue;
        }

        private void FrmAIsetting_Load(object sender, EventArgs e)
        {
            getDept();
            getPieceValue();
            if (AI.RUNNING)
            {
                MessageBox.Show("AI is running. Please set them before you create a new game!");
                BtnAIsetting.Enabled = false;
            }
        }
    }
}
