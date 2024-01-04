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
    public partial class GiaoDienXe : Form
    {
        public GiaoDienXe()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");

            try
            {
                conn.Open();
                string query = string.Format("select * from QuanLyXe");
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvXe.DataSource = table;
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
                string maxe = txtMaXe.Text;
                string tenxe = txtTenXe.Text;
                string xuatxu = txtXuatXu.Text;
                string mausac = txtMauSac.Text;
                string loaixe = txtLoaiXe.Text;

                string query = string.Format("insert into QuanLyXe(MaXe,TenXe,XuatXu,MauSac,LoaiXe)" + "values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", maxe, tenxe,xuatxu, mausac,loaixe);
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
                string maxe = txtMaXe.Text;
                string tenxe = txtTenXe.Text;
                string xuatxu = txtXuatXu.Text;
                string mausac = txtMauSac.Text;
                string loaixe = txtLoaiXe.Text;

                string query = string.Format("update QuanLyXe  set TenXe = N'{1}', XuatXu = N'{2}', MauSac = N'{3}', LoaiXe = N'{4}' where MaXe = N'{0}'", maxe, tenxe, xuatxu, mausac, loaixe);
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
                string maxe = txtMaXe.Text;
                string tenxe = txtTenXe.Text;
                string xuatxu = txtXuatXu.Text;
                string mausac = txtMauSac.Text;
                string loaixe = txtLoaiXe.Text;

                string query = string.Format("delete from QuanLyXe where MaXe = N'{0}'", maxe);
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
                string query = string.Format("select * from QuanLyXe where TenXe like N'%{0}%'", txtTimKiem.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvXe.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }

        }

        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvXe.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaXe.Text = row.Cells[0].Value.ToString();
                txtTenXe.Text = row.Cells[1].Value.ToString();
                txtXuatXu.Text = row.Cells[2].Value.ToString();
                txtMauSac.Text = row.Cells[3].Value.ToString();
                txtLoaiXe.Text = row.Cells[4].Value.ToString();
            }
        }

        private void GiaoDienXe_Load(object sender, EventArgs e)
        {

        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();          
            tc.Show();
            this.Hide();
          
        }
    }
}
