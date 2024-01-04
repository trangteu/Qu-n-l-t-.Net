using QuanLyOToNet;
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
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from KhuyenMai where TenCTKM like N'%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQuanLy.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                conn.Open();
                string query = "select * from QuanLy";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQuanLy.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuanLy_Load(object sender, EventArgs e)
        {
            getdata();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaQL.Text;
                string a1 = txtTenQL.Text;
                string a2 = txtMaNV.Text;
                string a3 = txtMaNCC.Text;
                string a4 = txtMaXe.Text;
                string a5 = txtDiachi.Text;
                string a6 = txtSDT.Text;
                string a7 = cbbChucVu.Text;
                string query = String.Format("insert into QuanLy( MaQL, TenQL, MaNV, MaNCC, MaXe, DiaChi, SDT, ChucVu) " +
                    "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')", a0, a1, a2, a3, a4, a5, a6, a7);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Thêm Quản Lý Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Thêm Quản lý Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaQL.Text;
                string a1 = txtTenQL.Text;
                string a2 = txtMaNV.Text;
                string a3 = txtMaNCC.Text;
                string a4 = txtMaXe.Text;
                string a5 = txtDiachi.Text;
                string a6 = txtSDT.Text;
                string a7 = cbbChucVu.Text;
                if (txtMaQL.Text.Length == 0 || txtTenQL.Text.Length == 0 || txtMaNV.Text.Length == 0 || txtMaNCC.Text.Length == 0 || txtMaXe.Text.Length == 0 || txtDiachi.Text.Length == 0 || txtSDT.Text.Length == 0 || cbbChucVu.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaQL.Focus();
                    txtTenQL.Focus();
                    txtMaNV.Focus();
                    txtMaNCC.Focus();
                    txtMaXe.Focus();
                    txtDiachi.Focus();
                    txtSDT.Focus();
                    cbbChucVu.Focus();
                    return;
                }
                string query = String.Format("update QuanLy set TenQL = N'{1}', MaNV = N'{2}', MaNCC = N'{3}', MaXe = N'{4}', DiaChi = N'{5}', SDT = N'{6}', ChucVu = N'{7}' where MaQL = N'{0}'", a0, a1, a2, a3, a4, a5, a6, a7);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Cập nhật Quản Lý thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Cập nhật Quản Lý thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();

                string query = String.Format("delete QuanLy where MaQL = '" + txtMaQL.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Xoa Quan lý Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Xóa Quản lý Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from QuanLy where TenQL like N'%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQuanLy.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            tc.Show();
            this.Hide();
        }

        private void dgvQuanLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvQuanLy.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaQL.Text = row.Cells[0].Value.ToString();
                txtTenQL.Text = row.Cells[1].Value.ToString();
                txtMaNV.Text = row.Cells[2].Value.ToString();
                txtMaNCC.Text = row.Cells[3].Value.ToString();
                txtMaXe.Text = row.Cells[4].Value.ToString();
                txtDiachi.Text = row.Cells[5].Value.ToString();
                txtSDT.Text = row.Cells[6].Value.ToString();
                cbbChucVu.Text = row.Cells[7].Value.ToString();
            }
            //txtMaKhachHang.Enabled = false;
        }

        private void btnHienThi_Click_1(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
