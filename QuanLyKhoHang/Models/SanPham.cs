using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyKhoHang.Models
{
    public partial class SanPham
    {
        public string TenSp { get; set; }
        public string MaSp { get; set; }
        public string Idkho { get; set; }
        public string Slton { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string Idnpp { get; set; }
        public string Iddm { get; set; }
        public string Idhxx { get; set; }

        public virtual DanhMuc IddmNavigation { get; set; }
        public virtual HangSanXuat IdhxxNavigation { get; set; }
        public virtual KhoTonHang IdkhoNavigation { get; set; }
        public virtual NhaPhanPhoi IdnppNavigation { get; set; }
    }
}
