using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;


namespace BTLC
{
    public partial class fmChiTietHoaDonNhap : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmChiTietHoaDonNhap()
        {
            InitializeComponent();
        }

        
        void btnInitial()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        void btnChooseRow()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        void btnDisabledAll()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }
        void btnExisted()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

        }

        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtSL.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if(!Char.IsDigit(ch)&& ch!=8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        void loadData()
        {
            string sql = "select * from vDanhSachChiTietHoaDonNhap";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            
            dgvDanhSachHDN.ReadOnly = true;
            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvDanhSachHDN.DataSource = ds.Tables[0];
            }
            connection.Close();
      
        }
        private void fmChiTietHoaDonNhap_Load(object sender, EventArgs e)
        {
            loadData();
            SqlConnection conn = new SqlConnection(ConnectionString);
            DataSet ds = new DataSet();
            string SQL = "select * from tblSach";
            SqlDataAdapter sda = new SqlDataAdapter(SQL, conn);
            conn.Open();
            sda.Fill(ds);
            cbbTenSach.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTenSach.DataSource = ds.Tables[0];
            cbbTenSach.DisplayMember = ds.Tables[0].Columns[1].ToString();

           
            DataSet ds1 = new DataSet();
            string sql = "select * from vDanhSachHoaDonNhap";
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            
            SDA.Fill(ds1);
            cbbMaHD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbMaHD.DataSource = ds1.Tables[0];
            cbbMaHD.DisplayMember = ds1.Tables[0].Columns[0].ToString();
        }

        private void txtDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtDG.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void cbbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
           

            string sql = "select * from vDanhSachChiTietHoaDonNhap where sMaHDN = N'" + cbbMaHD.Text + "'";
            
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, ConnectionString);
            DataSet ds = new DataSet();
            

            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvDanhSachHDN.DataSource = ds.Tables[0];
            }
            
            sqlConnection.Close();

        }

        private void cbbMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mas = cbbTenSach.Text;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select sMasach from tblSach where sTensach = N'" + mas + "'", sqlConnection);

            string i = (string)cmd.ExecuteScalar();
            txtMaSach.Text = i;
        }
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thêm hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procThemChiTietHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDN", SqlDbType.VarChar, 10);
            param.Value = cbbMaHD.Text;

            param = cmd.Parameters.Add("@Masach", SqlDbType.VarChar, 10);
            param.Value = txtMaSach.Text;

            param = cmd.Parameters.Add("@SL", SqlDbType.Int);
            param.Value = txtSL.Text;

            param = cmd.Parameters.Add("@DGmua", SqlDbType.Float);
            param.Value = txtDG.Text;

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("thêm thành công", "thông báo");
            }
            else
            {
                MessageBox.Show("thêm thất bại", "thông báo");
            }
            loadData();
        }

        private void dgvDanhSachHDN_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDanhSachHDN.CurrentRow == null) return;
            btnChooseRow();

            /*cbbMaHD.Text = dgvDanhSachHDN.CurrentRow.Cells[0].Value.ToString();*/
            cbbTenSach.Text = dgvDanhSachHDN.CurrentRow.Cells[2].Value.ToString();
            txtSL.Text = dgvDanhSachHDN.CurrentRow.Cells[3].Value.ToString();
            txtDG.Text = dgvDanhSachHDN.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn sửa hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procSuaChiTietHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDN", SqlDbType.VarChar, 10);
            param.Value = cbbMaHD.Text;

            param = cmd.Parameters.Add("@Masach", SqlDbType.VarChar, 10);
            param.Value = txtMaSach.Text;

            param = cmd.Parameters.Add("@SL", SqlDbType.Int);
            param.Value = txtSL.Text;

            param = cmd.Parameters.Add("@DGmua", SqlDbType.Float);
            param.Value = txtDG.Text;

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Sửa thành công", "thông báo");
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "thông báo");
            }
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procXoaChiTietHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDN", SqlDbType.VarChar, 10);
            param.Value = cbbMaHD.Text;

            param = cmd.Parameters.Add("@MaS", SqlDbType.VarChar, 10);
            param.Value = txtMaSach.Text;


            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("xóa thành công", "thông báo");
            }
            else
            {
                MessageBox.Show("xóa thất bại", "thông báo");
            }
            loadData();
        }

        void Check_Empty_String(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, "Không được để trống");
                btnDisabledAll();
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                btnInitial();
            }
        }
        private void txtSL_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtSL);
        }

        private void txtDG_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtDG);
        }

        private void fmChiTietHoaDonNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else e.Cancel = false;
            }
        }

        bool TonTai(string MaHD , string MaSach)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sq = new SqlCommand("Select * from tblChiTietHDN where sMaHDN = @MaHD and sMasach = @MaSach ", con);
           
            sq.Parameters.Clear();
            sq.Parameters.AddWithValue("@MaHD", MaHD);
            sq.Parameters.AddWithValue("@MaSach", MaSach);
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
        private void cbbMaSach_Validating(object sender, CancelEventArgs e)
        {
            if (TonTai(cbbMaHD.Text.ToString(), txtMaSach.Text.ToString()) == true)
            {
                errorProvider1.SetError(cbbTenSach, "Đã tồn tại sách này trong hóa đơn.");
                btnThem.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(cbbTenSach, "");
                btnThem.Enabled = true;
            }    
                
        }

        
    }
}
