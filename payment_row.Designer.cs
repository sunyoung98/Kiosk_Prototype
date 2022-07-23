
namespace HAI_KIOSK
{
    partial class payment_row
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
            this.row_pname = new System.Windows.Forms.Label();
            this.row_count = new System.Windows.Forms.Label();
            this.row_price = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // row_pname
            // 
            this.row_pname.AutoSize = true;
            this.row_pname.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.row_pname.Location = new System.Drawing.Point(3, 11);
            this.row_pname.Name = "row_pname";
            this.row_pname.Size = new System.Drawing.Size(64, 21);
            this.row_pname.TabIndex = 3;
            this.row_pname.Text = "label1";
            // 
            // row_count
            // 
            this.row_count.AutoSize = true;
            this.row_count.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.row_count.Location = new System.Drawing.Point(169, 11);
            this.row_count.Name = "row_count";
            this.row_count.Size = new System.Drawing.Size(68, 24);
            this.row_count.TabIndex = 4;
            this.row_count.Text = "label1";
            // 
            // row_price
            // 
            this.row_price.AutoSize = true;
            this.row_price.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.row_price.Location = new System.Drawing.Point(244, 12);
            this.row_price.Name = "row_price";
            this.row_price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.row_price.Size = new System.Drawing.Size(23, 24);
            this.row_price.TabIndex = 5;
            this.row_price.Text = "0";
            this.row_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // payment_row
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.row_price);
            this.Controls.Add(this.row_count);
            this.Controls.Add(this.row_pname);
            this.Name = "payment_row";
            this.Size = new System.Drawing.Size(315, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label row_pname;
        private System.Windows.Forms.Label row_count;
        private System.Windows.Forms.Label row_price;
    }
}
