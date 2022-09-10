using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyBanHang26_NguyenQuangHuy26.BLL;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Req;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;

namespace QuanLyBanHang26_NguyenQuangHuy26.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }
        [HttpPost("get-by-id")]
        public IActionResult GetCategoryByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(simpleReq.Id);
            return Ok(res);
        }
        [HttpPost("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }
        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.CreateCategory(categoryReq);
            return Ok(res);
        }
        [HttpPut("Update-Category")]
        public IActionResult UpdateProduct([FromBody] CategoryReq categoryReq)
        {
            var res = categorySvc.UpdateCategory(categoryReq);
            return Ok(res);
        }

        [HttpDelete("Delete-Category-ByID")]
        public IActionResult DeleteCategory(int id)
        {
            SalesManagerContext context = new SalesManagerContext();
            var pr = categorySvc.Read(id);
            context.Remove(pr.Data);
            context.SaveChanges();
            return Ok(pr);
        }
        [HttpPost("search-cate")]
        public IActionResult SearchCate([FromBody] SearchCateByName searchCateByName)
        {
            var res = new SingleRsp();
            res = categorySvc.SearchCategory(searchCateByName);
            return Ok(res);
        }
    }
}
