using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyBanHang26_NguyenQuangHuy26.Common.Req
{
    public class UserReq
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
