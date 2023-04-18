namespace Chess
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAIGame = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWhiteAutoMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.new2PlayerGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.endCurrentGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyDepthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prgThinking = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitView = new System.Windows.Forms.SplitContainer();
            this.lblWhiteOrBlackChecked = new System.Windows.Forms.Label();
            this.lblBlackCheck = new System.Windows.Forms.Label();
            this.lblWhiteCheck = new System.Windows.Forms.Label();
            this.picTurn = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblWhiteTime = new System.Windows.Forms.Label();
            this.lblBlackTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrWhite = new System.Windows.Forms.Timer(this.components);
            this.tmrBlack = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).BeginInit();
            this.splitView.Panel2.SuspendLayout();
            this.splitView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.difficultyDepthToolStripMenuItem,
            this.tryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAIGame,
            this.newGameToolStripMenuItem,
            this.newWhiteAutoMenuItem1,
            this.new2PlayerGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.endCurrentGameToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Game";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // newAIGame
            // 
            this.newAIGame.Name = "newAIGame";
            this.newAIGame.Size = new System.Drawing.Size(225, 22);
            this.newAIGame.Text = "New AI vs AI game";
            this.newAIGame.Click += new System.EventHandler(this.NewGame);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newGameToolStripMenuItem.Text = "New BlackAI vs Player game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.NewGame);
            // 
            // newWhiteAutoMenuItem1
            // 
            this.newWhiteAutoMenuItem1.Name = "newWhiteAutoMenuItem1";
            this.newWhiteAutoMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.newWhiteAutoMenuItem1.Text = "New WhiteAI vs Player game";
            this.newWhiteAutoMenuItem1.Click += new System.EventHandler(this.NewGame);
            // 
            // new2PlayerGameToolStripMenuItem
            // 
            this.new2PlayerGameToolStripMenuItem.Name = "new2PlayerGameToolStripMenuItem";
            this.new2PlayerGameToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.new2PlayerGameToolStripMenuItem.Text = "New Player vs Player game";
            this.new2PlayerGameToolStripMenuItem.Click += new System.EventHandler(this.NewGame);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // endCurrentGameToolStripMenuItem
            // 
            this.endCurrentGameToolStripMenuItem.Name = "endCurrentGameToolStripMenuItem";
            this.endCurrentGameToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.endCurrentGameToolStripMenuItem.Text = "End Current Game";
            this.endCurrentGameToolStripMenuItem.Click += new System.EventHandler(this.endGame);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(222, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Shutdown);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.pauseToolStripMenuItem.Text = "pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // difficultyDepthToolStripMenuItem
            // 
            this.difficultyDepthToolStripMenuItem.Name = "difficultyDepthToolStripMenuItem";
            this.difficultyDepthToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.difficultyDepthToolStripMenuItem.Text = "Setting";
            this.difficultyDepthToolStripMenuItem.Click += new System.EventHandler(this.difficultyDepthToolStripMenuItem_Click);
            // 
            // tryToolStripMenuItem
            // 
            this.tryToolStripMenuItem.Name = "tryToolStripMenuItem";
            this.tryToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgThinking,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(634, 23);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prgThinking
            // 
            this.prgThinking.Name = "prgThinking";
            this.prgThinking.Size = new System.Drawing.Size(100, 17);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(62, 18);
            this.lblStatus.Text = "Thinking...";
            // 
            // splitView
            // 
            this.splitView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitView.IsSplitterFixed = true;
            this.splitView.Location = new System.Drawing.Point(0, 24);
            this.splitView.Name = "splitView";
            // 
            // splitView.Panel1
            // 
            this.splitView.Panel1.BackColor = System.Drawing.Color.Gray;
            this.splitView.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitView_Panel1_Paint);
            this.splitView.Panel1.Resize += new System.EventHandler(this.ResizeBoard);
            this.splitView.Panel1MinSize = 400;
            // 
            // splitView.Panel2
            // 
            this.splitView.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitView.Panel2.Controls.Add(this.lblWhiteOrBlackChecked);
            this.splitView.Panel2.Controls.Add(this.lblBlackCheck);
            this.splitView.Panel2.Controls.Add(this.lblWhiteCheck);
            this.splitView.Panel2.Controls.Add(this.picTurn);
            this.splitView.Panel2.Controls.Add(this.label3);
            this.splitView.Panel2.Controls.Add(this.txtLog);
            this.splitView.Panel2.Controls.Add(this.lblWhiteTime);
            this.splitView.Panel2.Controls.Add(this.lblBlackTime);
            this.splitView.Panel2.Controls.Add(this.label1);
            this.splitView.Panel2.Controls.Add(this.label2);
            this.splitView.Panel2MinSize = 200;
            this.splitView.Size = new System.Drawing.Size(634, 415);
            this.splitView.SplitterDistance = 414;
            this.splitView.TabIndex = 2;
            // 
            // lblWhiteOrBlackChecked
            // 
            this.lblWhiteOrBlackChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWhiteOrBlackChecked.AutoSize = true;
            this.lblWhiteOrBlackChecked.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWhiteOrBlackChecked.ForeColor = System.Drawing.Color.Red;
            this.lblWhiteOrBlackChecked.Location = new System.Drawing.Point(75, 377);
            this.lblWhiteOrBlackChecked.Name = "lblWhiteOrBlackChecked";
            this.lblWhiteOrBlackChecked.Size = new System.Drawing.Size(71, 16);
            this.lblWhiteOrBlackChecked.TabIndex = 7;
            this.lblWhiteOrBlackChecked.Text = "Checked";
            this.lblWhiteOrBlackChecked.Visible = false;
            // 
            // lblBlackCheck
            // 
            this.lblBlackCheck.AutoSize = true;
            this.lblBlackCheck.ForeColor = System.Drawing.Color.Red;
            this.lblBlackCheck.Location = new System.Drawing.Point(153, 49);
            this.lblBlackCheck.Name = "lblBlackCheck";
            this.lblBlackCheck.Size = new System.Drawing.Size(50, 13);
            this.lblBlackCheck.TabIndex = 6;
            this.lblBlackCheck.Text = "In Check";
            this.lblBlackCheck.Visible = false;
            // 
            // lblWhiteCheck
            // 
            this.lblWhiteCheck.AutoSize = true;
            this.lblWhiteCheck.ForeColor = System.Drawing.Color.Red;
            this.lblWhiteCheck.Location = new System.Drawing.Point(13, 49);
            this.lblWhiteCheck.Name = "lblWhiteCheck";
            this.lblWhiteCheck.Size = new System.Drawing.Size(50, 13);
            this.lblWhiteCheck.TabIndex = 6;
            this.lblWhiteCheck.Text = "In Check";
            this.lblWhiteCheck.Visible = false;
            // 
            // picTurn
            // 
            this.picTurn.Location = new System.Drawing.Point(89, 12);
            this.picTurn.Name = "picTurn";
            this.picTurn.Size = new System.Drawing.Size(39, 20);
            this.picTurn.TabIndex = 5;
            this.picTurn.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Logs(Moves):";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLog.Location = new System.Drawing.Point(16, 90);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(187, 268);
            this.txtLog.TabIndex = 3;
            // 
            // lblWhiteTime
            // 
            this.lblWhiteTime.AutoSize = true;
            this.lblWhiteTime.Location = new System.Drawing.Point(13, 33);
            this.lblWhiteTime.Name = "lblWhiteTime";
            this.lblWhiteTime.Size = new System.Drawing.Size(58, 13);
            this.lblWhiteTime.TabIndex = 2;
            this.lblWhiteTime.Text = "00:00:00.0";
            // 
            // lblBlackTime
            // 
            this.lblBlackTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlackTime.AutoSize = true;
            this.lblBlackTime.Location = new System.Drawing.Point(145, 33);
            this.lblBlackTime.Name = "lblBlackTime";
            this.lblBlackTime.Size = new System.Drawing.Size(58, 13);
            this.lblBlackTime.TabIndex = 2;
            this.lblBlackTime.Text = "00:00:00.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "White";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Black";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tmrWhite
            // 
            this.tmrWhite.Tick += new System.EventHandler(this.tmrWhite_Tick);
            // 
            // tmrBlack
            // 
            this.tmrBlack.Tick += new System.EventHandler(this.tmrBlack_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 462);
            this.Controls.Add(this.splitView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(650, 501);
            this.Name = "MainForm";
            this.Text = "Chess";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.windowClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitView.Panel2.ResumeLayout(false);
            this.splitView.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).EndInit();
            this.splitView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTurn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prgThinking;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.SplitContainer splitView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblWhiteTime;
        private System.Windows.Forms.Label lblBlackTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picTurn;
        private System.Windows.Forms.ToolStripMenuItem new2PlayerGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultyDepthToolStripMenuItem;
        private System.Windows.Forms.Label lblBlackCheck;
        private System.Windows.Forms.Label lblWhiteCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem endCurrentGameToolStripMenuItem;
        private System.Windows.Forms.Timer tmrWhite;
        private System.Windows.Forms.Timer tmrBlack;
        private System.Windows.Forms.ToolStripMenuItem newAIGame;
        private System.Windows.Forms.Label lblWhiteOrBlackChecked;
        private System.Windows.Forms.ToolStripMenuItem tryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWhiteAutoMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    }
}

