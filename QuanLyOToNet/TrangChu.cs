using QuanLyOToNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyOToNet
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            QuanLy ql = new QuanLy();
            ql.Show();
            this.Hide();
        }

        private void btnQLK_Click(object sender, EventArgs e)
        {
            QuanLyKhoXe qlkx = new QuanLyKhoXe();
            qlkx.Show();
            this.Hide();
        }

        private void btnKM_Click(object sender, EventArgs e)
        {
            KhuyenMai km = new KhuyenMai();
            km.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            HeThong ht = new HeThong();
            ht.Show();
            this.Hide();
        }

        private void btnQuanLyXe_Click(object sender, EventArgs e)
        {
            Xe x = new Xe();
            x.Show();
            this.Hide();
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
            this.Hide();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();   
            nv.Show();
            this.Hide();
        }

        private void btnBaoHanh_Click(object sender, EventArgs e)
        {
            BaoHanh bh = new BaoHanh();
            bh.Show();
            this.Hide();
        }

        private void btnQLNCC_Click(object sender, EventArgs e)
        {
            NCC ncc = new NCC();
            ncc.Show();
            this.Hide();
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.Show();
            this.Hide();
        }
    }
}
