using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Report;

namespace LOrd_card_shop.View.Admin
{
    public partial class TransactionReportPage : System.Web.UI.Page
    {
        private TransactionHeaderController _thc = new TransactionHeaderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            CrystalReport1 report1 = new CrystalReport1();

            report1.SetDataSource(_thc.GetDataSet());

            CrystalReportViewer1.ReportSource = report1;
            CrystalReportViewer1.RefreshReport();
        }
    }
}