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
    public partial class fmQuanLyNXB : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmQuanLyNXB()
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

        void Check_Empty_String(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, "Không được để trống");
                btnDisabledAll();
            }
            else if (Check_MaNXB() > 0)
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
        int Check_MaNXB()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from tblNXB where sMaNXB = '" + txtMaNXB.Text + "'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            return i;
        }

        void loadData()
        {
            string sql = "select * from tblNXB";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            dgvNXB.ReadOnly = true;
            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvNXB.DataSource = ds.Tables[0];
            }
            connection.Close();
            btnInitial();

        }
      

        private void fmQuanLyNXB_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void fmQuanLyNXB_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvNXB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
        private void dgvNXB_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNXB.CurrentRow == null) return;

            btnChooseRow();

            txtMaNXB.Text = dgvNXB.CurrentRow.Cells[0].Value.ToString();
            txtTenNXB.Text = dgvNXB.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dgvNXB.CurrentRow.Cells[2].Value.ToString();
            txtDC.Text = dgvNXB.CurrentRow.Cells[3].Value.ToString();

        }
        private void txtMaNXB_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtMaNXB);
        }

        private void txtTenNV_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTenNXB);
        }

        private void txtDC_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtDC);
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from tblNXB where sMaNXB <> '" + txtMaNXB.Text + "' and sSDT='" + txtSDT.Text
               + "'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            if (i > 0)
            {
                errorProvider1.SetError(txtSDT, "Không được trùng số điện thoại");
                btnDisabledAll();
                return;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");

            }
            Check_Empty_String(txtDC);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm nhà xuất bản này ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "them_NXB";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10);
            param.Value = txtMaNXB.Text;

            param = cmd.Parameters.Add("@TenNXB", SqlDbType.NVarChar, 25);
            param.Value = txtTenNXB.Text;

            

            param = cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 10);
            param.Value = txtSDT.Text;
            param = cmd.Parameters.Add("@DC", SqlDbType.NVarChar, 255);
            param.Value = txtDC.Text;


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
            if (MessageBox.Show("Bạn có muốn sửa thông tin của nhà xuất bản này ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procSuaNXB";


            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10);
            param.Value = txtMaNXB.Text;

            param = cmd.Parameters.Add("@TenNXB", SqlDbType.NVarChar, 25);
            param.Value = txtTenNXB.Text;
            param = cmd.Parameters.Add("@DC", SqlDbType.NVarChar, 255);
            param.Value = txtDC.Text;
            param = cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 10);
            param.Value = txtSDT.Text;
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
            if (MessageBox.Show("bạn có muốn xóa nhà xuất bản này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "xoa_nxb";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10);
            param.Value = txtMaNXB.Text;


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
            string sql = "select * from tblNXB where sTenNXB like N'%" + txtTimKiem.Text + "%'";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            //dgvDSNhanVien.AutoGenerateColumns = false;

            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvNXB.DataSource = ds.Tables[0];
            }
            connection.Close();
            btnInitial();
        }

        
    }
}
