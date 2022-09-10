using QuanLyBanHang26_NguyenQuangHuy26.Common.DAL;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang26_NguyenQuangHuy26.DAL
{
    public class UserRep : GenericRep<SalesManagerContext, User>
    {
        public UserRep()
        {

        }
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(c => c.UserId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.FirstOrDefault(i => i.UserId == id);
            m = base.Delete(m);
            return m.UserId;
        }
        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new SalesManagerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Add(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new SalesManagerContext())
            {

                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Update(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public List<User> SearchUser(string keyword)
        {
            return All.Where(x => x.FirstName.Contains(keyword)).ToList();
        }
    }
}