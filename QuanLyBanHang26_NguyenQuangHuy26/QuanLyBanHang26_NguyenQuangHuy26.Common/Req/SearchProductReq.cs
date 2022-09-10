using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyBanHang26_NguyenQuangHuy26.Common.Req
{
    public class SearchProductReq
    {
        public string Keyword { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}