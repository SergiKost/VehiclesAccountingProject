using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using Core.DTOs.VehicleViewModels;
using Core.Entities;


namespace Core.IServices
{
    public interface IVehicleService
    {
        IEnumerable<VehicleDto> GetVehicleDtos();

        IEnumerable<PetrolDto> GetPetrolList();

        IEnumerable<EmployeeSimpleDto> GetEmployeeSimpleList();

        public IEnumerable<VehicleSimpleDto> GetVehicleSimpleDtos();

        public VehicleDetailsDto GetVehicleDetailsDto(int id);

        void Save(VehicleDto entity);

        Task<Vehicle> SaveAsync(AddNewVehicleViewModel entity);

        void Delete(int vehicleId);
    }
}
