using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataProcessing;
using System.Diagnostics;
using System.Data;

namespace Demo_QLDSV
{
    public partial class rpDSSV : DevExpress.XtraReports.UI.XtraReport
    {

        private String tenlop;
        private DataSet ds;
        public rpDSSV(DataTable dt, String tenlop)
        {
            InitializeComponent();

            this.tenlop = tenlop;
            ds = new DataSet();
            ds.DataSetName = "dataset";
            dt.TableName = "SV";
            ds.Tables.Add(dt);
            this.DataSource = ds;
            this.DataMember = ds.Tables[0].TableName;
        }

        private void rpDSSV_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Debug.WriteLine(this.tenlop);
            lbLop.Text = this.tenlop;

        }
    }
}
