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
    public partial class fmDangNhap : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmDangNhap()
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

        private void btnDN_Click(object sender, EventArgs e)
        {
            if(KiemTra(txtTDN.Text, "Select * from tblTaiKhoan where sTenDangNhap = @Ten") == false)
            {
                MessageBox.Show("Không tồn tại tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTDN.Focus();
            }
            else if(KiemTra(txtMK.Text, "Select * from tblTaiKhoan where sMatKhau = @Ten") == false)
            {
                MessageBox.Show("Bạn nhập sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMK.Focus();
            }else
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo!", MessageBoxButtons.OK);
                Form1 form = new Form1();
                form.Show();
                
            }    
            
        }

        private void fmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                if (MessageBox.Show("bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else e.Cancel = false;
        }

        private void txtTDN_Validating(object sender, CancelEventArgs e)
        {
            if(txtTDN.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTDN, "Không được bỏ trống.");
                btnDN.Enabled = false;
            }   
            else
            {
                errorProvider1.SetError(txtTDN, "");
                btnDN.Enabled = true;
            }
        }

        private void txtMK_Validating(object sender, CancelEventArgs e)
        {
            if (txtMK.Text == "")
            {
                errorProvider1.SetError(txtMK, "Không được bỏ trống.");
                btnDN.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtMK, "");
                btnDN.Enabled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
