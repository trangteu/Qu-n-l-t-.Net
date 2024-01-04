
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
    public partial class HeThong : Form
    {
        public HeThong()
        {
            InitializeComponent();
        }

      
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");

            try
            {
                conn.Open();
                string query = string.Format("select * from NguoiDung where Taikhoan = '" + txtTaiKhoan.Text + "'and Matkhau = '" + txtMatKhau.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader data = cmd.ExecuteReader();


                if (data.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công !");
                    TrangChu tc = new TrangChu();
                    tc.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            GiaoDienKetThuc tc = new GiaoDienKetThuc();
            tc.Show();
            this.Hide();
        }
    }
}
