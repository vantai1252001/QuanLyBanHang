using QuanLyBanHang26_NguyenQuangHuy26.Common.BLL;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Rsp;
using QuanLyBanHang26_NguyenQuangHuy26.Common.Req;
using QuanLyBanHang26_NguyenQuangHuy26.DAL;
using QuanLyBanHang26_NguyenQuangHuy26.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyBanHang26_NguyenQuangHuy26.BLL
{
    public class CategorySvc: GenericSvc<CategoryRep, Category>
    {
        private CategoryRep categoryRep;
        public CategorySvc()
        {
            categoryRep = new CategoryRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();

            var m1 = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.CategoryName);
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
        public SingleRsp CreateCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category.CategoryName = categoryReq.CategoryName;
            category.Description = categoryReq.Description;
            res = categoryRep.CreateCategory(category);
            return res;
        }
        public SingleRsp UpdateCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();

            Category category = new Category();
            category.CategoryId = categoryReq.CategoryID;
            category.CategoryName = categoryReq.CategoryName;
            category.Description = categoryReq.Description;
            res = categoryRep.UpdateCategory(category);
            return res;
        }
        public SingleRsp SearchCategory(SearchCateByName searchCateByName)
        {
            var res = new SingleRsp();
            //lay dssp theo keyword
            var cates = categoryRep.SearchCategory(searchCateByName.Keyword);
            res.Data = cates;
            return res;
        }
    }
    
}
