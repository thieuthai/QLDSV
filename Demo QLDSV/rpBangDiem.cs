using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Demo_QLDSV
{
    public partial class rpBangDiem : DevExpress.XtraReports.UI.XtraReport
    {

        private DataSet ds;
        private String tenlop;
        private String tenmh;
        private String lanthi;


        public rpBangDiem(DataTable dt, String tenlop, String tenmh, String lanthi)
        {
            InitializeComponent();

            this.tenlop = tenlop;
            this.tenmh = tenmh;
            this.lanthi = lanthi;

            ds = new DataSet();
            ds.DataSetName = "dataset";
            DataTable data = dt.Copy();
            data.TableName = "SV";
            ds.Tables.Add(data);
            this.DataSource = ds;
            this.DataMember = ds.Tables[0].TableName;
        }

        private void rpBangDiem_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbClass.Text = this.tenlop;
            lbSubject.Text = this.tenmh;
            lbCount.Text = this.lanthi;
        }
    }
}
