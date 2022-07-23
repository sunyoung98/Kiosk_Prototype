
namespace HAI_KIOSK
{
    partial class NoiseMonitor
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
            this.tnoise_lbl = new System.Windows.Forms.Label();
            this.noise_lbl = new System.Windows.Forms.Label();
            this.Slevel_lbl = new System.Windows.Forms.Label();
            this.tSlevel_lbl = new System.Windows.Forms.Label();
            this.nm_start_btn = new System.Windows.Forms.Button();
            this.scn_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tnoise_lbl
            // 
            this.tnoise_lbl.AutoSize = true;
            this.tnoise_lbl.Location = new System.Drawing.Point(20, 23);
            this.tnoise_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tnoise_lbl.Name = "tnoise_lbl";
            this.tnoise_lbl.Size = new System.Drawing.Size(69, 12);
            this.tnoise_lbl.TabIndex = 0;
            this.tnoise_lbl.Text = "Noise(dba)";
            this.tnoise_lbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // noise_lbl
            // 
            this.noise_lbl.AutoSize = true;
            this.noise_lbl.Location = new System.Drawing.Point(101, 23);
            this.noise_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noise_lbl.Name = "noise_lbl";
            this.noise_lbl.Size = new System.Drawing.Size(38, 12);
            this.noise_lbl.TabIndex = 1;
            this.noise_lbl.Text = "label2";
            // 
            // Slevel_lbl
            // 
            this.Slevel_lbl.AutoSize = true;
            this.Slevel_lbl.Location = new System.Drawing.Point(215, 23);
            this.Slevel_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Slevel_lbl.Name = "Slevel_lbl";
            this.Slevel_lbl.Size = new System.Drawing.Size(38, 12);
            this.Slevel_lbl.TabIndex = 3;
            this.Slevel_lbl.Text = "label3";
            // 
            // tSlevel_lbl
            // 
            this.tSlevel_lbl.AutoSize = true;
            this.tSlevel_lbl.Location = new System.Drawing.Point(159, 23);
            this.tSlevel_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tSlevel_lbl.Name = "tSlevel_lbl";
            this.tSlevel_lbl.Size = new System.Drawing.Size(39, 12);
            this.tSlevel_lbl.TabIndex = 2;
            this.tSlevel_lbl.Text = "Slevel";
            // 
            // nm_start_btn
            // 
            this.nm_start_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.nm_start_btn.Location = new System.Drawing.Point(22, 88);
            this.nm_start_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nm_start_btn.Name = "nm_start_btn";
            this.nm_start_btn.Size = new System.Drawing.Size(117, 31);
            this.nm_start_btn.TabIndex = 4;
            this.nm_start_btn.Text = "start";
            this.nm_start_btn.UseVisualStyleBackColor = false;
            this.nm_start_btn.Click += new System.EventHandler(this.nm_start_btn_Click);
            // 
            // scn_Button
            // 
            this.scn_Button.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.scn_Button.Location = new System.Drawing.Point(333, 96);
            this.scn_Button.Name = "scn_Button";
            this.scn_Button.Size = new System.Drawing.Size(75, 23);
            this.scn_Button.TabIndex = 5;
            this.scn_Button.Text = "Output Off";
            this.scn_Button.UseVisualStyleBackColor = false;
            this.scn_Button.Click += new System.EventHandler(this.scn_Button_Click);
            // 
            // NoiseMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 145);
            this.Controls.Add(this.scn_Button);
            this.Controls.Add(this.nm_start_btn);
            this.Controls.Add(this.Slevel_lbl);
            this.Controls.Add(this.tSlevel_lbl);
            this.Controls.Add(this.noise_lbl);
            this.Controls.Add(this.tnoise_lbl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NoiseMonitor";
            this.Text = "NoiseMonitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NoiseMonitor_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tnoise_lbl;
        private System.Windows.Forms.Label noise_lbl;
        private System.Windows.Forms.Label Slevel_lbl;
        private System.Windows.Forms.Label tSlevel_lbl;
        private System.Windows.Forms.Button nm_start_btn;
        private System.Windows.Forms.Button scn_Button;
    }
}