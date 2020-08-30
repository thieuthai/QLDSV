using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            
            // TODO: This line of code loads data into the 'qLDSVDataSet.LOP' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'qLDSVDataSet.SINHVIEN' table. You can move, or remove it, as needed.

           
            // TODO: This line of code loads data into the 'qLDSVDataSet.DIEM' table. You can move, or remove it, as needed.
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }
            string sqlStr = "sp_LayDsSinhVienTheoLop";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            foreach (ScoreItem score in listScore)
            {
                Program.cmd.Parameters.Clear();
                Program.cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = score.studentId;
                Program.cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = score.subjectId;
                Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = score.time;
                Program.cmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = score.score == 0 ? (object)DBNull.Value : score.score;
                Program.cmd.ExecuteNonQuery();
            }

            Program.connect.Close();
        }

        
        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.lOPTableAdapter.FillBy(this.qLDSVDataSet.LOP);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
