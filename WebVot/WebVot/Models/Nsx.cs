using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebVot.Models
{
    [Table("NSX")]
    public partial class Nsx
    {
        public Nsx()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("MaNSX")]
        [StringLength(15)]
        [Unicode(false)]
        public string MaNsx { get; set; } = null!;
        [Column("TenNSX")]
        [StringLength(50)]
        public string TenNsx { get; set; } = null!;

        [InverseProperty("MaNsxNavigation")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
