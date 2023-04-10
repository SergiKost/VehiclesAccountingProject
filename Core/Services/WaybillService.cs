using AutoMapper;
using Core.DTOs;
using Core.DTOs.WaybillViewModels;
using Core.Entities;
using Core.Interfaces;
using Core.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class WaybillService : BaseService<Waybill>, IWaybillService
    {
        private readonly IMapper _mapper;

        private readonly IVehicleService _vehicleService;

        private readonly IRefuelingPriceService _refuelingPriceService;

        private readonly IEmployeeService _employeeService;

        public WaybillService(IRepository<Waybill> repository, 
            IVehicleService vehicleService, 
            IRefuelingPriceService refuelingPriceService,
            IEmployeeService employeeService,
            IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _vehicleService = vehicleService;
            _refuelingPriceService = refuelingPriceService;
            _employeeService = employeeService;
        }

        public IEnumerable<VehicleSimpleDto> GetVehicleSimpleList()
        {
            var vehicleList = _vehicleService.GetVehicleSimpleDtos();
            return vehicleList;
        }

        public IEnumerable<RPSimpleDto> GetRPSimpleList()
        {
            var RpList = _refuelingPriceService.GetRPSimpleDtos();
            return RpList;
        }

        public IEnumerable<EmployeeSimpleDto> GetEmployeeSimpleList()
        {
            var empList = _employeeService.GetEmployeeSimpleDtos();
            return empList;
        }

        public IEnumerable<WaybillDetailsDto> GetWaybillDetailsDtos()
        {
            var waybill = repository.GetAll().Include(w => w.RefuelingPrice).ThenInclude(rp => rp.PetrolType).Select(w => new WaybillDetailsDto
            {
                DateFrom = w.DateFrom,
                DateTo = w.DateTo,
                Employee = $"{w.Employee.FirstName} {w.Employee.LastName}",
                Vehicle = $"{w.Vehicle.Name} {w.Vehicle.RegistPlate}",
                RefuelingPrice = $"{w.RefuelingPrice.PetrolPrice} {w.RefuelingPrice.PetrolType.Name}",
                CityFrom = w.CityFrom,
                CityTo = w.CityTo,
                StartPetrol = w.StartPetrol,
                PetrolRefueling = w.PetrolRefueling,
                PetrolConsumption = w.PetrolConsumption,
                FinishPetrol = w.FinishPetrol,                
                TotalCost = (double?)Math.Round((decimal)(w.RefuelingPrice.PetrolPrice * w.PetrolRefueling), 2),
                
            }).ToList();
            
            return waybill;
        }

         async Task<Waybill> IWaybillService.SaveAsync(AddNewWaybillViewModel model)
         {
            var waybill = new Waybill()
            {
                CityFrom = model.WaybillDetails.CityFrom,
                CityTo = model.WaybillDetails.CityTo,
                DateFrom = model.WaybillDetails.DateFrom,
                DateTo = model.WaybillDetails.DateTo,
                StartPetrol = model.WaybillDetails.StartPetrol,
                PetrolConsumption = model.WaybillDetails.PetrolConsumption,
                PetrolRefueling = model.WaybillDetails.PetrolRefueling,
                FinishPetrol = model.WaybillDetails.FinishPetrol,
                EmployeeId = model.WaybillDetails.EmployeeId,
                VehicleId = model.WaybillDetails.VehicleId,
                RefuelingPriceId = model.WaybillDetails.RefuelingPriceId
            };
            var result = await repository.AddAsync(waybill);

            return result;
         }

        private double CalculateTotalCost(double? petrolPrice, double? amountOfRefueling)
        {
            
            return (double)Math.Round((decimal)(petrolPrice * amountOfRefueling), 2);
        }
    }
}
