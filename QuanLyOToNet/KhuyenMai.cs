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
    public partial class KhuyenMai : Form
    {
        public KhuyenMai()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from Kho where MaKho like N'%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKM.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                conn.Open();
                string query = "select * from KhuyenMai";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKM.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     

        private void KhuyenMai_Load(object sender, EventArgs e)
        {
            getdata();
            dgvKM.Columns[0].Width = 210;
            dgvKM.Columns[1].Width = 210;
            dgvKM.Columns[2].Width = 205;
            dgvKM.Columns[3].Width = 210;
            dgvKM.Columns[4].Width = 205;
        }


        private void btnHienThi_Click(object sender, EventArgs e)
        {
            getdata();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaKM.Text;
                string a1 = txtTenCTKM.Text;
                string a2 = txtSoLuong.Text;
                string a3 = tgbd.Text;
                string a4 = tgkt.Text;
                string query = String.Format("insert into KhuyenMai( MaKM, TenCTKM, SoLuong, ThoiGianBatDau, ThoiGianKetThuc) " +
                    "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", a0, a1, a2, a3, a4);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    MessageBox.Show("Tem KM thanh cong ");
                    getdata();
                }
                else
                    MessageBox.Show("Them KM khong thanh cong");
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
                string a0 = txtMaKM.Text;
                string a1 = txtTenCTKM.Text;
                string a2 = txtSoLuong.Text;
                string a3 = tgbd.Text;
                string a4 = tgkt.Text;
                if (txtMaKM.Text.Length == 0 || txtTenCTKM.Text.Length == 0 || txtSoLuong.Text.Length == 0 || tgbd.Text.Length == 0 || tgkt.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaKM.Focus();
                    txtTenCTKM.Focus();
                    txtSoLuong.Focus();
                    tgbd.Focus();
                    tgkt.Focus();
                    return;
                }
                string query = String.Format("update KhuyenMai set TenCTKM = N'{1}', SoLuong = N'{2}', ThoiGianBatDau = N'{3}', ThoiGianKetThuc = N'{4}' where MaKM = N'{0}'", a0, a1, a2, a3, a4);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    MessageBox.Show("Sưa Thông Tin Khuyen mai Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getdata();
                }
                else
                    MessageBox.Show("Sửa Thông Tin Khuyen Mai Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                string query = String.Format("delete KhuyenMai where MaKM = '" + txtMaKM.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Xoa Thông Tin KM Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Xóa Thông Tin KM Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     

        private void btnBack_Click(object sender, EventArgs e)
        {
            TrangChu gdc = new TrangChu();
            gdc.Show();
            this.Hide();
        }

        private void dgvKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvKM.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaKM.Text = row.Cells[0].Value.ToString();
                txtTenCTKM.Text = row.Cells[1].Value.ToString();
                txtSoLuong.Text = row.Cells[2].Value.ToString();
                tgbd.Text = row.Cells[3].Value.ToString();
                tgkt.Text = row.Cells[4].Value.ToString();
            }
            //txtMaKhachHang.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from KhuyenMai where TenCTKM like N'%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKM.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
