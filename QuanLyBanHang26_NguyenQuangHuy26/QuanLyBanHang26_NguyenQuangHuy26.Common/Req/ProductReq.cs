using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyBanHang26_NguyenQuangHuy26.Common.Req
{
    public class ProductReq
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }

    }
}
