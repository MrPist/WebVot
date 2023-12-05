using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebVot.Models
{
    [Table("NCC")]
    public partial class Ncc
    {
        public Ncc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("MaNCC")]
        [StringLength(15)]
        [Unicode(false)]
        public string MaNcc { get; set; } = null!;
        [Column("TenNCC")]
        [StringLength(50)]
        public string? TenNcc { get; set; }
        [StringLength(50)]
        public string? DiaChi { get; set; }
        [Column("sdt")]
        public int? Sdt { get; set; }

        [InverseProperty("MaNccNavigation")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
