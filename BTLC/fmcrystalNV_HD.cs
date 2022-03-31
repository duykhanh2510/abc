using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLC
{
    public partial class fmcrystalNV_HD : Form
    {
        public fmcrystalNV_HD()
        {
            InitializeComponent();
        }

        private void fmcrystalNV_HD_Load(object sender, EventArgs e)
        {
            ReportDocument crys = new ReportDocument();
            crys.Load(@"C:\Users\HP\source\repos\BTLC\BTLC\rptNV_HD.rpt");

            crystalReportViewer1.ReportSource = crys;
            crystalReportViewer1.Refresh();
        }
    }
}
