using QuanLyBanHang26_NguyenQuangHuy26.Common.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using System.Linq;

namespace QuanLyBanHang26_NguyenQuangHuy26.DAL
{
    public class ProductRep :GenericRep<SalesManagerContext, Product>
    {
        #region -- Overrides --


        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }
   
        public int Remove(int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }

        #endregion
        #region -- Method --
        public SingleRsp CreateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new SalesManagerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Add(product);
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
        public SingleRsp UpdateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new SalesManagerContext())
            {
     
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Update(product);
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
        public List<Product> SearchProduct(string keyword)
        {
            return All.Where(x => x.ProductName.Contains(keyword)).ToList();
        }
        #endregion
    }
}
