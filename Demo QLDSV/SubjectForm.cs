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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace Demo_QLDSV
{
    public partial class SubjectForm : DevExpress.XtraEditors.XtraForm
    {

        private DataTable dt = new DataTable();
        public SubjectForm()
        {
            InitializeComponent();
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet.MONHOC' table. You can move, or remove it, as needed.
            dt = this.qLDSVDataSet.MONHOC.Copy();
            this.mONHOCTableAdapter.Fill(dt as QLDSVDataSet.MONHOCDataTable);
            
        }

       
        private void subjectGridControl_Click(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (tbTenMH == null || tbMaMH == null || tbTenMH.TextLength == 0 || tbMaMH.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                //this.qLDSVDataSet.

            }
        }
    }

    public class SubjectAction
    {
        public enum SubjectActionType
        {
            ADD,
            DELETE,
            UPDATE
        }

        private SubjectActionType type;
        private String mamh;
        private String tenmh;

        public SubjectAction(SubjectActionType actionType, String mamh, String tenmh = null)
        {
            this.type = actionType;
            this.mamh = mamh;
            this.tenmh = tenmh;
        }
    }
    
    
}