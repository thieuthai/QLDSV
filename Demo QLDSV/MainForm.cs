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
using System.Linq.Expressions;

namespace Demo_QLDSV
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            switch (Program.currentRole)
            {
                
                case "PKT":
                    btnStudent.Enabled = true;
                    btnSubject.Enabled = true;
                    btnClass.Enabled = true;
                    btnFee.Enabled = false;
                    break;
                default:
                    btnStudent.Enabled = true;
                    btnSubject.Enabled = true;
                    btnClass.Enabled = true;
                    btnFee.Enabled = false;
                    break;
            }
        }

        private void onBtnStudentPress(object sender, MouseEventArgs e)
        {
            
        }

        private void onbtnSubjectPress(object sender, MouseEventArgs e)
        {
            SubjectForm subjectForm = new SubjectForm();
            subjectForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new frmLogin();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmReport = new frmReport();
            frmReport.Show();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            var dssvLopForm = new frmDiemSv();
            dssvLopForm.Show();
        }
    }
}