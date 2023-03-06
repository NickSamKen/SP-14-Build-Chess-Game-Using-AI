namespace Chess
{
    partial class FrmAIsetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAIsetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioBtnBeginner = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numQueenValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numRookValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numBishopValue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numKnightValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numPawnValue = new System.Windows.Forms.NumericUpDown();
            this.BtnAIsetting = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQueenValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRookValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBishopValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKnightValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPawnValue)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioBtnBeginner);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Difficulty(Depth)";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(22, 210);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(101, 16);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.Text = "Very Hard (5)";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(22, 166);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(101, 16);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "Hard      (4)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(22, 122);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(101, 16);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Medium    (3)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 78);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(101, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Easy      (2)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioBtnBeginner
            // 
            this.radioBtnBeginner.AutoSize = true;
            this.radioBtnBeginner.Location = new System.Drawing.Point(22, 34);
            this.radioBtnBeginner.Name = "radioBtnBeginner";
            this.radioBtnBeginner.Size = new System.Drawing.Size(101, 16);
            this.radioBtnBeginner.TabIndex = 0;
            this.radioBtnBeginner.Text = "Beginner  (1)";
            this.radioBtnBeginner.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numQueenValue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numRookValue);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numBishopValue);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numKnightValue);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numPawnValue);
            this.groupBox2.Location = new System.Drawing.Point(199, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 325);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Piece Value";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(46, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 40);
            this.label6.TabIndex = 8;
            this.label6.Text = "Range：1—999；                             They will affect the evaluation";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Queen:";
            // 
            // numQueenValue
            // 
            this.numQueenValue.Location = new System.Drawing.Point(144, 227);
            this.numQueenValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numQueenValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQueenValue.Name = "numQueenValue";
            this.numQueenValue.Size = new System.Drawing.Size(120, 21);
            this.numQueenValue.TabIndex = 6;
            this.numQueenValue.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rook:";
            // 
            // numRookValue
            // 
            this.numRookValue.Location = new System.Drawing.Point(144, 182);
            this.numRookValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRookValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRookValue.Name = "numRookValue";
            this.numRookValue.Size = new System.Drawing.Size(120, 21);
            this.numRookValue.TabIndex = 6;
            this.numRookValue.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bishop:";
            // 
            // numBishopValue
            // 
            this.numBishopValue.Location = new System.Drawing.Point(144, 133);
            this.numBishopValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBishopValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBishopValue.Name = "numBishopValue";
            this.numBishopValue.Size = new System.Drawing.Size(120, 21);
            this.numBishopValue.TabIndex = 4;
            this.numBishopValue.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Knight:";
            // 
            // numKnightValue
            // 
            this.numKnightValue.Location = new System.Drawing.Point(144, 80);
            this.numKnightValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numKnightValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKnightValue.Name = "numKnightValue";
            this.numKnightValue.Size = new System.Drawing.Size(120, 21);
            this.numKnightValue.TabIndex = 2;
            this.numKnightValue.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pawn:";
            // 
            // numPawnValue
            // 
            this.numPawnValue.Location = new System.Drawing.Point(144, 34);
            this.numPawnValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPawnValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPawnValue.Name = "numPawnValue";
            this.numPawnValue.Size = new System.Drawing.Size(120, 21);
            this.numPawnValue.TabIndex = 0;
            this.numPawnValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // BtnAIsetting
            // 
            this.BtnAIsetting.Location = new System.Drawing.Point(343, 359);
            this.BtnAIsetting.Name = "BtnAIsetting";
            this.BtnAIsetting.Size = new System.Drawing.Size(138, 23);
            this.BtnAIsetting.TabIndex = 6;
            this.BtnAIsetting.Text = "Save";
            this.BtnAIsetting.UseVisualStyleBackColor = true;
            this.BtnAIsetting.Click += new System.EventHandler(this.BtnAIsetting_Click);
            // 
            // FrmAIsetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 403);
            this.ControlBox = false;
            this.Controls.Add(this.BtnAIsetting);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAIsetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI Setting";
            this.Load += new System.EventHandler(this.FrmAIsetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQueenValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRookValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBishopValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKnightValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPawnValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioBtnBeginner;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPawnValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numKnightValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numQueenValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numRookValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBishopValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnAIsetting;
    }
}