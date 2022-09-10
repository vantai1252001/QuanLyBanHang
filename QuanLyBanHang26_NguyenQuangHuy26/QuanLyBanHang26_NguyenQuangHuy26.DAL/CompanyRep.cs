using QuanLyBanHang26_NguyenQuangHuy26.Common.DAL;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang26_NguyenQuangHuy26.DAL
{
    public class CompanyRep : GenericRep<SalesManagerContext, Company>
    {
        public CompanyRep()
        {

        }
        public override Company Read(int id)
        {
            var res = All.FirstOrDefault(c => c.CompanyId == id);
            return res;
        }
        public Boolean Remove(int id)
        {
            var m = base.All.FirstOrDefault(i => i.CompanyId == id);
            m = base.Delete(m);
            return true;
        }
        public SingleRsp CreateCompany(Company company)
        {
            var res = new SingleRsp();
            using (var context = new SalesManagerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Companies.Add(company);
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
        public SingleRsp UpdateCompany(Company company)
        {
            var res = new SingleRsp();
            using (var context = new SalesManagerContext())
            {

                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Companies.Update(company);
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
        //public List<Category> SearchCategory(string keyword)
        //{
        //    return All.Where(x => x.CategoryName.Contains(keyword)).ToList();
        //}
    }
}
