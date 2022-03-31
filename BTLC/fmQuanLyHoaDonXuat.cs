using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;
namespace BTLC
{
    public partial class fmQuanLyHoaDonXuat : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmQuanLyHoaDonXuat()
        {
            InitializeComponent();
        }
        void btnInitial()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
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

        void loadData()
        {
            string sql = "select * from vDanhSachHoaDonXuat";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            //dgvDSNhanVien.AutoGenerateColumns = false;

            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvHDX.DataSource = ds.Tables[0];
            }
            connection.Close();
            btnInitial();

        }

        int Check_MaHDX()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from tblHoaDonXuat where sMaHDX = '" + txtMaHDX.Text + "'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            return i;
        }

        void Check_Empty_String(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, "Không được để trống");
                btnDisabledAll();
            }
            else if (Check_MaHDX() > 0)
            {
                errorProvider1.SetError(textBox, "");
                btnExisted();
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                btnInitial();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm hóa đơn này ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procThemHDX";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDX", SqlDbType.VarChar, 10);
            param.Value = txtMaHDX.Text;

            param = cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10);
            param.Value = txtMaNV.Text;

            param = cmd.Parameters.Add("@NgayLap", SqlDbType.Date);
            param.Value = dtpNgayLap.Value.ToString();

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn sửa hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procSuaHDX";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDX", SqlDbType.VarChar, 10);
            param.Value = txtMaHDX.Text;

            param = cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10);
            param.Value = txtMaNV.Text;

            param = cmd.Parameters.Add("@NgayLap", SqlDbType.Date);
            param.Value = dtpNgayLap.Value.ToString();

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("sửa thành công", "thông báo");
            }
            else
            {
                MessageBox.Show("sửa thất bại", "thông báo");
            }
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procXoaHDX";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDX", SqlDbType.VarChar, 10);
            param.Value = txtMaHDX.Text;


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

        private void fmQuanLyHoaDonXuat_Load(object sender, EventArgs e)
        {

            loadData();
            SqlConnection conn = new SqlConnection(ConnectionString);
            DataSet ds = new DataSet();
            string SQL = "SELECT * FROM vDanhSachNhanVien";
            SqlDataAdapter sda = new SqlDataAdapter(SQL, conn);
            conn.Open();
            sda.Fill(ds);
            cbxTenNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTenNV.DataSource = ds.Tables[0];
            cbxTenNV.DisplayMember = ds.Tables[0].Columns[1].ToString();
        }
        private void fmQuanLyHoaDonXuat_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtMaHD_Validating(object sender, CancelEventArgs e)
        {

            Check_Empty_String(txtMaHDX);

        }

        private void dgvDSHoaDonXuat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHDX.CurrentRow == null) return;
            btnChooseRow();

            txtMaHDX.Text = dgvHDX.CurrentRow.Cells[0].Value.ToString();
            txtMaNV.Text = dgvHDX.CurrentRow.Cells[1].Value.ToString();
            cbxTenNV.Text = dgvHDX.CurrentRow.Cells[2].Value.ToString();
            if (dgvHDX.CurrentRow.Index >= dgvHDX.Rows.Count - 1)
            {
                dtpNgayLap.Value = DateTime.Parse("01/01/2000");
                btnDisabledAll();
            }
            else
                dtpNgayLap.Value = DateTime.Parse(dgvHDX.CurrentRow.Cells[3].Value.ToString());
        }
        private void cbxMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Check_MaHDX() > 0)
            {
                btnExisted();
            }
            else
            {
                btnInitial();
            }
            string manv = cbxTenNV.Text;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select sMaNV from tblNhanVien where sTenNV = N'" + manv + "'", sqlConnection);

            string i = (string)cmd.ExecuteScalar();
            txtMaNV.Text = i;

        }
    }
}
