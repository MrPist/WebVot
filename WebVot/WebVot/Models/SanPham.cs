using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebVot.Models
{
    [Table("SanPham")]
    [Index("MaNcc", Name = "IX_SanPham_MaNCC")]
    [Index("MaNsx", Name = "IX_SanPham_MaNSX")]
    public partial class SanPham
    {
        public SanPham()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Column("MaSP")]
        [StringLength(15)]
        [Unicode(false)]
        public string MaSp { get; set; } = null!;
        [Column("TenSP")]
        [StringLength(50)]
        public string TenSp { get; set; } = null!;
        public int? Sluong { get; set; }
        [Column("MaNSX")]
        [StringLength(15)]
        [Unicode(false)]
        public string MaNsx { get; set; } = null!;
        [Column("MaNCC")]
        [StringLength(15)]
        [Unicode(false)]
        public string MaNcc { get; set; } = null!;
        [StringLength(50)]
        public string? Hinhanh { get; set; }
        public int GiaBan { get; set; }
        public int? GiaGoc { get; set; }

        [ForeignKey("MaNcc")]
        [InverseProperty("SanPhams")]
        public virtual Ncc MaNccNavigation { get; set; } = null!;
        [ForeignKey("MaNsx")]
        [InverseProperty("SanPhams")]
        public virtual Nsx MaNsxNavigation { get; set; } = null!;
        [InverseProperty("MaSpNavigation")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
        public object MatKhau { get; internal set; }
    }
}
