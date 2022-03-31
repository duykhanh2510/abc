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
    public partial class fmDangKy : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmDangKy()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn đăng ký ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "them_TK";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@sTenDangNhap", SqlDbType.VarChar, 50);
            param.Value = txtTDN.Text;

            param = cmd.Parameters.Add("@sMatKhau", SqlDbType.VarChar, 50);
            param.Value = txtMK.Text;

            

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Đăng ký thành công", "thông báo");
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại", "thông báo");
            }
        }

        private void txtTDN_Validating(object sender, CancelEventArgs e)
        {
            if(txtTDN.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTDN, "Không được bỏ trống!");
                btnDK.Enabled = false;
            }    
            else if(KiemTra(txtTDN.Text, "Select * from tblTaiKhoan where sTenDangNhap = @Ten") == true)
            {
                errorProvider1.SetError(txtTDN, "Đã tồn tại tài khoản này!");
                btnDK.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtTDN, "");
                btnDK.Enabled = true;
            }   
        }

        private void txtMK_Validating(object sender, CancelEventArgs e)
        {
            if (txtMK.Text == "")
            {
                errorProvider1.SetError(txtMK, "Không được bỏ trống!");
                btnDK.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtMK, "");
                btnDK.Enabled = true;
            }
        }

        private void txtNLMK_Validating(object sender, CancelEventArgs e)
        {
            if (txtNLMK.Text == "")
            {
                errorProvider1.SetError(txtNLMK, "Không được bỏ trống!");
                btnDK.Enabled = false;
            }
            else if(txtNLMK.Text != txtMK.Text)
            {
                errorProvider1.SetError(txtNLMK, "Không khớp với mật khẩu!");
                btnDK.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtNLMK, "");
                btnDK.Enabled = true;
            }
        }
    }
}
