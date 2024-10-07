using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace _2212366_BTHieu_Lab3
{
    public delegate int SoSanh(object sv1, object sv2);
    internal class QuanLySinhVien

    {
        public List<SinhVien> DanhSach;

        public QuanLySinhVien()
        {
             DanhSach = new List<SinhVien> ();

        }

        public SinhVien this[int index]
        {
            get
            {
                return DanhSach[index];
            }

            set
            {
                DanhSach[index] = value;
            }
        }

        public void Them(SinhVien sv)
        {
            DanhSach.Add(sv);
        }

        public SinhVien Tim ( object obj , SoSanh ss)
        {
            SinhVien result = null;
            foreach (SinhVien sv in DanhSach)
            {
                if (ss(sv,obj)==0)
                {
                    result = sv;
                    break;
                }
            }
            return result;
        }

        public void Xoa ( object obj , SoSanh ss)
        {
            for (int i = 0; i < DanhSach.Count - 1; i++) 
            {
                if (ss(DanhSach[i],obj)==0)
                {
                    DanhSach.RemoveAt(i);
                    break;
                }
            }
        }
        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            //foreach (SinhVien sv in DanhSach)
            //{
            //    if (ss(sv,obj )== 0)
            //    {
            //        sv = svsua;
            //        break;
            //    }
            //}
            bool kq = false;
            for (int i = 0; i < DanhSach.Count - 1; i++)
            {
                if (ss(DanhSach[i], obj) == 0)
                {
                    DanhSach[i] = svsua;
                    kq = true;
                }
            }
            return kq;
        }

        public void DocTuFile()
        {
            //string filename = "D:\\Lâp trình ứng dụng desktop\\10-7\\2212366_Lab3-main\\2212366_Lab3-main\\2212366_BTHieu_Lab3\\2212366_BTHieu_Lab3\\ds.txt",
            string filename = "ds2.txt",
                line; // biến được gán khi đọc từng dòng
            FileStream file = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(file);
            string[] chuoi;
            SinhVien sv;
            
            while (( line = sr.ReadLine())!=null) 
            {
                chuoi = line.Split(';');
                sv= new SinhVien();
                sv.MaSo = chuoi[0];
                sv.HoTen = chuoi[1];
                sv.NgaySinh = DateTime.Parse(chuoi[2]);
                sv.DiaChi = chuoi[3];   
                sv.Lop = chuoi[4];  
                sv.Hinh = chuoi[5];
                sv.GioiTinh = false;
                if (chuoi[6] == "1" )
                {
                    sv.GioiTinh = true;
                }
                string[] cn = chuoi[7].Split(',');
                sv.ChuyenNganh = new List<string>();
                foreach (var item in cn )
                {
                    sv.ChuyenNganh.Add(item);
                }

                this.Them(sv);            
            }

        }
        // DocTuFile (StreamReader sr = new StreamReader(file))
        //          _file la 1 FileStream khởi tạo cần string tenFile và FileMode.Open
        //          _ Doc tung dong sr.ReadLine() cho tới khi Null
        //          _ Tung dong do se split ra thanh phan 

        public override string ToString()
        {
            string s = "UI";
            foreach (var item in DanhSach)
            {
                s+= item.ToString() + "\n";
            }
            return s;
        }
    }
}
