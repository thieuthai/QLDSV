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
using System.Diagnostics;

namespace Demo_QLDSV
{
    public partial class xfrmInPD : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public xfrmInPD()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }


            string sqlStr = "sp_InPhieuDiemCaNhan";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;
            Program.cmd.Parameters.Clear();
    
            Program.cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = txtMaSV.Text.ToString();
            Program.cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(Program.cmd);
            da.Fill(dt);
            Program.connect.Close();
            Debug.WriteLine(dt.Rows.Count);
            var report = new rpInPD( lblMaSV.Text,dt);
            report.RequestParameters = false; // Hide the Parameters UI from end-users.
            report.ShowPreviewDialog();
        }

       
    }
}