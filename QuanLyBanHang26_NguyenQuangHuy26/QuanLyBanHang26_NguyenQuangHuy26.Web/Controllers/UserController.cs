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
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;
        public UserController()
        {
            userSvc = new UserSvc();
        }
        [HttpPost("get-by-id")]
        public IActionResult GetUserByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = userSvc.Read(simpleReq.Id);
            return Ok(res);
        }
        [HttpPost("get-all")]
        public IActionResult getAllUsers()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;
            return Ok(res);
        }
        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.CreateUser(userReq);
            return Ok(res);
        }
        [HttpPut("Update-User")]
        public IActionResult UpdateUser([FromBody] UserReq userReq)
        {
            var res = userSvc.UpdateUser(userReq);
            return Ok(res);
        }

        [HttpDelete("Delete-User-ByID")]
        public IActionResult DeleteUser(int id)
        {
            SalesManagerContext context = new SalesManagerContext();
            var pr = userSvc.Read(id);
            context.Remove(pr.Data);
            context.SaveChanges();
            return Ok(pr);
        }
        [HttpPost("search-user")]
        public IActionResult SearchCate([FromBody] SearchUserByFirstName searchUserByFirstName)
        {
            var res = new SingleRsp();
            res = userSvc.SearchUser(searchUserByFirstName);
            return Ok(res);
        }
    }
}