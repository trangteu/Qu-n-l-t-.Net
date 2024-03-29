﻿using System;
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
    public partial class NCC : Form
    {
        public NCC()
        {
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string query = string.Format("select * from NhaCungCap");
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvncc.DataSource = table;
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
                string mancc = txtmaNCC.Text;
                string mabh = txtmaBH.Text;
                string tenncc = txtTenNCC.Text;
                string dd = txtdiadiem.Text;

                string query = string.Format("insert into NhaCungCap(MaNCC, MaBH, TenNCC, DiaDiem)" + "values (N'{0}',N'{1}',N'{2}',N'{3}')", mancc, mabh, tenncc, dd);
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


        private void NCC_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");
            try
            {
                conn.Open();
                string mancc = txtmaNCC.Text;         
                string mabh = txtmaBH.Text;
                string tenncc = txtTenNCC.Text;
                string dd = txtdiadiem.Text;

                string query = string.Format("update NhaCungCap set  MaBH = N'{1}', TenNCC = N'{2}', DiaDiem = N'{3}' where MaNCC = N'{0}'", mancc ,mabh, tenncc, dd);
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
                string mancc = txtmaNCC.Text;
                string mabh = txtmaBH.Text;
                string tenncc = txtTenNCC.Text;
                string dd = txtdiadiem.Text;

                string query = string.Format("delete from NhaCungCap where MaNCC = N'{0}'", mancc);
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
                string query = string.Format("select * from NhaCungCap where MaNCC like N'%{0}%'", txtTimKiem.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvncc.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void dgvncc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvncc.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtmaNCC.Text = row.Cells[0].Value.ToString();
                txtmaBH.Text = row.Cells[1].Value.ToString();
                txtTenNCC.Text = row.Cells[2].Value.ToString();
                txtdiadiem.Text = row.Cells[3].Value.ToString();
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
