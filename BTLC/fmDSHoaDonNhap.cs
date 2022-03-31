using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace BTLC
{
    public partial class fmDSHoaDonNhap : Form
    {
        public fmDSHoaDonNhap()
        {
            InitializeComponent();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            ReportDocument crys = new ReportDocument();
            crys.Load(@"C:\Users\HP\source\repos\BTLC\BTLC\DSHoaDonNhap.rpt");

            ParameterFieldDefinition pfd1 = crys.DataDefinition.ParameterFields["Từ ngày"];
            ParameterValues pv1 = new ParameterValues();
            ParameterDiscreteValue pdv1 = new ParameterDiscreteValue();
            pdv1.Value = dtpStart.Value;
            pv1.Add(pdv1);
            pfd1.CurrentValues.Clear();
            pfd1.ApplyCurrentValues(pv1);

            ParameterFieldDefinition pfd2 = crys.DataDefinition.ParameterFields["Đến"];
            ParameterValues pv2 = new ParameterValues();
            ParameterDiscreteValue pdv2 = new ParameterDiscreteValue();
            pdv2.Value = dtpEnd.Value;
            pv2.Add(pdv2);
            pfd2.CurrentValues.Clear();
            pfd2.ApplyCurrentValues(pv2);

            crystalReportViewer1.ReportSource = crys;
            crystalReportViewer1.Refresh();
        }
    }
}
