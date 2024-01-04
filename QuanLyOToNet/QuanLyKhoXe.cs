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
    public partial class QuanLyKhoXe : Form
    {
        public QuanLyKhoXe()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from Kho";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKhoxe.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                string a0 = txtMaKho.Text;
                string a1 = txtSoLuongxe.Text;
                string a2 = txtTonKho.Text;
                string query = String.Format("insert into Kho( MaKho, SoLuongXe, TonKho) " +
                    "values (N'{0}', N'{1}', N'{2}')", a0, a1, a2);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    MessageBox.Show("Them Kho thanh cong ");
                    getdata();
                }
                else
                    MessageBox.Show("Them Kho khong thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void QuanLyKhoXe_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaKho.Text;
                string a1 = txtSoLuongxe.Text;
                string a2 = txtTonKho.Text;
                if (txtMaKho.Text.Length == 0 || txtSoLuongxe.Text.Length == 0 || txtTonKho.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaKho.Focus();
                    txtSoLuongxe.Focus();
                    txtTonKho.Focus();
                    return;
                }
                string query = String.Format("update Kho set SoLuongXe = N'{1}', TonKho = N'{2}' where MaKho = N'{0}'", a0, a1, a2);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    MessageBox.Show("Sưa Thông Tin Kho Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getdata();
                }
                else
                    MessageBox.Show("Sửa Thông Tin Kho Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                string query = String.Format("delete Kho where MaKho = '" + txtMaKho.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Xoa Thông Tin Kho Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Xóa Thông Tin Kho Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "select * from Kho where MaKho like N'%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKhoxe.DataSource = dt;
                conn.Close();
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

        private void dgvKhoxe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvKhoxe.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaKho.Text = row.Cells[0].Value.ToString();
                txtSoLuongxe.Text = row.Cells[1].Value.ToString();
                txtTonKho.Text = row.Cells[2].Value.ToString();
            }
            //txtMaKhachHang.Enabled = false;
        }
    }
}
