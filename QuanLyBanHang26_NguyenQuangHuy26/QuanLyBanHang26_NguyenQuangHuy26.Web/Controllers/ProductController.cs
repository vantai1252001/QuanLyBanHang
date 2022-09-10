using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang26_NguyenQuangHuy26.BLL;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Req;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using QuanLyBanHang26_NguyenQuangHuy26.Common.BLL;
using QuanLyBanHang26_NguyenQuangHuy26.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang26_NguyenQuangHuy26.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllProduct()
        {
            var res = new SingleRsp();
            res.Data = productSvc.All;
            return Ok(res);
        }


        [HttpPut("Update-Product")]
        public IActionResult UpdateProduct([FromBody]ProductReq productReq)
        {         
                var res = productSvc.UpdateProduct(productReq);
                return Ok(res);
        }
        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductReq reqProduct)
        {
            var res = productSvc.CreateProduct(reqProduct);
            return Ok(res);
        }
        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }

        [HttpDelete("Delete-Product")]
        public IActionResult DeleteProduct(int id)
        {
            SalesManagerContext context = new SalesManagerContext();
            var pr = productSvc.Read(id);
            context.Remove(pr.Data);
            context.SaveChanges();
            return Ok(pr);
        }
    }
}