using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHang26_NguyenQuangHuy26.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
