using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using System.Collections.Generic;

namespace ProiectMaster.Models.Interfaces
{
    public interface IRetailerService
    {
        IEnumerable<RetailerVM> GetRetailers();

        RetailerVM GetRetailer(int id);

        void AddRetailer(RetailerVM dto);

        void UpdateRetailer(int id, RetailerVM dto);

        void DeleteRetailer(int id);

        List<IdNameDto> GetProductTypes();
    }
}
