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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace QuanLyOToNet
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

       

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=DoAn.Net;Integrated Security=True");

            try
            {
                conn.Open();
                string query = string.Format("select * from HoaDon");
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvHoaDon.DataSource = table;
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
                string mahd = txtMaHoaDon.Text;
                string maxe = txtMaXe.Text;
                string tenhd = txtTenHoaDon.Text;
                DateTime thoigian = txtThoiGian.Value;
                string dongia = txtDonGia.Text;
                string thanhtien = txtThanhTien.Text;

                string query = string.Format("insert into HoaDon(MaHD,MaXe,TenHD,ThoiGian,DonGia,ThanhTien)" + "values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", mahd, maxe, tenhd,thoigian,dongia, thanhtien);
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
                string mahd = txtMaHoaDon.Text;
                string maxe = txtMaXe.Text;
                string tenhd = txtTenHoaDon.Text;
                DateTime thoigian = txtThoiGian.Value;
                string dongia = txtDonGia.Text;
                string thanhtien = txtThanhTien.Text;

                string query = string.Format("update HoaDon  set MaXe = N'{1}', TenHD = N'{2}', ThoiGian = N'{3}', DonGia = N'{4}', ThanhTien = N'{5}' where MaHD = N'{0}'", mahd, maxe, tenhd,thoigian,dongia, thanhtien);
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
                string mahd = txtMaHoaDon.Text;
                string maxe = txtMaXe.Text;
                string tenhd = txtTenHoaDon.Text;
                DateTime thoigian = txtThoiGian.Value;
                string dongia = txtDonGia.Text;
                string thanhtien = txtThanhTien.Text;

                string query = string.Format("delete from HoaDon where MaHD = N'{0}'", mahd);
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
                string query = string.Format("select * from HoaDon where MaHD like N'%{0}%'", txtTimKiem.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvHoaDon.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvHoaDon.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaHoaDon.Text = row.Cells[0].Value.ToString();
                txtMaXe.Text = row.Cells[1].Value.ToString();
                txtTenHoaDon.Text = row.Cells[2].Value.ToString();
                txtThoiGian.Text = row.Cells[3].Value.ToString();
                txtDonGia.Text = row.Cells[4].Value.ToString();
                txtSoLuong.Text = row.Cells[5].Value.ToString();
                txtThanhTien.Text = row.Cells[6].Value.ToString();
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            string sl = txtSoLuong.Text;
            string gt = txtDonGia.Text;

            int a = int.Parse(sl);
            int b = int.Parse(gt);

            int c = a * b;
            txtThanhTien.Text = Convert.ToString(c);
        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            ////khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            //Microsoft.Office.Interop.Excel.Application excel;
            //Microsoft.Office.Interop.Excel.Workbook workbook;
            //Microsoft.Office.Interop.Excel.Worksheet worksheet;
            //try
            //{
            //    //Tạo đối tượng COM.
            //    excel = new Microsoft.Office.Interop.Excel.Application();
            //    excel.Visible = false;
            //    excel.DisplayAlerts = false;
            //    //tạo mới một Workbooks bằng phương thức add()
            //    workbook = excel.Workbooks.Add(Type.Missing);
            //    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
            //    //đặt tên cho sheet
            //    worksheet.Name = "Quản lý hóa đơn";

            //    // export header trong DataGridView
            //    for (int i = 0; i < dataGridView1.ColumnCount; i++)
            //    {
            //        worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            //    }
            //    // export nội dung trong DataGridView
            //    for (int i = 0; i < dataGridView1.RowCount; i++)
            //    {
            //        for (int j = 0; j < dataGridView1.ColumnCount; j++)
            //        {
            //            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //    // sử dụng phương thức SaveAs() để lưu workbook với filename
            //    workbook.SaveAs(fileName);
            //    //đóng workbook
            //    workbook.Close();
            //    excel.Quit();
            //    MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    workbook = null;
            //    worksheet = null;
            //}
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dgvHoaDon.Columns.Count);
                            pdfTable.DefaultCell.Padding = 4;
                            pdfTable.WidthPercentage = 95;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgvHoaDon.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvHoaDon.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 20f, 8f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrangChu gdc = new TrangChu();
            gdc.Show();
            this.Hide();
        }
    }
}
