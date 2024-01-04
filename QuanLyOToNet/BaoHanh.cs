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
    public partial class BaoHanh : Form
    {
        public BaoHanh()
        {
            InitializeComponent();
        }

        public void getData()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = string.Format("select * from BaoHanh");
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvbh.DataSource = table;
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
                string mabh = txtmabh.Text;
                string tct = txttenctbh.Text;
                string tenxe = txttenxebh.Text;
                string tienbh = txttenxebh.Text;
                string dk = txtdk.Text;

                string query = string.Format("insert into BaoHanh(MaBH, TenCongTyBaoHanh, TenXeBaoHanh, TienBaoHanh, CacDieuKien)" + "values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", mabh,tct, tenxe, tienbh, dk);
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
     
        private void BaoHanh_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvbh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string mabh = txtmabh.Text;
                string tct = txttenctbh.Text;
                string tenxe = txttenxebh.Text;
                string tienbh = txttenxebh.Text;
                string dk = txtdk.Text;

                string query = string.Format("update BaoHanh set TenCongTyBaoHanh = N'{1}', TenXeBaoHanh = N'{2}', TienBaoHanh = N'{3}', CacDieuKien = N'{4}' where MaBH = N'{0}'", mabh, tct, tenxe, tienbh, dk);
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
                string mabh = txtmabh.Text;
                string tct = txttenctbh.Text;
                string tenxe = txttenxebh.Text;
                string tienbh = txttenxebh.Text;
                string dk = txtdk.Text; ;

                string query = string.Format("delete from BaoHanh where MaBH = N'{0}'", mabh);
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
                string query = string.Format("select * from BaoHanh where MaBH like N'%{0}%'", txtTimKiem.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvbh.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void dgvbh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvbh.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtmabh.Text = row.Cells[0].Value.ToString();
                txttenctbh.Text = row.Cells[1].Value.ToString();
                txttenxebh.Text = row.Cells[2].Value.ToString();
                txttienbh.Text = row.Cells[3].Value.ToString();
                txtdk.Text = row.Cells[4].Value.ToString();
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
