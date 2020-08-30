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
using DevExpress.CodeParser.Diagnostics;
using System.Diagnostics;
using DevExpress.Charts.Native;
using DevExpress.Utils;

namespace Demo_QLDSV
{
    public partial class SubjectForm : DevExpress.XtraEditors.XtraForm
    {

        private List<SubjectAction> actions = new List<SubjectAction>();
        public SubjectForm()
        {
            InitializeComponent();

        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet.MONHOC' table. You can move, or remove it, as needed.
            Debug.WriteLine("SubjectForm_Load");
            this.qLDSVDataSet.Reset();
            this.mONHOCTableAdapter.Fill(this.qLDSVDataSet.MONHOC);
            // TODO: This line of code loads data into the 'qLDSVDataSet.MONHOC' table. You can move, or remove it, as needed.

            
        }

       
        private void subjectGridControl_Click(object sender, EventArgs e)
        {

        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (tbTenMH == null || tbMaMH == null || tbTenMH.TextLength == 0 || tbMaMH.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
               if (mONHOCBindingSource.Find("MAMH", tbMaMH.Text) == -1) {
                    DataRowView row = (DataRowView)mONHOCBindingSource.AddNew();

                    gridView.BeginEdit(false);
                    row["MAMH"] = tbMaMH.Text;
                    row["TENMH"] = tbTenMH.Text;
                    row["rowguid"] = Guid.NewGuid();
                    gridView.EndEdit();
                    gridView.Refresh();

                    actions.Add(new SubjectAction(SubjectAction.SubjectActionType.ADD, tbMaMH.Text, tbTenMH.Text, (Guid)row["rowguid"]));

                } else
                {
                    MessageBox.Show("Mã môn học đã tồn tại", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        
        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mONHOCBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLDSVDataSet);

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (actions.Count() > 0)
            {
                var action = actions[actions.Count() - 1];
               switch (action.type)
                {
                    case SubjectAction.SubjectActionType.ADD:
                        var index = mONHOCBindingSource.Find("MAMH", action.mamh);
                       if ( index > -1)
                        {
                            mONHOCBindingSource.RemoveAt(index);
                        }
                        break;
                    case SubjectAction.SubjectActionType.DELETE:
                        if (mONHOCBindingSource.Find("MAMH", action.mamh) == -1)
                        {
                            DataRowView row = (DataRowView)mONHOCBindingSource.AddNew();

                            gridView.BeginEdit(false);
                            row["MAMH"] = action.mamh;
                            row["TENMH"] = action.tenmh;
                            row["rowguid"] = action.rowguid;
                            gridView.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Mã môn học đã tồn tại", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                        break;

                }
                actions.RemoveLast();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow != null)
            {
                DataRowView row = (DataRowView)gridView.CurrentRow.DataBoundItem;
                actions.Add(new SubjectAction(SubjectAction.SubjectActionType.DELETE, (string)row.Row["MAMH"], (string)row.Row["TENMH"], (Guid)row.Row["rowguid"]));
                mONHOCBindingSource.RemoveAt(gridView.CurrentRow.Index);
                gridView.Refresh();
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        private void saveChanges()
        {
            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }

            string sqlStr = "";
            int i = actions.Count() - 1;

            while(i > -1)
            {
                var action = actions[i];

                switch (action.type)
                {
                    case SubjectAction.SubjectActionType.ADD:
                        Debug.WriteLine("Đã thêm môn học với mã là: " + action.mamh);
                        sqlStr = "sp_InsertMonHoc";
                        Program.cmd = Program.connect.CreateCommand();
                        Program.cmd.CommandType = CommandType.StoredProcedure;
                        Program.cmd.CommandText = sqlStr;
                        Program.cmd.Parameters.Clear();
                        Program.cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = action.mamh;
                        Program.cmd.Parameters.Add("@TENMH", SqlDbType.NChar).Value = action.tenmh;
                        break;
                    case SubjectAction.SubjectActionType.DELETE:
                        Debug.WriteLine("Đã xóa môn học với mã là: " + action.mamh);
                        sqlStr = "sp_XoaMonHoc";
                        Program.cmd = Program.connect.CreateCommand();
                        Program.cmd.CommandType = CommandType.StoredProcedure;
                        Program.cmd.CommandText = sqlStr;
                        Program.cmd.Parameters.Clear();
                        Program.cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = action.mamh;
                        break;
                }


                var index = Program.cmd.ExecuteNonQuery();
                Debug.WriteLine("Kết quả: " + index.ToString());
                actions.RemoveAt(i);
                i--;
            }

          
            Program.connect.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (actions.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Bạn có ");
                sb.Append(actions.Count().ToString());
                sb.Append(" thay đổi");
                sb.AppendLine();
                sb.Append("Bạn có muốn lưu trước khi thoát?");

                DialogResult dialogResult = MessageBox.Show(sb.ToString(),  "Thoát", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveChanges();
                }
                
            }

            this.Close();
            
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

        public SubjectActionType type;
        public String mamh;
        public String tenmh;
        public Guid rowguid;

        public SubjectAction(SubjectActionType actionType, String mamh, String tenmh, Guid rowguid)
        {
            this.type = actionType;
            this.mamh = mamh;
            this.tenmh = tenmh;
            this.rowguid = rowguid;
        }

    }
    
    
}