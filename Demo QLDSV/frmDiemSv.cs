using DevExpress.XtraRichEdit.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo_QLDSV
{
    public partial class frmDiemSv : Form
    {
        public class ScoreItem
        {
            public string studentId;
            public string name;
            public string subjectId;
            public short time;
            public double score;
            public string title;

            public ScoreItem(string title, string studentId, string name, string subjectId, short time, double score)
            {
                this.studentId = studentId;
                this.name = name;
                this.subjectId = subjectId;
                this.time = time;
                this.score = score;
                this.title = title;
            }
        }
        public List<ScoreItem> listScore;

        public frmDiemSv()
        {

            InitializeComponent();
             listScore = new List<ScoreItem>();
        }

        private void dIEMBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDiem.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLDSVDataSet);

        }

        private void frmDiemSv_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'qLDSVDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.qLDSVDataSet.MONHOC);

            
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("sp_LayDsLopTheoKhoa");
            cbbClass.DataSource = dt;
            cbbClass.DisplayMember = "TENLOP";
            cbbClass.ValueMember = "MALOP";
            cbbClass.SelectedIndex = 0;
            //     cbbClass.SelectedIndex = Program.MKhoa;


        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }

            DataTable dt = new DataTable();
            string sqlStr = "sp_LayDsSinhVienTheoLop";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            Program.cmd.Parameters.Clear();
            Program.cmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = cbbClass.SelectedValue;
            // Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = score.time;
            //Program.cmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = score.score == 0 ? (object)DBNull.Value : score.score;
            Program.cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(Program.cmd);
            da.Fill(dt);
            dt.Columns.Add("DIEM");
            dt.Columns[0].ReadOnly = true;
            dt.Columns[1].ReadOnly = true;

            gridView.DataSource = dt;
            Program.connect.Close();


        }

        
        private void btnSave_Click_1(object sender, EventArgs e)
        {

           
            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }

            string sqlStr = "UpdateScoreByStudent";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

           
            // Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = score.time;
            // Program.cmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = score.score == 0 ? (object)DBNull.Value : score.score;


            foreach (DataGridViewRow row in gridView.Rows)
            {

                Program.cmd.Parameters.Clear();
                Program.cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = row.Cells[0].Value;
                Program.cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = cbbSubject.SelectedValue;
                Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = tbLan.Text;
                Program.cmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = row.Cells[2].Value;

                Program.cmd.ExecuteNonQuery();

            }


            Program.connect.Close();
        }

   
    }
}
