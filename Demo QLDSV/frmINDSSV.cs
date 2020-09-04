using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace QLDSV_PT.Report
{
    public partial class frmINDSSV : DevExpress.XtraEditors.XtraForm
    {
        public frmINDSSV()
        {
            InitializeComponent();
        }

        private void btnMayIn_Click(object sender, EventArgs e)
        {
            string mlop = cmbLop.SelectedValue.ToString();
            INDSSV rpt = new INDSSV(mlop);
            rpt.xrLabel3.Text = cmbLop.Text.Trim();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmINDSSV_Load(object sender, EventArgs e)
        {
            cmbKhoa.DataSource = Program.Bds_Dskhoa;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            if (Program.MGroup == "KHOA")
            {
                cmbKhoa.Enabled = false;
            }
            else
            {
                cmbKhoa.Enabled = true;
            }
            dS.EnforceConstraints = false;
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            this.sP_REPORT_DSSVTableAdapter.Connection.ConnectionString = Program.connstr;
            btnMayIn.Enabled = false;
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
        }

       

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Program.ServerName = cmbKhoa.SelectedValue.ToString();
            }
            if (cmbKhoa.SelectedIndex != Program.MKhoa)
            {
                Program.MLogin = Program.RemoteLogin;
                Program.MPassword = Program.RemotePassword;
            }
            else
            {
                Program.MLogin = Program.MLoginDN;
                Program.MPassword = Program.PasswordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi chuyển khoa", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            else
            {
                dS.EnforceConstraints = false;
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.dS.LOP);
                this.sP_REPORT_DSSVTableAdapter.Connection.ConnectionString = Program.connstr;
            }
        }

        private void btnManHinh_Click(object sender, EventArgs e)
        {
            this.sP_REPORT_DSSVTableAdapter.Fill(dS.SP_REPORT_DSSV, cmbLop.SelectedValue.ToString());
            if (bdsReportDSSV.Count == 0)
            {
                MessageBox.Show("Lớp không có sinh viên. Không có dữ liệu để in", "Thông báo !", MessageBoxButtons.OK);
                btnMayIn.Enabled = false;
            }
            else
            {
                btnMayIn.Enabled = true;
            }
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label2.Text = "Mã Lớp : " + cmbLop.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}