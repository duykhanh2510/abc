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
    public partial class fmQuanLySach : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        public fmQuanLySach()
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
        private void layNXB()
        {

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblNXB", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("NXB");
                        ad.Fill(tb);
                        cbxTenNXB.DataSource = tb;
                        cbxTenNXB.DisplayMember = "sTenNXB";
                        cbxTenNXB.ValueMember = "sMaNXB";
                    }
                }
            }
        }
        void Check_Empty_String(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, "Không được để trống");
                btnDisabledAll();
            }
            else if (Check_MaSach() > 0)
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
        int Check_MaSach()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from tblSach where sMasach = '" + txtMaSach.Text + "'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            return i;
        }

        void loadData()
        {
            string sql = "select * from tblSach";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            dgvSach.ReadOnly = true;
            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvSach.DataSource = ds.Tables[0];
            }
            connection.Close();
            btnInitial();

        }

        private void fmQuanLySach_FormClosing(object sender, FormClosingEventArgs e)
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
        private void fmQuanLySach_Load(object sender, EventArgs e)
        {
            loadData();
            layNXB();
           
        }
      
        
        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            /*if(dgvSach.SelectedRows.Count == 0)
            {
                return;
            }
            txtMaSach.Text = dgvSach[0, dgvSach.SelectedRows[0].Index].Value.ToString();
            txtTenSach.Text = dgvSach[1, dgvSach.SelectedRows[1].Index].Value.ToString();
            cbxMaNXB.SelectedValue = dgvSach[1, dgvSach.SelectedRows[2].Index].Value.ToString();
            txtTG.Text = dgvSach[1, dgvSach.SelectedRows[3].Index].Value.ToString();
            txtTL.Text = dgvSach[1, dgvSach.SelectedRows[4].Index].Value.ToString();
            txtSL.Text = dgvSach[1, dgvSach.SelectedRows[5].Index].Value.ToString();
            txtMaSach.ReadOnly = true;*/
            if (dgvSach.CurrentRow == null) return;

            btnChooseRow();

            txtMaSach.Text = dgvSach.CurrentRow.Cells[0].Value.ToString();
            txtTenSach.Text = dgvSach.CurrentRow.Cells[1].Value.ToString();
            cbxTenNXB.SelectedValue = dgvSach.CurrentRow.Cells[2].Value.ToString();
            txtTG.Text = dgvSach.CurrentRow.Cells[3].Value.ToString();
            txtTL.Text = dgvSach.CurrentRow.Cells[4].Value.ToString();
            txtSL.Text = dgvSach.CurrentRow.Cells[5].Value.ToString();
        }
        private void txtMaSach_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtMaSach);
        }

        private void txtTenSach_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTenSach);
        }

        private void txtTG_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTG);
        }
        private void txtTL_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTL);
        }
        private void txtSL_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtSL);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm sách này ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "them_sach";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@Masach", SqlDbType.VarChar, 10);
            param.Value = txtMaSach.Text;

            param = cmd.Parameters.Add("@Tensach", SqlDbType.NVarChar, 255);
            param.Value = txtTenSach.Text;
            param = cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10);
            param.Value = cbxTenNXB.SelectedValue;


            param = cmd.Parameters.Add("@Tacgia", SqlDbType.NVarChar, 255);
            param.Value = txtTG.Text;
            param = cmd.Parameters.Add("@Theloai", SqlDbType.NVarChar, 255);
            param.Value = txtTL.Text;
            param = cmd.Parameters.Add("@Soluong", SqlDbType.VarChar, 10);
            param.Value = txtSL.Text;


            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
            }
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin của sách này ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procSuaSach";


            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@Masach", SqlDbType.VarChar, 10);
            param.Value = txtMaSach.Text;

            param = cmd.Parameters.Add("@Tensach", SqlDbType.NVarChar, 255);
            param.Value = txtTenSach.Text;
            param = cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10);
            param.Value = cbxTenNXB.SelectedValue;
            param = cmd.Parameters.Add("@Tacgia", SqlDbType.NVarChar, 255);
            param.Value = txtTG.Text;
            param = cmd.Parameters.Add("@Theloai", SqlDbType.NVarChar, 255);
            param.Value = txtTL.Text;
            param = cmd.Parameters.Add("@Soluong", SqlDbType.VarChar, 10);
            param.Value = txtSL.Text;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Sửa thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo");
            }
            loadData();
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa sách này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "xoa_sach";

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@Masach", SqlDbType.VarChar, 10);
            param.Value = txtMaSach.Text;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Xóa thành công", "Thông báo");

            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
            }
            loadData();

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from tblSach where sTensach like N'%" + txtTimKiem.Text + "%'";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvSach.DataSource = ds.Tables[0];
            }
            connection.Close();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
    }
}
