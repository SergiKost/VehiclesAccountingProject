using Core.DTOs;
using Core.DTOs.WaybillViewModels;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IWaybillService
    {
        public IEnumerable<EmployeeSimpleDto> GetEmployeeSimpleList();

        public IEnumerable<VehicleSimpleDto> GetVehicleSimpleList();

        public IEnumerable<RPSimpleDto> GetRPSimpleList();
        public IEnumerable<WaybillDetailsDto> GetWaybillDetailsDtos();

        Task<Waybill> SaveAsync(AddNewWaybillViewModel model);
    }
}
