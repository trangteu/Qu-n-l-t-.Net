using QuanLyCuaHangOTo;
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
    public partial class Xe : Form
    {
        public Xe()
        {
            InitializeComponent();
        }

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm); 
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XePorsche());
            label1.Text = btn01.Text;
        }

        private void btn02_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XeBugatti());
            label1.Text = btn02.Text;
        }

        private void btn03_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XeMayBach());
            label1.Text = btn03.Text;
        }

        private void btn04_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XeLexus());
            label1.Text = btn04.Text;
        }

        private void btn05_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XeBently());
            label1.Text = btn05.Text;
        }

        private void btn06_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XeFerrari());
            label1.Text = btn06.Text;
        }

        private void btnThongtinxe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GiaoDienXe());
            label1.Text = btnThongtinxe.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            label1.Text = "Trang chủ";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
