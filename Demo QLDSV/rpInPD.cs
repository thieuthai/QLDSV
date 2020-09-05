using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Demo_QLDSV
{
    public partial class rpInPD : DevExpress.XtraReports.UI.XtraReport
    {
      
        private DataSet ds;

        public rpInPD(String Masv, DataTable dt)

        {
            
            InitializeComponent();
            ds = new DataSet();
            ds.DataSetName = "dataset";
           
            dt.TableName = "SV";
            ds.Tables.Add(dt);
            this.DataSource = ds;
            this.DataMember = ds.Tables[0].TableName;
            lblMSSV.Text = Masv;
           // lblTenSV.Text = TenSv;
        }

    }
}
