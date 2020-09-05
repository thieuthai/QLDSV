namespace Demo_QLDSV
{
    partial class frmReport
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
            this.btnDSSV = new DevExpress.XtraEditors.SimpleButton();
            this.btnBangDiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnPhieuDiem = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnDSSV
            // 
            this.btnDSSV.Location = new System.Drawing.Point(41, 59);
            this.btnDSSV.Name = "btnDSSV";
            this.btnDSSV.Size = new System.Drawing.Size(124, 47);
            this.btnDSSV.TabIndex = 0;
            this.btnDSSV.Text = "Danh sách sinh viên";
            this.btnDSSV.Click += new System.EventHandler(this.btnDSSV_Click);
            // 
            // btnBangDiem
            // 
            this.btnBangDiem.Location = new System.Drawing.Point(191, 59);
            this.btnBangDiem.Name = "btnBangDiem";
            this.btnBangDiem.Size = new System.Drawing.Size(124, 47);
            this.btnBangDiem.TabIndex = 1;
            this.btnBangDiem.Text = "Bảng điểm môn học";
            this.btnBangDiem.Click += new System.EventHandler(this.btnBangDiem_Click);
            // 
            // btnPhieuDiem
            // 
            this.btnPhieuDiem.Location = new System.Drawing.Point(337, 59);
            this.btnPhieuDiem.Name = "btnPhieuDiem";
            this.btnPhieuDiem.Size = new System.Drawing.Size(124, 47);
            this.btnPhieuDiem.TabIndex = 2;
            this.btnPhieuDiem.Text = "Phiếu điểm";
            this.btnPhieuDiem.Click += new System.EventHandler(this.btnPhieuDiem_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 206);
            this.Controls.Add(this.btnPhieuDiem);
            this.Controls.Add(this.btnBangDiem);
            this.Controls.Add(this.btnDSSV);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDSSV;
        private DevExpress.XtraEditors.SimpleButton btnBangDiem;
        private DevExpress.XtraEditors.SimpleButton btnPhieuDiem;
    }
}