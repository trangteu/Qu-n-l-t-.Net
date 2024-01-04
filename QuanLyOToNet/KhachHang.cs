using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyOToNet
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = string.Format("select * from KhachHang");
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvkh.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string makh = txtmakh.Text;
                string mahd = txtmahd.Text;
                string tenkh = txttenkh.Text;
                string sdt = txtsdt.Text;
                string em = txtemail.Text;

                string query = string.Format("insert into KhachHang(MaKH, MaHD, TenKH,SDT, Email)" + "values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", makh, mahd,tenkh, sdt, em);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();

                if (s1 == 1)
                {
                    MessageBox.Show("Thêm thành công !");
                    getData();
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

        private void btnsua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string makh = txtmakh.Text;
                string mahd = txtmahd.Text;
                string tenkh = txttenkh.Text;
                string sdt = txtsdt.Text;
                string em = txtemail.Text;

                string query = string.Format("update KhachHang set MaHD = N'{1}', TenKH = N'{2}', SDT = N'{3}', Email = N'{4}' where MaKH = N'{0}'", makh, mahd, tenkh, sdt, em);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();

                if (s1 == 1)
                {
                    MessageBox.Show("Sửa thành công !");
                    getData();
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

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string makh = txtmakh.Text;
                string mahd = txtmahd.Text;
                string tenkh = txttenkh.Text;
                string sdt = txtsdt.Text;
                string em = txtemail.Text;

                string query = string.Format("delete from KhachHang where MaKH = N'{0}'", makh);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    MessageBox.Show("Xóa thành công !");
                    getData();
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

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = string.Format("select * from KhachHang where MaKH like N'%{0}%'", txtTimKiem.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvkh.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvkh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvkh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvkh.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtmakh.Text = row.Cells[0].Value.ToString();
                txtmahd.Text = row.Cells[1].Value.ToString();
                txttenkh.Text = row.Cells[2].Value.ToString();
                txtsdt.Text = row.Cells[3].Value.ToString();
                txtemail.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            tc.Show();
            this.Hide();
        }

    }
}
