using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang26_NguyenQuangHuy26.BLL;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Req;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang26_NguyenQuangHuy26.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private CompanySvc companySvc;
        public CompanyController()
        {
            companySvc = new CompanySvc();
        }
        [HttpPost("get-by-id")]
        public IActionResult GetCompanyID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = companySvc.Read(simpleReq.Id);
            return Ok(res);
        }
        [HttpPost("get-all")]
        public IActionResult getAllCompany()
        {
            var res = new SingleRsp();
            res.Data = companySvc.All;
            return Ok(res);
        }
        [HttpPost("create-company")]
        public IActionResult CreateCompany([FromBody] CompanyReq companyReq)
        {
            var res = new SingleRsp();
            res = companySvc.CreateCompany(companyReq);
            return Ok(res);
        }
        [HttpPut("Update-Company")]
        public IActionResult UpdateCompany([FromBody] CompanyReq companyReq)
        {
            var res = companySvc.UpdateCompany(companyReq);
            return Ok(res);
        }
        [HttpDelete("Delete-Company")]
        public IActionResult SortProduct(int id)
        {
            SalesManagerContext context = new SalesManagerContext();
            var pr =companySvc.Read(id);
            context.Remove(pr.Data);
            context.SaveChanges();
            return Ok(pr);
        }
    }
}
