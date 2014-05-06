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
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnControls = new System.Windows.Forms.Button();
            this.btnChoosePlane = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(68, 93);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(165, 53);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play Game";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(68, 348);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(165, 53);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnControls
            // 
            this.btnControls.Location = new System.Drawing.Point(68, 263);
            this.btnControls.Name = "btnControls";
            this.btnControls.Size = new System.Drawing.Size(165, 53);
            this.btnControls.TabIndex = 2;
            this.btnControls.Text = "Controls";
            this.btnControls.UseVisualStyleBackColor = true;
            // 
            // btnChoosePlane
            // 
            this.btnChoosePlane.Location = new System.Drawing.Point(68, 178);
            this.btnChoosePlane.Name = "btnChoosePlane";
            this.btnChoosePlane.Size = new System.Drawing.Size(165, 53);
            this.btnChoosePlane.TabIndex = 3;
            this.btnChoosePlane.Text = "Choose Plane";
            this.btnChoosePlane.UseVisualStyleBackColor = true;
            this.btnChoosePlane.Click += new System.EventHandler(this.btnChoosePlane_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.btnChoosePlane);
            this.Controls.Add(this.btnControls);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnPlay);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnControls;
        private System.Windows.Forms.Button btnChoosePlane;
    }
}