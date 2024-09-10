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
        List<SinhVien> DanhSach;

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
            string filename = "",line;
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
                 
            }

        }
    }
}
