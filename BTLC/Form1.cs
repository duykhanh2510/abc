
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new fmQuanLyNhanVien();
            form.MdiParent = this;
            form.Show();
        }
        


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                if (MessageBox.Show("bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else e.Cancel = false;
        }

        

        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmQuanLyHoaDonNhap form = new fmQuanLyHoaDonNhap();
            form.MdiParent = this;
            form.Show();
        }

        private void quảnLýChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChiTietHoaDonNhap form = new fmChiTietHoaDonNhap();
            form.MdiParent = this;
            form.Show();
        }

        private void hóaĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmHoaDonNhap form = new fmHoaDonNhap();
            form.MdiParent = this;
            form.Show();
        }

        private void danhSáchHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmDSHoaDonNhap form = new fmDSHoaDonNhap();
            form.MdiParent = this;
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fmQuanLyNXB form = new fmQuanLyNXB();
            form.MdiParent = this;
            form.Show();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmDangKy form = new fmDangKy();
            form.MdiParent = this;
            form.Show();
        }

        private void quảnLýToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            fmQuanLySach form = new fmQuanLySach();
            form.MdiParent = this;
            form.Show();
        }

        private void sáchCủaNXBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmcrystalSachTuNXB form = new fmcrystalSachTuNXB();
            form.MdiParent = this;
            form.Show();
        }

        private void sốLượngHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmcrystalNV_HD form = new fmcrystalNV_HD();
            form.MdiParent = this;
            form.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmQuanLyHoaDonXuat form = new fmQuanLyHoaDonXuat();
            form.MdiParent = this;
            form.Show();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChiTietHoaDonXuat form = new fmChiTietHoaDonXuat();
            form.MdiParent = this;
            form.Show();
        }

        private void hóaĐơnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmcrystalHoaDonXuat form = new fmcrystalHoaDonXuat();
            form.MdiParent = this;
            form.Show();
        }
    }
}
