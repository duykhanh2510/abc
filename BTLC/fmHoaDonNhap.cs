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
using System.Data.SqlClient;
using System.Configuration;

namespace BTLC
{
    public partial class fmHoaDonNhap : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void fmHoaDonNhap_Load(object sender, EventArgs e)
        {
            
        }

        bool KiemTra(string ten, string sql)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sq = new SqlCommand(sql, con);

            sq.Parameters.Clear();
            sq.Parameters.AddWithValue("@Ten", ten);

            con.Open();
            SqlDataReader dr = sq.ExecuteReader();
            bool TimThay = false;

            if (dr.Read() == true)
            {
                TimThay = true;
            }
            con.Close();
            return TimThay;
        }
        private void btnHien_Click(object sender, EventArgs e)
        {
            if(KiemTra(txtHien.Text, "select sMaHDN from tblHoaDonNhap where sMaHDN = @Ten") == false)
            {
                MessageBox.Show("Không tồn tại hóa đơn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ReportDocument crys = new ReportDocument();
                crys.Load(@"C:\Users\HP\source\repos\BTLC\BTLC\rptHoaDonNhap.rpt");

                ParameterFieldDefinition pfd = crys.DataDefinition.ParameterFields["Mã hóa đơn"];
                ParameterValues pv = new ParameterValues();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();
                pdv.Value = txtHien.Text;
                pv.Add(pdv);
                pfd.CurrentValues.Clear();
                pfd.ApplyCurrentValues(pv);

                crystalReportViewer1.ReportSource = crys;
                crystalReportViewer1.Refresh();
            }
            
        }

        
    }
}
