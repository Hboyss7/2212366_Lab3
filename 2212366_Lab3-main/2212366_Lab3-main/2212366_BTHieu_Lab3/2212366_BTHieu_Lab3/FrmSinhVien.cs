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

        // Khi bấm click sẽ lấy thông tin mà người dùng nhập vào control
        // sau đó sẽ kiểm tra nếu phù hợp thì
        // lưu vào ds sau đó từ mới hiển thị listView từ ds
        private SinhVien GetControl()
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = mtxtMaSo.Text;
            sv.HoTen = txtHoTen.Text;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.DiaChi = txtDiaChi.Text;
            sv.Lop = cboLop.Text;
            sv.Hinh = txtHinh.Text;
            sv.GioiTinh = true;
            if (rdNu.Checked)
            {
                sv.GioiTinh = false;
            }
            sv.ChuyenNganh = new List<string>();

            // C1 CheckListBox có GetItemChecked(int index) để kiểm tra vị trí đã check hay chưa, nếu checked thì add
            // vì tham số là int nên ta phải dùng for
            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
            {
                if (clbChuyenNganh.GetItemChecked(i)) 
                {
                    sv.ChuyenNganh.Add(clbChuyenNganh.Items[i].ToString());
                            // Thêm phần tử thứ i và chuyển nó thành string 
                }
            }

            // C2 CheckListBox có CheckedItems là danh sách items dc checked nên ta add lun
            foreach (var item in clbChuyenNganh.CheckedItems)
            {
                sv.ChuyenNganh.Add(item.ToString());
            }

            return sv;
        }

       
        // Nhấn click dữ liệu sẽ chuyển sang ListView
        private void btnThem_Click(object sender, EventArgs e)
        {
            label10.Text = GetControl().ToString();
        }

        // Khi tải form thì hiện dssv lên ListView
        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadListView();
        }

        // Thêm từng sv lên ListView từ dssv
        // Danh sách ListView có collection là ListViewItem
        // Mỗi ListViewItem là 1 dòng, 1 dòng này là danh sách (SubItems)
        // Mỗi phần tử trong SubItems là 1 thuộc tính
        // SubItems có thể add string nên ta phải chuyển thuộc tính thành string

        private void ThemListView(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            
            lvitem.SubItems.Add(sv.HoTen);
            lvitem.SubItems.Add(sv.NgaySinh.ToString());
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Lop);
            string gt = "Nữ";
            if (sv.GioiTinh)
            {
                gt = "Nam";
            }
            lvitem.SubItems.Add(gt); // add string

            // Đối với List<string> cần add tất cả item vào 1 SubItems
            string cn = "";
            foreach (string item in sv.ChuyenNganh) // cần thêm dấu ,
            {
                cn += item + ", ";
            }
            cn = cn.Substring(0, cn.Length - 3);
            lvitem.SubItems.Add(cn);
            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);
        }

        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (var item in qlsv.DanhSach)
            {
                ThemListView(item);
            }
        }

        //Khi bấm sẽ Get vào SV sau đó sẽ hiển thị lên control
        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetListView(lvitem);
                ThietLapControl(sv);
            }
        }

        // Lấy thông tin của dòng nào (ListViewItem) để hiển thị lên Control
        
        // 
        // Trong ListViewItem có SubItems (collection)

        private SinhVien GetListView(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[2].Text);
            sv.DiaChi = lvitem.SubItems[3].Text;
            sv.Lop = lvitem.SubItems[4].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[5].Text == "Nam")
            {
                sv.GioiTinh = true;
            }
            sv.ChuyenNganh = new List<string>();
            string[] cn = lvitem.SubItems[5].Text.Split(',');
            foreach (var item in cn)
            {
                sv.ChuyenNganh.Add(item);
            }
            sv.Hinh = lvitem.SubItems[7].Text;
            return sv;

        }
        
        private void ThietLapControl(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MaSo;
            this.txtHoTen.Text = sv.HoTen;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cboLop.Text = sv.Lop;
            this.txtHinh.Text = sv.Hinh;
            this.rdNam.Checked = true;
            if (sv.GioiTinh == false)
            {
                this.rdNu.Checked = true;
            }
            // So sánh cn với từng phần tử trong ListCheckedBox nếu giống nhau (=0)
            // Sử dụng SetItemChecked(i, true/ false) để đặt phần tử nào set

            foreach (var item in sv.ChuyenNganh)
            {
                for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                {
                    if (item.CompareTo(this.clbChuyenNganh.Items[i])==0)
                    {
                        this.clbChuyenNganh.SetItemChecked(i, true);
                    }
                }
            }

        }

    }
}
