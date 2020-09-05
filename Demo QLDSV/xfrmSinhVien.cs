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
using System.Data.SqlClient;

namespace Demo_QLDSV
{
    public partial class xfrmSinhVien : DevExpress.XtraEditors.XtraForm
    {

        private DataTable dt = new DataTable();
        public xfrmSinhVien()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("sp_LayDsLopTheoKhoa");
            cbbLop.DataSource = dt;
            cbbLop.DisplayMember = "TENLOP";
            cbbLop.ValueMember = "MALOP";
            cbbLop.SelectedIndex = 0;

            btnScreen.Enabled = true;
            btnPrint.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnScreen_Click(object sender, EventArgs e)
        {

            //  this.sp_InDanhSachSinhVienFiledTableAdapter.Fill(this.qLDSVDataSet.sp_InDanhSachSinhVienFilled, cbbLop.SelectedValue.ToString());

            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }

            
            string sqlStr = "sp_InDanhSachSinhVien";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            Program.cmd.Parameters.Clear();
            Program.cmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = cbbLop.SelectedValue.ToString();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Create a report instance.
           var report = new rpDSSV(dt, cbbLop.Text);
            report.RequestParameters = false; // Hide the Parameters UI from end-users.
            report.ShowPreviewDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}