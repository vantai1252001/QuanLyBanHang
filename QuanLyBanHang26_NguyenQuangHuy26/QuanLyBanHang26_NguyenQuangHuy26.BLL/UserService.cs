using QuanLyBanHang26_NguyenQuangHuy26.Common.BLL;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Req;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using QuanLyBanHang26_NguyenQuangHuy26.DAL;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyBanHang26_NguyenQuangHuy26.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep userRep;
        public UserSvc()
        {
            userRep = new UserRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        public override SingleRsp Update(User m)
        {
            var res = new SingleRsp();

            var m1 = m.UserId > 0 ? _rep.Read(m.UserId) : _rep.Read(m.FirstName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        public SingleRsp Remove(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Remove(id);
            return res;

        }
        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.LastName = userReq.LastName;
            user.FirstName = userReq.FirstName;
            user.BirthDay = userReq.BirthDay;
            user.Address = userReq.Address;
            user.Phone = userReq.Phone;
            res = userRep.CreateUser(user);
            return res;
        }
        public SingleRsp UpdateUser(UserReq userReq)
        {
            var res = new SingleRsp();

            User user = new User();
            user.UserId = userReq.UserId;
            user.LastName = userReq.LastName;
            user.FirstName = userReq.FirstName;
            user.BirthDay = userReq.BirthDay;
            user.Address = userReq.Address;
            user.Phone = userReq.Phone;
            res = userRep.UpdateUser(user);
            return res;
        }
        public SingleRsp SearchUser(SearchUserByFirstName searchUserByFirstName)
        {
            var res = new SingleRsp();
            //lay dssp theo keyword
            var cates = userRep.SearchUser(searchUserByFirstName.Keyword);
            res.Data = cates;
            return res;
        }
    }

}
