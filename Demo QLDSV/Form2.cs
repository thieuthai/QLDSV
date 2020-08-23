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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSV_VIEWKHOA.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSV_VIEWKHOA.V_DS_PHANMANH);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "Username" || txtPass.Text.Trim() == "Password")
            {
                MessageBox.Show("Tài khoản đăng nhập không được rỗng", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                txtUser.Focus();
                txtPass.Focus();
                return;
            }

            try
            {
                Program.userName = txtUser.Text.Trim();
                Program.password = txtPass.Text.Trim();
                Program.serverName = cbbTenKhoa.SelectedValue.ToString().Trim();

                if (Program.Connection() == 0) return;
                Program.currentBranch = cbbTenKhoa.SelectedIndex;
                Program.bds = bdsKhoa;
                Program.currentUserName = Program.userName;
                Program.currentPass = Program.password;
                String strLenh = "";
                //if (rbGiaoVien.Checked == true)
                //{
                //    strLenh = "exec SP_DANGNHAP '" + Program.userName + "'";
                //}
                //else if (rbSinhVien.Checked == true)
                //{
                //    strLenh = "exec sp_DangNhapSinhVien '" + Program.userName + "'";
                //}
                strLenh = "exec SP_DANGNHAP_GIAOVIEN '" + Program.userName + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                Program.currentID = Program.myReader.GetString(0);     // Lay username
                if (Convert.IsDBNull(Program.currentID))
                {
                    MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại Username của cơ sở dữ liệu", "", MessageBoxButtons.OK);
                    return;
                }
                Program.currentLoginName = Program.myReader.GetString(1); // lấy họ tên 
                Program.currentRole = Program.myReader.GetString(2); // lấy nhóm quyền
                Program.myReader.Close();
                Program.connect.Close();

                initForm();

                Hide();

            }
            catch
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username của cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void initForm()
        {
            Program.frmChinh.lblName.Text = "UserID : " + Program.currentID + "\nUsername : " + Program.currentLoginName + "\nGroup : " + Program.currentRole;
            //Program.frmChinh.userName.Text = "Username : " + Program.currentLoginName;
            //Program.frmChinh.userRole.Text = "Group : " + Program.currentRole;

            //Program.frmChinh.btnLogin.Enabled = false;
            //Program.frmChinh.btnLogout.Enabled = true;
            //if (Program.currentRole == "USER")
            //{
            //    Program.frmChinh.btnCreate.Enabled = false;
            //}
            //initRibGroup(true);
        }
    }
}
