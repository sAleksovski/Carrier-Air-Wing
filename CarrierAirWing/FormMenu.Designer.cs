namespace CarrierAirWing
{
    partial class FormMenu
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHighScore = new System.Windows.Forms.Button();
            this.btnChoosePlane = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnPlay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPlay.Location = new System.Drawing.Point(123, 394);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(165, 53);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play Game";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHighScore
            // 
            this.btnHighScore.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnHighScore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHighScore.Location = new System.Drawing.Point(505, 394);
            this.btnHighScore.Name = "btnHighScore";
            this.btnHighScore.Size = new System.Drawing.Size(165, 53);
            this.btnHighScore.TabIndex = 2;
            this.btnHighScore.Text = "High Score";
            this.btnHighScore.UseVisualStyleBackColor = false;
            this.btnHighScore.Click += new System.EventHandler(this.btnHighScore_Click);
            // 
            // btnChoosePlane
            // 
            this.btnChoosePlane.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnChoosePlane.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChoosePlane.Location = new System.Drawing.Point(318, 394);
            this.btnChoosePlane.Name = "btnChoosePlane";
            this.btnChoosePlane.Size = new System.Drawing.Size(165, 53);
            this.btnChoosePlane.TabIndex = 1;
            this.btnChoosePlane.Text = "Choose Plane";
            this.btnChoosePlane.UseVisualStyleBackColor = false;
            this.btnChoosePlane.Click += new System.EventHandler(this.btnChoosePlane_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarrierAirWing.Properties.Resources.MainMenu;
            this.pictureBox1.Location = new System.Drawing.Point(284, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnChoosePlane);
            this.Controls.Add(this.btnHighScore);
            this.Controls.Add(this.btnPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenu_FormClosing);
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnHighScore;
        private System.Windows.Forms.Button btnChoosePlane;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}