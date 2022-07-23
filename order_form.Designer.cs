
namespace HAI_KIOSK
{
    partial class order_form
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
            this.panel_order = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_order
            // 
            this.panel_order.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_order.Location = new System.Drawing.Point(0, 0);
            this.panel_order.Name = "panel_order";
            this.panel_order.Size = new System.Drawing.Size(614, 325);
            this.panel_order.TabIndex = 0;
            // 
            // order_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 1081);
            this.Controls.Add(this.panel_order);
            this.Name = "order_form";
            this.Text = "order_form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_order;
    }
}