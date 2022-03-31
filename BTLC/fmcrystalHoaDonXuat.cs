﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLC
{
    public partial class fmcrystalHoaDonXuat : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmcrystalHoaDonXuat()
        {
            InitializeComponent();
        }

        private void fmcrystalHoaDonXuat_Load(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblHoaDonXuat", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("NXB");
                        ad.Fill(tb);
                        cbbMa.DataSource = tb;
                        cbbMa.DisplayMember = "sMaHDX";
                        cbbMa.ValueMember = "sMaHDX";
                    }
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            ReportDocument crys = new ReportDocument();
            crys.Load(@"C:\Users\HP\source\repos\BTLC\BTLC\rptHoaDonXuat.rpt");

            ParameterFieldDefinition pfd = crys.DataDefinition.ParameterFields["Mã hóa đơn"];
            ParameterValues pv = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = cbbMa.SelectedValue;
            pv.Add(pdv);
            pfd.CurrentValues.Clear();
            pfd.ApplyCurrentValues(pv);

            crystalReportViewer1.ReportSource = crys;
            crystalReportViewer1.Refresh();
        }
    }
}
