
namespace Chess
{
    partial class Credits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credits));
            this.label1 = new System.Windows.Forms.Label();
            this.Return = new System.Windows.Forms.Button();
            this.AaranDailey = new System.Windows.Forms.Button();
            this.HaigeZhu = new System.Windows.Forms.Button();
            this.NicholasKennel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.label1.Location = new System.Drawing.Point(31, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Return
            // 
            this.Return.BackColor = System.Drawing.Color.Transparent;
            this.Return.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return.Location = new System.Drawing.Point(242, 370);
            this.Return.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(292, 69);
            this.Return.TabIndex = 1;
            this.Return.Text = "Return to Start";
            this.Return.UseVisualStyleBackColor = false;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // AaranDailey
            // 
            this.AaranDailey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AaranDailey.Location = new System.Drawing.Point(12, 68);
            this.AaranDailey.Name = "AaranDailey";
            this.AaranDailey.Size = new System.Drawing.Size(155, 37);
            this.AaranDailey.TabIndex = 2;
            this.AaranDailey.Text = "Aaran Dailey";
            this.AaranDailey.UseVisualStyleBackColor = true;
            this.AaranDailey.Click += new System.EventHandler(this.AaranDailey_Click);
            // 
            // HaigeZhu
            // 
            this.HaigeZhu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HaigeZhu.Location = new System.Drawing.Point(12, 272);
            this.HaigeZhu.Name = "HaigeZhu";
            this.HaigeZhu.Size = new System.Drawing.Size(173, 37);
            this.HaigeZhu.TabIndex = 3;
            this.HaigeZhu.Text = "Haige (Evan) Zhu";
            this.HaigeZhu.UseVisualStyleBackColor = true;
            this.HaigeZhu.Click += new System.EventHandler(this.HaigeZhu_Click);
            // 
            // NicholasKennel
            // 
            this.NicholasKennel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NicholasKennel.Location = new System.Drawing.Point(12, 186);
            this.NicholasKennel.Name = "NicholasKennel";
            this.NicholasKennel.Size = new System.Drawing.Size(173, 37);
            this.NicholasKennel.TabIndex = 4;
            this.NicholasKennel.Text = "Nicholas Kennel";
            this.NicholasKennel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NicholasKennel.UseVisualStyleBackColor = true;
            this.NicholasKennel.Click += new System.EventHandler(this.NicholasKennel_Click);
            // 
            // Credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.NicholasKennel);
            this.Controls.Add(this.HaigeZhu);
            this.Controls.Add(this.AaranDailey);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Credits";
            this.Text = "Credits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.Button AaranDailey;
        private System.Windows.Forms.Button HaigeZhu;
        private System.Windows.Forms.Button NicholasKennel;
    }
}