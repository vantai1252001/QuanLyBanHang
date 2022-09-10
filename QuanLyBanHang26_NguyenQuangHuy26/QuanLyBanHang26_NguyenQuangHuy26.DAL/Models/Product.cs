﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHang26_NguyenQuangHuy26.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }

        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
