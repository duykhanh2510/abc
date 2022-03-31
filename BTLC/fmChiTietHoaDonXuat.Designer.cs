
namespace BTLC
{
    partial class fmChiTietHoaDonXuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvChiTietHDX = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxMaHDX = new System.Windows.Forms.ComboBox();
            this.cbxTensach = new System.Windows.Forms.ComboBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtDG = new System.Windows.Forms.TextBox();
            this.txtMasach = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.sMaHDX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMasach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTensach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDGban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChiTietHDX
            // 
            this.dgvChiTietHDX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietHDX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHDX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMaHDX,
            this.sMasach,
            this.sTensach,
            this.iSL,
            this.fDGban,
            this.tongtien});
            this.dgvChiTietHDX.Location = new System.Drawing.Point(-2, 0);
            this.dgvChiTietHDX.Name = "dgvChiTietHDX";
            this.dgvChiTietHDX.ReadOnly = true;
            this.dgvChiTietHDX.RowHeadersWidth = 51;
            this.dgvChiTietHDX.RowTemplate.Height = 24;
            this.dgvChiTietHDX.Size = new System.Drawing.Size(803, 212);
            this.dgvChiTietHDX.TabIndex = 0;
            this.dgvChiTietHDX.SelectionChanged += new System.EventHandler(this.dgvChiTietHDX_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã hóa đơn";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên sách";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đơn giá";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mã sách";
            // 
            // cbxMaHDX
            // 
            this.cbxMaHDX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxMaHDX.FormattingEnabled = true;
            this.cbxMaHDX.Location = new System.Drawing.Point(143, 228);
            this.cbxMaHDX.Name = "cbxMaHDX";
            this.cbxMaHDX.Size = new System.Drawing.Size(121, 24);
            this.cbxMaHDX.TabIndex = 6;
            this.cbxMaHDX.SelectedIndexChanged += new System.EventHandler(this.cbxMaHDX_SelectedIndexChanged);
            // 
            // cbxTensach
            // 
            this.cbxTensach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxTensach.FormattingEnabled = true;
            this.cbxTensach.Location = new System.Drawing.Point(143, 277);
            this.cbxTensach.Name = "cbxTensach";
            this.cbxTensach.Size = new System.Drawing.Size(121, 24);
            this.cbxTensach.TabIndex = 7;
            this.cbxTensach.SelectedIndexChanged += new System.EventHandler(this.cbxMaSach_SelectedIndexChanged);
            this.cbxTensach.Validating += new System.ComponentModel.CancelEventHandler(this.cbxMaSach_Validating);
            // 
            // txtSL
            // 
            this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSL.Location = new System.Drawing.Point(143, 338);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(100, 22);
            this.txtSL.TabIndex = 8;
            this.txtSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtSL.Validating += new System.ComponentModel.CancelEventHandler(this.txtSL_Validating);
            // 
            // txtDG
            // 
            this.txtDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDG.Location = new System.Drawing.Point(143, 396);
            this.txtDG.Name = "txtDG";
            this.txtDG.Size = new System.Drawing.Size(100, 22);
            this.txtDG.TabIndex = 9;
            this.txtDG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDG_KeyPress);
            this.txtDG.Validating += new System.ComponentModel.CancelEventHandler(this.txtDG_Validating);
            // 
            // txtMasach
            // 
            this.txtMasach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMasach.Location = new System.Drawing.Point(439, 277);
            this.txtMasach.Name = "txtMasach";
            this.txtMasach.Size = new System.Drawing.Size(100, 22);
            this.txtMasach.TabIndex = 10;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(641, 232);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(641, 315);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(641, 396);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // sMaHDX
            // 
            this.sMaHDX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sMaHDX.DataPropertyName = "sMaHDX";
            this.sMaHDX.HeaderText = "Mã hóa đơn xuât";
            this.sMaHDX.MinimumWidth = 6;
            this.sMaHDX.Name = "sMaHDX";
            this.sMaHDX.ReadOnly = true;
            this.sMaHDX.Width = 107;
            // 
            // sMasach
            // 
            this.sMasach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sMasach.DataPropertyName = "sMasach";
            this.sMasach.HeaderText = "Mã sách";
            this.sMasach.MinimumWidth = 6;
            this.sMasach.Name = "sMasach";
            this.sMasach.ReadOnly = true;
            this.sMasach.Width = 83;
            // 
            // sTensach
            // 
            this.sTensach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sTensach.DataPropertyName = "Ten sach";
            this.sTensach.HeaderText = "Tên sách";
            this.sTensach.MinimumWidth = 6;
            this.sTensach.Name = "sTensach";
            this.sTensach.ReadOnly = true;
            // 
            // iSL
            // 
            this.iSL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iSL.DataPropertyName = "iSL";
            this.iSL.HeaderText = "Số lượng";
            this.iSL.MinimumWidth = 6;
            this.iSL.Name = "iSL";
            this.iSL.ReadOnly = true;
            // 
            // fDGban
            // 
            this.fDGban.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fDGban.DataPropertyName = "fDGban";
            this.fDGban.HeaderText = "Giá bán";
            this.fDGban.MinimumWidth = 6;
            this.fDGban.Name = "fDGban";
            this.fDGban.ReadOnly = true;
            this.fDGban.Width = 81;
            // 
            // tongtien
            // 
            this.tongtien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tongtien.DataPropertyName = "tong tien";
            this.tongtien.HeaderText = "Tổng tiền hóa đơn";
            this.tongtien.MinimumWidth = 6;
            this.tongtien.Name = "tongtien";
            this.tongtien.ReadOnly = true;
            this.tongtien.Width = 118;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // fmChiTietHoaDonXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMasach);
            this.Controls.Add(this.txtDG);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.cbxTensach);
            this.Controls.Add(this.cbxMaHDX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvChiTietHDX);
            this.Name = "fmChiTietHoaDonXuat";
            this.Text = "fmChiTietHoaDonXuat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmChiTietHoaDonXuat_FormClosing);
            this.Load += new System.EventHandler(this.fmChiTietHoaDonXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChiTietHDX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxMaHDX;
        private System.Windows.Forms.ComboBox cbxTensach;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtDG;
        private System.Windows.Forms.TextBox txtMasach;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaHDX;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMasach;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTensach;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn fDGban;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}