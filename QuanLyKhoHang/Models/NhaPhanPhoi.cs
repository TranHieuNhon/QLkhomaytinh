using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyKhoHang.Models
{
    public partial class NhaPhanPhoi
    {
        public NhaPhanPhoi()
        {
            SanPham = new HashSet<SanPham>();
        }

        public string MaNpp { get; set; }
        public string TenNpp { get; set; }
        public string Qg { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
