using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebVot.Models
{
    [Table("DonHang")]
    [Index("MaSp", Name = "IX_DonHang_MaSP")]
    [Index("Username", Name = "IX_DonHang_username")]
    public partial class DonHang
    {
        [Key]
        [Column("MaDH")]
        [StringLength(15)]
        [Unicode(false)]
        public string MaDh { get; set; } = null!;
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; } = null!;
        [Column("MaSP")]
        [StringLength(15)]
        [Unicode(false)]
        public string MaSp { get; set; } = null!;
        public int? ThanhTien { get; set; }

        [ForeignKey("MaSp")]
        [InverseProperty("DonHangs")]
        public virtual SanPham MaSpNavigation { get; set; } = null!;
        [ForeignKey("Username")]
        [InverseProperty("DonHangs")]
        public virtual TaiKhoan UsernameNavigation { get; set; } = null!;
    }
}
