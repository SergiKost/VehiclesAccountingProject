using AutoMapper;
using Core.DTOs;
using Core.DTOs.VehicleViewModels;
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
    public class VehicleService : BaseService<Vehicle>, IVehicleService
    {
        private readonly IMapper _mapper;

        private readonly IPetrolService _petrolService;

        private readonly IEmployeeService _employeeService;

        public VehicleService( IRepository<Vehicle> repository, IPetrolService petrolService, IEmployeeService employeeService,
             IMapper mapper) : base(repository)
        {
            this._petrolService = petrolService;
            this._employeeService = employeeService;
            this._mapper = mapper;
        }     

        public VehicleDetailsDto GetVehicleDetailsDto(int id)
        {
            //var vehicle = repository.Find(v => v.Id == id);
            var selectedVehicle = repository.GetAll().Include(v => v.Engine).ThenInclude(e => e.PetrolType).Where(v => v.Id == id).Select(v => new VehicleDetailsDto
            {
                Brand = v.Brand,
                Model = v.Model,
                Color = v.Color,
                Type = v.Type,
                ChassisNumber = v.ChassisNumber,
                Name = v.Name,
                EngineName = v.Engine.Name,
                EngineNumber = v.Engine.Number,
                EnginePower = v.Engine.Power,
                EngineVolume = v.Engine.Volume,
                EnginePetrol = v.Engine.PetrolType.Name,
                HullNumber = v.HullNumber,
                StockMass = v.StockMass,
                MaxMass = v.MaxMass,
                Mileage = v.Mileage,
                RegistPlate = v.RegistPlate,
                ReleaseYear = v.ReleaseYear,
                VINCode = v.VINCode,
                FullNameOfDriver = $"{v.Employee.FirstName} {v.Employee.LastName}",
                EmployeeId = v.EmployeeId,
                EnginePetrolId = v.Engine.PetrolType.Id,
            }).ToList().FirstOrDefault(); ;
                       
            return selectedVehicle;
        }

        /// <summary>
        /// Получение списка ТС, включая данные двигателя и типа топлива
        /// </summary>
        /// <returns></returns>
        IEnumerable<VehicleDto> IVehicleService.GetVehicleDtos()
        {
            var vehicles = repository.GetAll().Include(v => v.Engine).ThenInclude(e => e.PetrolType).Select(v => new VehicleDto
            {
                Id = v.Id,
                Brand = v.Brand,
                Model = v.Model,
                Color = v.Color,
                Type = v.Type,
                ChassisNumber = v.ChassisNumber,
                Name = v.Name,
                EngineId = v.Engine.Id,
                Engine = v.Engine.Name,
                EmpoyeeId = v.Employee.Id,
                FullNameOfDriver = $"{v.Employee.FirstName} {v.Employee.LastName}",
                HullNumber = v.HullNumber,
                StockMass = v.StockMass,
                MaxMass = v.MaxMass,
                Mileage = v.Mileage,
                RegistPlate = v.RegistPlate,
                ReleaseYear = v.ReleaseYear,
                VINCode = v.VINCode,
                Petrol = v.Engine.PetrolType.Name,
            }).ToList();

            
            return vehicles;
        }

        /// <summary>
        ///  Получение списка типов топлива (для выбора пользователем элемента из списка на UI)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PetrolDto> GetPetrolList()
        {
            var petrolList = _petrolService.GetPetrolDtos();
            return petrolList;
        }

        /// <summary>
        /// Получение списка сотрудников (для выбора пользователем элемента из списка на UI)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeSimpleDto> GetEmployeeSimpleList()
        {
            var employeeList = _employeeService.GetEmployeeSimpleDtos();
            return employeeList;
        }

        public IEnumerable<VehicleSimpleDto> GetVehicleSimpleDtos()
        {
            var vehicleList = repository.GetAll().Include(v => v.Engine).ThenInclude(e => e.PetrolType).Select(v => new VehicleSimpleDto
            {
                Id = v.Id,
                Name = $"{v.Brand} {v.Model} {v.RegistPlate} {v.Engine.PetrolType.Name}",
                RegistPlate = v.RegistPlate,
            }).ToList();

            return vehicleList;
        }

        /// <summary>
        /// Добавление нового ТС в базу данных.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        async Task<Vehicle> IVehicleService.SaveAsync(AddNewVehicleViewModel model)
        {
          

            Engine engine = new Engine()
            {
                Name = model.VehicleDetailsModel.EngineName,
                Number = model.VehicleDetailsModel.EngineNumber,
                Power = model.VehicleDetailsModel.EnginePower,
                Volume = model.VehicleDetailsModel.EngineVolume,
                PetrolTypeId = model.VehicleDetailsModel.EnginePetrolId,                
            };

            var vehicle = new Vehicle()
            {                
                Name = model.VehicleDetailsModel.Name,
                Brand = model.VehicleDetailsModel.Brand,
                Model = model.VehicleDetailsModel.Model,
                ChassisNumber = model.VehicleDetailsModel.ChassisNumber,
                Color = model.VehicleDetailsModel.Color,
                HullNumber = model.VehicleDetailsModel.HullNumber,
                MaxMass = (int)model.VehicleDetailsModel.MaxMass,
                StockMass = (int)model.VehicleDetailsModel.StockMass,
                Mileage = model.VehicleDetailsModel.Mileage,
                RegistPlate = model.VehicleDetailsModel.RegistPlate,
                Type = model.VehicleDetailsModel.Type,
                VINCode = model.VehicleDetailsModel.VINCode,
                ReleaseYear = (int)model.VehicleDetailsModel.ReleaseYear,
                EmployeeId = model.VehicleDetailsModel.EmployeeId,
            };
           
            vehicle.Engine = engine;
                        
            var result = await repository.AddAsync(vehicle);           
           
            return result;
        }

        void IVehicleService.Save(VehicleDto entity)
        {
            //var vehicle = repository.GetAll()
            //    .FirstOrDefault( v => v.Id == model.Id );
            //if (vehicle != null)
            //{
            //    throw new Exception("Already added entity error");
            //}            
            throw new NotImplementedException();
        }

        void IVehicleService.Delete(int vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
