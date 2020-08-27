using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_QLDSV
{
    public partial class frmLop : Form
    {
        int index = 0;
        String depID = "";
        String currentClassID = "";
        String currentClassName = "";
        String method = Program.Method.New;

        // Stack Undo
        public Stack stUndo = new Stack();
        public Stack stRedo = new Stack();
        public ClassDto dtoUndo = new ClassDto("", "", "");
        public bool isUndo = false;
        public bool isRedo = false;
        public class ClassDto
        {
            public String strClassID;
            public String strClassName;
            public String method;
            public int index;
            public ClassDto(String depID, String depName, String strMethod)
            {
                strClassID = depID;
                strClassName = depName;
                method = strMethod;
            }
        }
        public frmLop()
        {
            InitializeComponent();
        }
        private void frmClass_Load(object sender, EventArgs e)
        {
            qLDSVDataSet.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dataSetTracNghiem.LOP' table. You can move, or remove it, as needed.
            this.lopTableAdapter1.Connection.ConnectionString = Program.connectStr;
            this.lopTableAdapter1.Fill(this.qLDSVDataSet.LOP);

            cbbPhongBan.DataSource = Program.bds;
            cbbPhongBan.DisplayMember = "MAKH";
            cbbPhongBan.ValueMember = "TENKH";
            cbbPhongBan.SelectedIndex = Program.currentBranch;

            depID = Program.currentBranch == 0 ? "CNTT" : "VT";

            Program.currentBidingSource = vDSPHANMANHBindingSource;

            setCurrentRole();
           
            if (vDSPHANMANHBindingSource.Count == 0) btnDel.Enabled = false;
        }
        public void setCurrentRole()
        {
            if (Program.currentRole == "PGV")
            {
                cbbPhongBan.Enabled = true;
            }
            else
            {
                cbbPhongBan.Enabled = false;
                cbbPhongBan.Visible = false;
            }

            btnNew.Enabled = btnDel.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
          
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOPBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLDSVDataSet);

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void cbbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSV_VIEWKHOA.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSV_VIEWKHOA.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'qLDSVDataSet.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.qLDSVDataSet.SINHVIEN);

        }
    }
}
