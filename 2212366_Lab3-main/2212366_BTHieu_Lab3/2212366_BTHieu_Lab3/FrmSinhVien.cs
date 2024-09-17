using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2212366_BTHieu_Lab3
{
    public partial class FrmSinhVien : Form
    {
        QuanLySinhVien qlsv;
        public FrmSinhVien()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            label9.Text = GetSinhVien().ToString();
        }

        // Lay thong tin tu control

        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = mtxtMaSo.Text;
            sv.HoTen = txtHoTen.Text;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.DiaChi = txtDiaChi.Text;
            sv.Lop = cboLop.Text;
            sv.GioiTinh = false;
            sv.Hinh = txtHinh.Text;
            if (rdNam.Checked)
            {
                sv.GioiTinh = true;
            }
            List<string> cn = new List<string>();
            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
            {
                if (clbChuyenNganh.GetItemChecked(i)) // == true
                {
                    cn.Add(clbChuyenNganh.Items[i].ToString());
                }
            }

            //foreach (string item in clbChuyenNganh.CheckedItems)
            //{
            //    cn.Add(item.ToString());
            //}

            sv.ChuyenNganh = cn; // ko chuyen truc tiep duoc

            return sv; 

        }

        private SinhVien GetSVListView(ListViewItem lvitem )
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.DiaChi = txtDiaChi.Text;
            sv.Lop = cboLop.Text;
            sv.GioiTinh = false;
            sv.Hinh = txtHinh.Text;
            if (rdNam.Checked)
            {
                sv.GioiTinh = true;
            }
            List<string> cn = new List<string>();
            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
            {
                if (clbChuyenNganh.GetItemChecked(i)) // == true
                {
                    cn.Add(clbChuyenNganh.Items[i].ToString());
                }
            }

            return sv; 

        }
        
    }
}
