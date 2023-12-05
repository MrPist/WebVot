using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebVot.Models
{
    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; } = null!;
        [Column("user_password")]
        [StringLength(30)]
        public string UserPassword { get; set; } = null!;

        [InverseProperty("UsernameNavigation")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
