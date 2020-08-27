namespace Demo_QLDSV
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            this.cbbTenKhoa = new System.Windows.Forms.ComboBox();
            this.bdsKhoa = new System.Windows.Forms.BindingSource(this.components);
            this.qLDSV_VIEWKHOA = new Demo_QLDSV.QLDSV_VIEWKHOA();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.v_DS_PHANMANHTableAdapter = new Demo_QLDSV.QLDSV_VIEWKHOATableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager = new Demo_QLDSV.QLDSV_VIEWKHOATableAdapters.TableAdapterManager();
            this.btnLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_VIEWKHOA)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbTenKhoa
            // 
            this.cbbTenKhoa.DataSource = this.bdsKhoa;
            this.cbbTenKhoa.DisplayMember = "TENKHOA";
            this.cbbTenKhoa.FormattingEnabled = true;
            this.cbbTenKhoa.Location = new System.Drawing.Point(97, 49);
            this.cbbTenKhoa.Name = "cbbTenKhoa";
            this.cbbTenKhoa.Size = new System.Drawing.Size(261, 21);
            this.cbbTenKhoa.TabIndex = 0;
            this.cbbTenKhoa.ValueMember = "TENSERVER";
            // 
            // bdsKhoa
            // 
            this.bdsKhoa.DataMember = "V_DS_PHANMANH";
            this.bdsKhoa.DataSource = this.qLDSV_VIEWKHOA;
            // 
            // qLDSV_VIEWKHOA
            // 
            this.qLDSV_VIEWKHOA.DataSetName = "QLDSV_VIEWKHOA";
            this.qLDSV_VIEWKHOA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(97, 99);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(261, 20);
            this.txtUser.TabIndex = 1;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(97, 140);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(261, 20);
            this.txtPass.TabIndex = 2;
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = Demo_QLDSV.QLDSV_VIEWKHOATableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(429, 78);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(191, 61);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thoat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.cbbTenKhoa);
            this.Name = "frmLogin";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdsKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_VIEWKHOA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbTenKhoa;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private QLDSV_VIEWKHOA qLDSV_VIEWKHOA;
        private System.Windows.Forms.BindingSource bdsKhoa;
        private QLDSV_VIEWKHOATableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private QLDSV_VIEWKHOATableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button1;
    }
}