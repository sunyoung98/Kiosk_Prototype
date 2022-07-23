
namespace HAI_KIOSK
{
    partial class menu_row
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.row_mname = new System.Windows.Forms.Label();
            this.row_count = new System.Windows.Forms.Label();
            this.row_price = new System.Windows.Forms.Label();
            this.del_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // row_mname
            // 
            this.row_mname.AutoSize = true;
            this.row_mname.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.row_mname.Location = new System.Drawing.Point(40, 7);
            this.row_mname.Name = "row_mname";
            this.row_mname.Size = new System.Drawing.Size(80, 28);
            this.row_mname.TabIndex = 0;
            this.row_mname.Text = "label1";
            // 
            // row_count
            // 
            this.row_count.AutoSize = true;
            this.row_count.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.row_count.Location = new System.Drawing.Point(260, 4);
            this.row_count.Name = "row_count";
            this.row_count.Size = new System.Drawing.Size(97, 34);
            this.row_count.TabIndex = 1;
            this.row_count.Text = "label2";
            // 
            // row_price
            // 
            this.row_price.AutoSize = true;
            this.row_price.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.row_price.Location = new System.Drawing.Point(400, 4);
            this.row_price.Name = "row_price";
            this.row_price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.row_price.Size = new System.Drawing.Size(97, 34);
            this.row_price.TabIndex = 2;
            this.row_price.Text = "label3";
            // 
            // del_button
            // 
            this.del_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.del_button.Font = new System.Drawing.Font("나눔스퀘어 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.del_button.Location = new System.Drawing.Point(530, 0);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(100, 42);
            this.del_button.TabIndex = 24;
            this.del_button.Text = "삭제";
            this.del_button.UseVisualStyleBackColor = true;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // menu_row
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.del_button);
            this.Controls.Add(this.row_price);
            this.Controls.Add(this.row_count);
            this.Controls.Add(this.row_mname);
            this.Name = "menu_row";
            this.Size = new System.Drawing.Size(630, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label row_mname;
        private System.Windows.Forms.Label row_count;
        private System.Windows.Forms.Label row_price;
        private System.Windows.Forms.Button del_button;
    }
}
