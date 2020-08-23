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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOPBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLDSVDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            qLDSVDataSet.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSVDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connectStr;
            this.lOPTableAdapter.Fill(this.qLDSVDataSet.LOP);

            cbbDep.DataSource = Program.bds;
            cbbDep.DisplayMember = "TENKHOA";
            cbbDep.ValueMember = "TENSERVER";
            cbbDep.SelectedIndex = Program.currentBranch;

            //depID = Program.currentBranch == 0 ? "CNTT" : "VT";

            Program.currentBidingSource = lOPBindingSource;

        }

        private void cbbDep_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //stUndo.Clear();
            //stRedo.Clear();
            //updateUIUndo();
            if (cbbDep.SelectedValue != null)
            {
                if (cbbDep.SelectedValue.ToString() == "System.Data.DataRowView") return;
                Program.serverName = cbbDep.SelectedValue.ToString();
                Program.currentBranch = cbbDep.SelectedIndex;
                //depID = Program.currentBranch == 0 ? "CNTT" : "VT";

                if (cbbDep.SelectedIndex != Program.currentBranch)
                {
                    Program.userName = Program.remoteLogin;
                    Program.password = Program.remotePass;
                }
                else
                {
                    Program.userName = Program.currentUserName;
                    Program.password = Program.currentPass;
                }
                if (Program.Connection() == 0)
                    MessageBox.Show("Connect Error", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connectStr;
                    this.lOPTableAdapter.Fill(this.qLDSVDataSet.LOP);
                }
            }
        }
    }
}
