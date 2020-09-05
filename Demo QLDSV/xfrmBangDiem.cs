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
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace Demo_QLDSV
{
    public partial class xfrmBangDiem : DevExpress.XtraEditors.XtraForm
    {

        private DataTable dt = new DataTable();

        public xfrmBangDiem()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("sp_LayDsLopTheoKhoa");
            cbbClass.DataSource = dt;
            cbbClass.DisplayMember = "TENLOP";
            cbbClass.ValueMember = "MALOP";
            cbbClass.SelectedIndex = 0;

            btnScreen.Enabled = true;
            btnPrint.Enabled = false;
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            resetData();

            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }


            string sqlStr = "sp_InBDMonHoc";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            Program.cmd.Parameters.Clear();
            Program.cmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = cbbClass.SelectedValue.ToString();
            Program.cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = cbbSubject.SelectedValue.ToString();
            Program.cmd.Parameters.Add("@LAN", SqlDbType.NChar).Value = tbLan.Text.ToString();
            Program.cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(Program.cmd);
            da.Fill(dt);
            Program.connect.Close();

            if (dt.Rows.Count > 0)
            {
                btnPrint.Enabled = true;

            }
            else
            {
                MessageBox.Show("Lớp không có sinh viên. Không có dữ liệu để in", "Thông báo !", MessageBoxButtons.OK);
                btnPrint.Enabled = false;
            }
        }

        private void resetData()
        {
            dt = new DataTable();
            btnScreen.Enabled = true;
            btnPrint.Enabled = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var report = new rpBangDiem(dt, cbbClass.Text, cbbSubject.Text, tbLan.Text);
            report.RequestParameters = false; // Hide the Parameters UI from end-users.
            report.ShowPreviewDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xfrmBangDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.qLDSVDataSet.MONHOC);

        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetData();
        }

        private void cbbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetData();
        }
    }
}