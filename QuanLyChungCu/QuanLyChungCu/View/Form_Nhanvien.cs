using QuanLyChungCu.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChungCu.View
{
    public partial class Form_Nhanvien : Form
    {        
        public Form_Nhanvien()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            foreach (chucvu i in ChucvuBLL.Instance.GetAllChucvu())
            {
                cbxChucvu.Items.Add(new CBBItem
                {
                    Value = i.machucvu,
                    Text = i.tenchucvu
                });
            }
        }
        private void Form_Nhanvien_Load(object sender, EventArgs e)
        {
            DSNV();
        }
        void DSNV()
        {
            dgvDanhSachNhanVien.DataSource = BLL_Nhanvien.Instance.LayDSNV(); 
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            DSNV();
        }
        private void dgvDanhSachNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            txtMaNhanVien.Text = dgvDanhSachNhanVien.Rows[dong].Cells[0].Value.ToString();
            txtHoTen.Text = dgvDanhSachNhanVien.Rows[dong].Cells[1].Value.ToString();
            if (dgvDanhSachNhanVien.Rows[dong].Cells[2].Value.ToString() == "Nữ")
                rdbtnNu.Checked = true;
            else if (dgvDanhSachNhanVien.Rows[dong].Cells[2].Value.ToString() == "Nam")
                rdbtnNam.Checked = true;
            txtSoDienThoai.Text = dgvDanhSachNhanVien.Rows[dong].Cells[3].Value.ToString();
            dtpNgaySinh.Text = dgvDanhSachNhanVien.Rows[dong].Cells[4].Value.ToString();
            txtSoCMND.Text = dgvDanhSachNhanVien.Rows[dong].Cells[5].Value.ToString();
            cbxChucvu.Text = dgvDanhSachNhanVien.Rows[dong].Cells[6].Value.ToString();
            txtTenDangNhap.Text = dgvDanhSachNhanVien.Rows[dong].Cells[7].Value.ToString();
            txtMatKhau.Text = dgvDanhSachNhanVien.Rows[dong].Cells[8].Value.ToString();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "" || txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã nhân viên và tên đăng nhập!", "Cảnh báo");

            }
            else
            {
                nhanvien nv = new nhanvien();
                taikhoan tk = new taikhoan();
                nv.manhanvien = Convert.ToInt32(txtMaNhanVien.Text);
                nv.tennhanvien = txtHoTen.Text;
                if (rdbtnNam.Checked == true)
                    nv.gioitinh = "Nam";
                if (rdbtnNu.Checked == true)
                    nv.gioitinh = "Nữ";
                nv.sdt = txtSoDienThoai.Text;
                nv.cmnd = txtSoCMND.Text;
                nv.ngaysinh = dtpNgaySinh.Value;
                nv.machucvu = ((CBBItem)cbxChucvu.SelectedItem).Value;
                tk.manhanvien = Convert.ToInt32(txtMaNhanVien.Text);
                tk.tendangnhap = txtTenDangNhap.Text;
                tk.matkhau = txtMatKhau.Text;

                if (BLL_Nhanvien.Instance.Add_NV(nv) == true && BLL_TaiKhoan.Instance.Add_TK(tk) == true)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DSNV();
                }
                else
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachNhanVien.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvDanhSachNhanVien.SelectedRows.Count; i++)
                {
                    BLL_TaiKhoan.Instance.Delete_TK(Convert.ToInt32(dgvDanhSachNhanVien.SelectedRows[i].Cells["manhanvien"].Value));
                    BLL_Nhanvien.Instance.Delete_NV(Convert.ToInt32(dgvDanhSachNhanVien.SelectedRows[i].Cells["manhanvien"].Value));
                    
                }
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DSNV();
            }
            else
                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachNhanVien.SelectedRows.Count != 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 nhân viên", "Cảnh báo");

            }
            else
            {
                if (txtMaNhanVien.Text == "" || txtTenDangNhap.Text == "")
                {
                    MessageBox.Show("Vui lòng không được sửa mã nhân viên và tên đăng nhập!", "Cảnh báo");

                }
                else
                {
                    nhanvien nv = new nhanvien();
                    taikhoan tk = new taikhoan();
                    nv.manhanvien = Convert.ToInt32(txtMaNhanVien.Text);
                    nv.tennhanvien = txtHoTen.Text;
                    if (rdbtnNam.Checked == true)
                        nv.gioitinh = "Nam";
                    if (rdbtnNu.Checked == true)
                        nv.gioitinh = "Nữ";
                    nv.sdt = txtSoDienThoai.Text;
                    nv.cmnd = txtSoCMND.Text;
                    nv.ngaysinh = dtpNgaySinh.Value;
                    nv.machucvu = ((CBBItem)cbxChucvu.SelectedItem).Value;
                    tk.tendangnhap = txtTenDangNhap.Text;
                    tk.matkhau = txtMatKhau.Text;

                    if (BLL_Nhanvien.Instance.Edit_NV(nv) == true && BLL_TaiKhoan.Instance.Edit_TK(tk) == true)
                    {
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DSNV();
                    }
                    else
                        MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhSachNhanVien.DataSource = BLL_Nhanvien.Instance.GetListNVByTen(txbSearch.Text);
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txtMaNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtSoCMND.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            cbxChucvu.Text = "";
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSachNhanVien.DataSource = BLL_Nhanvien.Instance.GetListNVByTen(txbSearch.Text);
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }
    }
}
