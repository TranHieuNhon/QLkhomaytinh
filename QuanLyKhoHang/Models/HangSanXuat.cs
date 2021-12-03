using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyKhoHang.Models
{
    public partial class HangSanXuat
    {
        public HangSanXuat()
        {
            SanPham = new HashSet<SanPham>();
        }

        public string MaNxx { get; set; }
        public string TenNxx { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
