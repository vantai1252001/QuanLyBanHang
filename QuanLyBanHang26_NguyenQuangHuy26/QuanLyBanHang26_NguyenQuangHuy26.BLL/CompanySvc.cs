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
    public class CompanySvc : GenericSvc<CompanyRep, Company>
    {
        private CompanyRep companyRep;
        public CompanySvc()
        {
            companyRep = new CompanyRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        public override SingleRsp Update(Company m)
        {
            var res = new SingleRsp();

            var m1 = m.CompanyId > 0 ? _rep.Read(m.CompanyId) : _rep.Read(m.CompanyName);
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
        public SingleRsp CreateCompany(CompanyReq companyReq)
        {
            var res = new SingleRsp();
            Company company = new Company();
            company.CompanyId = companyReq.CompanyId;
            company.CompanyName = companyReq.CompanyName;
            company.Country = companyReq.Country;
            company.Phone = companyReq.Phone;
            company.Address = companyReq.Address;
            res = companyRep.CreateCompany(company);
            return res;
        }
        public SingleRsp UpdateCompany(CompanyReq companyReq)
        {
            var res = new SingleRsp();
            Company company = new Company();
            company.CompanyId = companyReq.CompanyId;
            company.CompanyName = companyReq.CompanyName;
            company.Country = companyReq.Country;
            company.Phone = companyReq.Phone;
            company.Address = companyReq.Address;
            res = companyRep.UpdateCompany(company);
            return res;
        }
        //public SingleRsp SearchCategory(SearchCateByName searchCateByName)
        //{
        //    var res = new SingleRsp();
        //    //lay dssp theo keyword
        //    var cates = categoryRep.SearchCategory(searchCateByName.Keyword);
        //    res.Data = cates;
        //    return res;
        //}
    }

}