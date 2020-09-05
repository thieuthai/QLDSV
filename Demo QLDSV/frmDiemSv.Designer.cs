namespace Demo_QLDSV
{
    partial class frmDiemSv
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
            this.qLDSVDataSet = new Demo_QLDSV.QLDSVDataSet();
            this.bdsDiem = new System.Windows.Forms.BindingSource(this.components);
            this.dIEMTableAdapter = new Demo_QLDSV.QLDSVDataSetTableAdapters.DIEMTableAdapter();
            this.tableAdapterManager = new Demo_QLDSV.QLDSVDataSetTableAdapters.TableAdapterManager();
            this.sINHVIENTableAdapter = new Demo_QLDSV.QLDSVDataSetTableAdapters.SINHVIENTableAdapter();
            this.sINHVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbSubject = new System.Windows.Forms.ComboBox();
            this.mONHOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbbClass = new System.Windows.Forms.ComboBox();
            this.spLayDsLopTheoKhoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sp_LayDiemSinhVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_LayDiemSinhVienTableAdapter = new Demo_QLDSV.QLDSVDataSetTableAdapters.sp_LayDiemSinhVienTableAdapter();
            this.btnSave = new System.Windows.Forms.Button();
            this.lOPTableAdapter = new Demo_QLDSV.QLDSVDataSetTableAdapters.LOPTableAdapter();
            this.mONHOCTableAdapter = new Demo_QLDSV.QLDSVDataSetTableAdapters.MONHOCTableAdapter();
            this.tbLan = new System.Windows.Forms.TextBox();
            this.fKSINHVIENLOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fKSINHVIENLOPBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.spkiemtrasinhvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_kiemtrasinhvienTableAdapter = new Demo_QLDSV.QLDSVDataSetTableAdapters.sp_kiemtrasinhvienTableAdapter();
            this.sp_LayDsLopTheoKhoaTableAdapter = new Demo_QLDSV.QLDSVDataSetTableAdapters.sp_LayDsLopTheoKhoaTableAdapter();
            this.spLayDsLopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spLayDsLopTheoKhoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_LayDiemSinhVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSINHVIENLOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSINHVIENLOPBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkiemtrasinhvienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spLayDsLopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // qLDSVDataSet
            // 
            this.qLDSVDataSet.DataSetName = "QLDSVDataSet";
            this.qLDSVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsDiem
            // 
            this.bdsDiem.DataMember = "DIEM";
            this.bdsDiem.DataSource = this.qLDSVDataSet;
            // 
            // dIEMTableAdapter
            // 
            this.dIEMTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DIEMTableAdapter = this.dIEMTableAdapter;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.HOCPHITableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = this.sINHVIENTableAdapter;
            this.tableAdapterManager.UpdateOrder = Demo_QLDSV.QLDSVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sINHVIENTableAdapter
            // 
            this.sINHVIENTableAdapter.ClearBeforeFill = true;
            // 
            // sINHVIENBindingSource
            // 
            this.sINHVIENBindingSource.DataMember = "SINHVIEN";
            this.sINHVIENBindingSource.DataSource = this.qLDSVDataSet;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(694, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Xác nhận";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Môn học";
            // 
            // cbbSubject
            // 
            this.cbbSubject.DataSource = this.mONHOCBindingSource;
            this.cbbSubject.DisplayMember = "TENMH";
            this.cbbSubject.FormattingEnabled = true;
            this.cbbSubject.Location = new System.Drawing.Point(352, 83);
            this.cbbSubject.Name = "cbbSubject";
            this.cbbSubject.Size = new System.Drawing.Size(208, 21);
            this.cbbSubject.TabIndex = 7;
            this.cbbSubject.ValueMember = "MAMH";
            // 
            // mONHOCBindingSource
            // 
            this.mONHOCBindingSource.DataMember = "MONHOC";
            this.mONHOCBindingSource.DataSource = this.qLDSVDataSet;
            // 
            // cbbClass
            // 
            this.cbbClass.FormattingEnabled = true;
            this.cbbClass.Location = new System.Drawing.Point(43, 82);
            this.cbbClass.Name = "cbbClass";
            this.cbbClass.Size = new System.Drawing.Size(238, 21);
            this.cbbClass.TabIndex = 8;
            // 
            // spLayDsLopTheoKhoaBindingSource
            // 
            this.spLayDsLopTheoKhoaBindingSource.DataMember = "sp_LayDsLopTheoKhoa";
            this.spLayDsLopTheoKhoaBindingSource.DataSource = this.qLDSVDataSet;
            // 
            // lOPBindingSource
            // 
            this.lOPBindingSource.DataMember = "LOP";
            this.lOPBindingSource.DataSource = this.qLDSVDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lớp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lần thi";
            // 
            // colLAN
            // 
            this.colLAN.FieldName = "LAN";
            this.colLAN.Name = "colLAN";
            // 
            // sp_LayDiemSinhVienBindingSource
            // 
            this.sp_LayDiemSinhVienBindingSource.DataMember = "sp_LayDiemSinhVien";
            this.sp_LayDiemSinhVienBindingSource.DataSource = this.qLDSVDataSet;
            // 
            // sp_LayDiemSinhVienTableAdapter
            // 
            this.sp_LayDiemSinhVienTableAdapter.ClearBeforeFill = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(674, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // mONHOCTableAdapter
            // 
            this.mONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // tbLan
            // 
            this.tbLan.Location = new System.Drawing.Point(621, 84);
            this.tbLan.Name = "tbLan";
            this.tbLan.Size = new System.Drawing.Size(41, 20);
            this.tbLan.TabIndex = 13;
            this.tbLan.Validating += new System.ComponentModel.CancelEventHandler(this.tbLan_Validating);
            // 
            // fKSINHVIENLOPBindingSource
            // 
            this.fKSINHVIENLOPBindingSource.DataMember = "FK_SINHVIEN_LOP";
            this.fKSINHVIENLOPBindingSource.DataSource = this.lOPBindingSource;
            // 
            // fKSINHVIENLOPBindingSource1
            // 
            this.fKSINHVIENLOPBindingSource1.DataMember = "FK_SINHVIEN_LOP";
            this.fKSINHVIENLOPBindingSource1.DataSource = this.lOPBindingSource;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(800, 25);
            this.fillByToolStrip.TabIndex = 0;
            // 
            // spkiemtrasinhvienBindingSource
            // 
            this.spkiemtrasinhvienBindingSource.DataMember = "sp_kiemtrasinhvien";
            this.spkiemtrasinhvienBindingSource.DataSource = this.qLDSVDataSet;
            // 
            // sp_kiemtrasinhvienTableAdapter
            // 
            this.sp_kiemtrasinhvienTableAdapter.ClearBeforeFill = true;
            // 
            // sp_LayDsLopTheoKhoaTableAdapter
            // 
            this.sp_LayDsLopTheoKhoaTableAdapter.ClearBeforeFill = true;
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Location = new System.Drawing.Point(12, 112);
            this.gridView.Name = "gridView";
            this.gridView.Size = new System.Drawing.Size(776, 253);
            this.gridView.TabIndex = 14;
            // 
            // frmDiemSv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.tbLan);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbClass);
            this.Controls.Add(this.cbbSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmDiemSv";
            this.Text = "frmDiemSv";
            this.Load += new System.EventHandler(this.frmDiemSv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spLayDsLopTheoKhoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_LayDiemSinhVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSINHVIENLOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSINHVIENLOPBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkiemtrasinhvienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spLayDsLopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private QLDSVDataSet qLDSVDataSet;
        private System.Windows.Forms.BindingSource bdsDiem;
        private QLDSVDataSetTableAdapters.DIEMTableAdapter dIEMTableAdapter;
        private QLDSVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnSearch;
        private QLDSVDataSetTableAdapters.SINHVIENTableAdapter sINHVIENTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbSubject;
        private System.Windows.Forms.ComboBox cbbClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn colLAN;
        private System.Windows.Forms.BindingSource sINHVIENBindingSource;
        private System.Windows.Forms.BindingSource sp_LayDiemSinhVienBindingSource;
        private QLDSVDataSetTableAdapters.sp_LayDiemSinhVienTableAdapter sp_LayDiemSinhVienTableAdapter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private QLDSVDataSetTableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.BindingSource mONHOCBindingSource;
        private QLDSVDataSetTableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
        private System.Windows.Forms.TextBox tbLan;
        private System.Windows.Forms.BindingSource fKSINHVIENLOPBindingSource;
        private System.Windows.Forms.BindingSource fKSINHVIENLOPBindingSource1;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.BindingSource spLayDsLopTheoKhoaBindingSource;
        private System.Windows.Forms.BindingSource spkiemtrasinhvienBindingSource;
        private QLDSVDataSetTableAdapters.sp_kiemtrasinhvienTableAdapter sp_kiemtrasinhvienTableAdapter;
        private QLDSVDataSetTableAdapters.sp_LayDsLopTheoKhoaTableAdapter sp_LayDsLopTheoKhoaTableAdapter;
        private System.Windows.Forms.BindingSource spLayDsLopBindingSource;
        private System.Windows.Forms.DataGridView gridView;
    }
}