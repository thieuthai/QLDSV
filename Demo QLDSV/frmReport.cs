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

namespace Demo_QLDSV
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void btnDSSV_Click(object sender, EventArgs e)
        {
            this.Hide();
            var xfrmSinhvien = new xfrmSinhVien();
            xfrmSinhvien.Closed += (s, args) => this.Close();
            xfrmSinhvien.Show();
        }

        private void btnBangDiem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var xfrmBangDiem = new xfrmBangDiem();
            xfrmBangDiem.Closed += (s, args) => this.Close();
            xfrmBangDiem.Show();
        }
    }
}