using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProiectMaster.Services
{
    public class RetailerService : IRetailerService
    {
        private readonly IRepository<Retailer, int> retailerRep;
        private readonly IRepository<ProductType, int> productTypeRep;
        private readonly IMapper mapper;

        public RetailerService(IRepository<Retailer, int> retailerRep, IRepository<ProductType, int> productTypeRep, IMapper mapper)
        {
            this.retailerRep = retailerRep;
            this.productTypeRep = productTypeRep;
            this.mapper = mapper;
        }
        public void AddRetailer(RetailerVM dto)
        {
            var entity = mapper.Map<Retailer>(dto);
            retailerRep.Add(entity);
        }

        public void DeleteRetailer(int id)
        {
            var entity = retailerRep.GetInstance(id);
            retailerRep.Delete(entity);
        }

        public List<IdNameDto> GetProductTypes()
        {
            return productTypeRep.GetAll().Select(e => new IdNameDto(e.Id, e.Name)).ToList();
        }

        public RetailerVM GetRetailer(int id)
        {
            var entity = retailerRep.GetInstance(id);
            return mapper.Map<RetailerVM>(entity);
        }

        public IEnumerable<RetailerVM> GetRetailers()
        {
            var list = retailerRep.GetAll();
            return mapper.Map<List<RetailerVM>>(list);
        }

        public void UpdateRetailer(int id, RetailerVM dto)
        {
            var entity = retailerRep.GetInstance(id);
            mapper.Map(dto, entity);
            retailerRep.Update(entity);

        }
    }
}
