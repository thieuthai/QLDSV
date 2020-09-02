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
    public partial class XfrmDanhSachSVLop : Form
    {
        public XfrmDanhSachSVLop()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaLop_TextChanged(object sender, EventArgs e)
        {
            txtMaLop.Enabled = false;
        }
    }
}
