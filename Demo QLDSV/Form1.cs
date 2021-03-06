﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo_QLDSV
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmLogin));
            if (frm != null) frm.Activate();
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
            }
        }

        public void initForm()
        {
         //   Program.frmChinh.lblName.Text = "UserID : " + Program.currentID + "\nUsername : " + Program.currentLoginName + "\nGroup : " + Program.currentRole;
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

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // Form frm = this.CheckExists(typeof(Form3));
           // if (frm != null) frm.Activate();
          //  else
          //  {
          //      Form3 f = new Form3();
          //      f.Show();
         //       
         //   }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
