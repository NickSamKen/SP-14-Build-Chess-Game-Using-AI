
namespace Chess
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.Quit = new System.Windows.Forms.Button();
            this.Credits = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.ChessGame = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.Transparent;
            this.Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quit.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Quit.Location = new System.Drawing.Point(271, 268);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(255, 74);
            this.Quit.TabIndex = 7;
            this.Quit.Text = "Exit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Credits
            // 
            this.Credits.BackColor = System.Drawing.Color.Transparent;
            this.Credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Credits.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Credits.Location = new System.Drawing.Point(412, 188);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(206, 74);
            this.Credits.TabIndex = 6;
            this.Credits.Text = "Credits";
            this.Credits.UseVisualStyleBackColor = false;
            this.Credits.Click += new System.EventHandler(this.Credits_Click);
            // 
            // StartGame
            // 
            this.StartGame.BackColor = System.Drawing.Color.Transparent;
            this.StartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGame.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.StartGame.Location = new System.Drawing.Point(183, 188);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(206, 74);
            this.StartGame.TabIndex = 5;
            this.StartGame.Text = "Start";
            this.StartGame.UseVisualStyleBackColor = false;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // ChessGame
            // 
            this.ChessGame.AutoSize = true;
            this.ChessGame.BackColor = System.Drawing.Color.Transparent;
            this.ChessGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChessGame.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ChessGame.Location = new System.Drawing.Point(195, 109);
            this.ChessGame.Name = "ChessGame";
            this.ChessGame.Size = new System.Drawing.Size(423, 76);
            this.ChessGame.TabIndex = 4;
            this.ChessGame.Text = "Chess Game";
            this.ChessGame.Click += new System.EventHandler(this.ChessGame_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.ChessGame);
            this.Name = "StartScreen";
            this.Text = "StartScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button Credits;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Label ChessGame;
    }
}