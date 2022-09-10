using QuanLyBanHang26_NguyenQuangHuy26.Common.BLL;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Req;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using QuanLyBanHang26_NguyenQuangHuy26.DAL;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang26_NguyenQuangHuy26.BLL
{
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;
        public ProductSvc()
        {
            productRep = new ProductRep();
        }
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        //public override SingleRsp Remove(int id)
        //{
        //    var res = new SingleRsp();
        //    res.Data = _rep.Remove(id);
        //    return res;
        //}
        public override SingleRsp Update(Product m)
        {
            var res = new SingleRsp();

            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductName);
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
        #endregion
        public SingleRsp CreateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductName = productReq.ProductName;
            product.CategoryId = productReq.CategoryId;
            product.CompanyId = productReq.CompanyId;
            product.Price = productReq.Price;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.CreateProduct(product);
            return res;
        }

        public SingleRsp UpdateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.CategoryId = productReq.CategoryId;
            product.CompanyId = productReq.CompanyId;
            product.Price = productReq.Price;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.UpdateProduct(product);
            return res;
        }

        public SingleRsp SearchProduct(SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            //lay dssp theo keyword
            var products = productRep.SearchProduct(searchProductReq.Keyword);
            //xu ly phan trang
            int pCount, totalPage, offset;
            offset = searchProductReq.Size * (searchProductReq.Page - 1);
            pCount = products.Count;
            totalPage = (pCount % searchProductReq.Size) == 0 ? pCount / searchProductReq.Size : 1 + (pCount / searchProductReq.Size);
            var p = new
            {
                Data = products.Skip(offset).Take(searchProductReq.Size).ToList(),
                Page = searchProductReq.Page,
                Size = searchProductReq.Size
            }; 
            res.Data = p;
            return res;
        }

    }
}