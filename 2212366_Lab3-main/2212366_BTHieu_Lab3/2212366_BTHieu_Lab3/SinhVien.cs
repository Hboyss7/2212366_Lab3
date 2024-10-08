﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2212366_BTHieu_Lab3
{
    internal class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Lop { get; set; }     
        public string Hinh { get; set; }    
        public bool GioiTinh { get; set; }       
        public List<string> ChuyenNganh { get; set; }
        public SinhVien()
        {
                
        }

        public SinhVien(string ms, string lop, string ht, string hinh, string dc, DateTime ns, bool gt, List<string> cn)
        {
            this.MaSo = ms;
            this.HoTen = ht;
            this.NgaySinh = ns;
            this.DiaChi = dc;
            this.Lop = lop;   
            this.Hinh = hinh;                 
            this.GioiTinh = gt;
            this.ChuyenNganh = cn;
        }


    }
}
