using QuanLyBanHang26_NguyenQuangHuy26.Common.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using System.Linq;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;

namespace QuanLyBanHang26_NguyenQuangHuy26.DAL
{
    public class CategoryRep:GenericRep<SalesManagerContext,Category>
    {
        public CategoryRep()
        {

        }
        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(c => c.CategoryId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.FirstOrDefault(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }
        public SingleRsp CreateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new SalesManagerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Add(category);
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
        public SingleRsp UpdateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new SalesManagerContext())
            {

                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Update(category);
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
        public List<Category> SearchCategory(string keyword)
        {
            return All.Where(x => x.CategoryName.Contains(keyword)).ToList();
        }
    }
}
