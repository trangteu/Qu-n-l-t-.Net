using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyOToNet
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");

            try
            {
                conn.Open();
                string query = string.Format("select * from NhanVien");
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvNhanVien.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");

            try
            {
                conn.Open();
                string manv = txtMaNhanVien.Text;
                string makho = txtMaKho.Text;
                string makh = txtMaKhachHang.Text;
                string makm = txtKhuyenMai.Text;
                string tennv = txtTenNhanVien.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtChucVu.Text;                       
                string chucvu = txtDiaChi.Text;
                string gioitinh = txtGioiTinh.Text;

                string query = string.Format("insert into NhanVien(MaNV,MaKho,MaKH,MaKM,TenNV,DiaChi,SDT,ChucVu,GioiTinh)" + "values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')", manv, makho, makh, makm, tennv, diachi,sdt,chucvu,gioitinh);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();

                if (s1 == 1)
                {
                    MessageBox.Show("Thêm thành công !");

                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");

            try
            {
                conn.Open();
                string manv = txtMaNhanVien.Text;
                string makho = txtMaKho.Text;
                string makh = txtMaKhachHang.Text;
                string makm = txtKhuyenMai.Text;
                string tennv = txtTenNhanVien.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtChucVu.Text;
                string chucvu = txtDiaChi.Text;
                string gioitinh = txtGioiTinh.Text;

                string query = string.Format("update NhanVien  set MaKho = N'{1}', MaKH = N'{2}', MaKM = N'{3}', TenNV = N'{4}', DiaChi = N'{5}', SDT = N'{6}', ChucVu = N'{7}', GioiTinh = N'{8}' where MaNV = N'{0}'", manv, makho, makh, makm, tennv, diachi, sdt, chucvu, gioitinh);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();

                if (s1 == 1)
                {
                    MessageBox.Show("Sửa thành công !");

                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");

            try
            {
                conn.Open();
                string manv = txtMaNhanVien.Text;
                string makho = txtMaKho.Text;
                string makh = txtMaKhachHang.Text;
                string makm = txtKhuyenMai.Text;
                string tennv = txtTenNhanVien.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtChucVu.Text;
                string chucvu = txtDiaChi.Text;
                string gioitinh = txtGioiTinh.Text;

                string query = string.Format("delete from NhanVien where MaNV = N'{0}'", manv);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();

                if (s1 == 1)
                {
                    MessageBox.Show("Xóa thành công !");

                }
                else
                {
                    MessageBox.Show("Xóa thất bại !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");

            try
            {
                conn.Open();
                string query = string.Format("select * from NhanVien where MaNV like N'%{0}%'", txtTimKiem.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvNhanVien.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvNhanVien.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaNhanVien.Text = row.Cells[0].Value.ToString();
                txtMaKho.Text = row.Cells[1].Value.ToString();
                txtMaKhachHang.Text = row.Cells[2].Value.ToString();
                txtKhuyenMai.Text = row.Cells[3].Value.ToString();
                txtTenNhanVien.Text = row.Cells[4].Value.ToString();
                txtGioiTinh.Text = row.Cells[8].Value.ToString();
                txtChucVu.Text = row.Cells[7].Value.ToString();
                txtDiaChi.Text = row.Cells[5].Value.ToString();
                txtSDT.Text = row.Cells[6].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrangChu gdc = new TrangChu();
            gdc.Show();
            this.Hide();
        }
    }
}
