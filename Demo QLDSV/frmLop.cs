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
using DevExpress.Charts.Native;
using System.Diagnostics;

namespace Demo_QLDSV
{
    public partial class frmLop : DevExpress.XtraEditors.XtraForm
    {
        private List<ClassAction> actions = new List<ClassAction>();
        BindingSource bds = new BindingSource();

        public frmLop()
        {
            InitializeComponent();

            
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.qLDSVDataSet.LOP);

            if (Program.currentRole != "PGV")
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnUndo.Enabled = false;
                tbMaLop.Enabled = false;
                tbTenLop.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                btnUndo.Enabled = true;
                tbMaLop.Enabled = true;
                tbTenLop.Enabled = true;
            }
            bds = new BindingSource();
            
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("sp_LayDsLopTheoKhoa");
            dt.TableName = "LOP";
            bds.DataSource = dt;
            gridView.DataSource = bds;
            
            gridView.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow != null)
            {
                DataRowView row = (DataRowView)gridView.CurrentRow.DataBoundItem;
                actions.Add(new ClassAction(ClassAction.ClassActionType.DELETE, (string)row.Row["MALOP"], (string)row.Row["TENMH"]));
                bds.RemoveAt(gridView.CurrentRow.Index);
                gridView.Refresh();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (actions.Count() > 0)
            {
                var action = actions[actions.Count() - 1];
                switch (action.type)
                {
                    case ClassAction.ClassActionType.ADD:
                        var index = bds.Find("MALOP", action.malop);
                        if (index > -1)
                        {
                            bds.RemoveAt(index);
                        }
                        break;
                    case ClassAction.ClassActionType.DELETE:
                        if (bds.Find("MALOP", action.malop) == -1)
                        {
                            DataRowView row = (DataRowView)bds.AddNew();

                            gridView.BeginEdit(false);
                            row["MALOP"] = action.malop;
                            row["TENLOP"] = action.tenlop;
                            gridView.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Lớp đã tồn tại", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        break;

                }
                actions.RemoveLast();
            }
        }

        private void saveChanges()
        {
            String makh;
            if (Program.currentBranch == 0)
            {
                makh = "CNTT";
            }
            else
            {
                makh = "VT";
            }

            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }

            string sqlStr = "";
            int i = actions.Count() - 1;

            while (i > -1)
            {
                var action = actions[i];
                
                
                switch (action.type)
                {
                    case ClassAction.ClassActionType.ADD:
                        Debug.WriteLine("Đã thêm lớp với mã là: " + action.malop);
                        sqlStr = "sp_InsertLop";
                        Program.cmd = Program.connect.CreateCommand();
                        Program.cmd.CommandType = CommandType.StoredProcedure;
                        Program.cmd.CommandText = sqlStr;
                        Program.cmd.Parameters.Clear();
                        Program.cmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = action.malop;
                        Program.cmd.Parameters.Add("@TENLOP", SqlDbType.NChar).Value = action.tenlop;
                        Program.cmd.Parameters.Add("@MKH", SqlDbType.NChar).Value = makh;
                        break;
                    case ClassAction.ClassActionType.DELETE:
                        Debug.WriteLine("Đã xóa lớp với mã là: " + action.malop);
                        sqlStr = "sp_XoaLop";
                        Program.cmd = Program.connect.CreateCommand();
                        Program.cmd.CommandType = CommandType.StoredProcedure;
                        Program.cmd.CommandText = sqlStr;
                        Program.cmd.Parameters.Clear();
                        Program.cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = action.malop;
                        break;
                }


                var index = Program.cmd.ExecuteNonQuery();
                Debug.WriteLine("Kết quả: " + index.ToString());
                actions.RemoveAt(i);
                i--;
            }


            Program.connect.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
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

                DialogResult dialogResult = MessageBox.Show(sb.ToString(), "Thoát", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveChanges();
                }

            }

            this.Close();

        }

        private void tbMaLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbTenLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbTenLop == null || tbMaLop == null || tbTenLop.TextLength == 0 || tbMaLop.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (bds.Find("MALOP", tbMaLop.Text) == -1)
                {
                    DataRowView row = (DataRowView)bds.AddNew();

                    gridView.BeginEdit(false);
                    row["MALOP"] = tbMaLop.Text;
                    row["TENLOP"] = tbTenLop.Text;
                 //   row["rowguid"] = Guid.NewGuid();
                    gridView.EndEdit();
                    gridView.Refresh();

                    actions.Add(new ClassAction(ClassAction.ClassActionType.ADD, tbMaLop.Text, tbTenLop.Text));

                }
                else
                {
                    MessageBox.Show("Lớp đã tồn tại", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}

public class ClassAction
{
    public enum ClassActionType
    {
        ADD,
        DELETE,
        UPDATE
    }

    public ClassActionType type;
    public String malop;
    public String tenlop;

    public ClassAction(ClassActionType actionType, String malop, String tenlop)
    {
        this.type = actionType;
        this.malop = malop;
        this.tenlop = tenlop;
    }

}
