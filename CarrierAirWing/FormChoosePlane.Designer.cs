namespace CarrierAirWing
{
    partial class FormChoosePlane
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
            this.btnThunderbolt = new System.Windows.Forms.Button();
            this.btnTomcat = new System.Windows.Forms.Button();
            this.btnTigerShark = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnThunderbolt
            // 
            this.btnThunderbolt.Location = new System.Drawing.Point(12, 12);
            this.btnThunderbolt.Name = "btnThunderbolt";
            this.btnThunderbolt.Size = new System.Drawing.Size(148, 23);
            this.btnThunderbolt.TabIndex = 4;
            this.btnThunderbolt.Text = "A10 Thunderbolt";
            this.btnThunderbolt.UseVisualStyleBackColor = true;
            this.btnThunderbolt.Click += new System.EventHandler(this.btnThunderbolt_Click);
            // 
            // btnTomcat
            // 
            this.btnTomcat.Location = new System.Drawing.Point(12, 41);
            this.btnTomcat.Name = "btnTomcat";
            this.btnTomcat.Size = new System.Drawing.Size(148, 23);
            this.btnTomcat.TabIndex = 5;
            this.btnTomcat.Text = "F14 Tomcat";
            this.btnTomcat.UseVisualStyleBackColor = true;
            this.btnTomcat.Click += new System.EventHandler(this.btnTomcat_Click);
            // 
            // btnTigerShark
            // 
            this.btnTigerShark.Location = new System.Drawing.Point(12, 70);
            this.btnTigerShark.Name = "btnTigerShark";
            this.btnTigerShark.Size = new System.Drawing.Size(148, 23);
            this.btnTigerShark.TabIndex = 6;
            this.btnTigerShark.Text = "F20 TigerShark";
            this.btnTigerShark.UseVisualStyleBackColor = true;
            this.btnTigerShark.Click += new System.EventHandler(this.btnTigerShark_Click);
            // 
            // FormChoosePlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 114);
            this.Controls.Add(this.btnTigerShark);
            this.Controls.Add(this.btnTomcat);
            this.Controls.Add(this.btnThunderbolt);
            this.Name = "FormChoosePlane";
            this.Text = "FormChoosePlane";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThunderbolt;
        private System.Windows.Forms.Button btnTomcat;
        private System.Windows.Forms.Button btnTigerShark;
    }
}