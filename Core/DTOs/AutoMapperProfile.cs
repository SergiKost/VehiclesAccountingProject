using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Waybill, WaybillDetailsDto>()
                .ForMember(wDto => wDto.RefuelingPriceId, cfg => cfg.MapFrom(w => w.RefuelingPrice.Id))
                .ForMember(wDto => wDto.RefuelingPrice, cfg => cfg.MapFrom(w => $"{w.RefuelingPrice.PetrolPrice} {w.RefuelingPrice.PetrolType.Name}"))
                .ForMember(wDto => wDto.EmployeeId, cfg => cfg.MapFrom(w => w.Employee.Id))
                .ForMember(wDto => wDto.Employee, cfg => cfg.MapFrom(w => $"{w.Employee.FirstName} {w.Employee.LastName}"))
                .ForMember(wDto => wDto.VehicleId, cfg => cfg.MapFrom(w => w.Vehicle.Id))
                .ForMember(wDto => wDto.Vehicle, cfg => cfg.MapFrom(w => $"{w.Vehicle.Name} {w.Vehicle.RegistPlate}"));

            CreateMap<RefuelingPrice, RefuelingPriceDto>()
                .ForMember(rpDto => rpDto.PetrolTypeId, cfg => cfg.MapFrom(rp => rp.PetrolType.Id))
                .ForMember(rpDto => rpDto.PetrolType, cfg => cfg.MapFrom(rp => rp.PetrolType.Name));

            CreateMap<RefuelingPrice, RPSimpleDto>()
                .ForMember(rpDto => rpDto.Name, cfg => cfg.MapFrom(rp => $"{rp.PetrolPrice} {rp.PetrolType.Name} {rp.DateFrom} {rp.DateTo}"))
                .ForMember(rpDto => rpDto.PetrolTypeId, cfg => cfg.MapFrom(rp => rp.PetrolTypeId))
                .ForMember(rpDto => rpDto.PetrolType, cfg => cfg.MapFrom(rp => rp.PetrolType.Name));

            CreateMap<Employee, EmployeeDto>();

            CreateMap<Employee, EmployeeSimpleDto>()
                .ForMember(eDto => eDto.FullName, cfg => cfg.MapFrom(e => $"{e.FirstName} {e.LastName}"));

            CreateMap<Vehicle, VehicleSimpleDto>()
                .ForMember(vDto => vDto.Name, cfg => cfg.MapFrom(v => $"{v.Brand} {v.Model} {v.RegistPlate}"));

            CreateMap<Vehicle, VehicleDto>()
                .ForMember(vDto => vDto.EngineId, cfg => cfg.MapFrom(v => v.Engine.Id))
                .ForMember(vDto => vDto.Engine, cfg => cfg.MapFrom(v => v.Engine.Name))
                .ForMember(vDto => vDto.EmpoyeeId, cfg => cfg.MapFrom(v => v.Employee.Id))
                .ForMember(vDto => vDto.Employee, cfg => cfg.MapFrom(v => v.Employee.FirstName))
                .ForMember(vDto => vDto.FullNameOfDriver, cfg => cfg.MapFrom(v => $"{v.Employee.FirstName} {v.Employee.LastName}"))
                .ForMember(vDto => vDto.Petrol, cfg => cfg.MapFrom(v => v.Engine.PetrolType.Name));

            CreateMap<Vehicle, VehicleDetailsDto>()
                .ForMember(vDto => vDto.EngineName, cfg => cfg.MapFrom(v => v.Engine.Name))
                .ForMember(vDto => vDto.EngineNumber, cfg => cfg.MapFrom(v => v.Engine.Number))
                .ForMember(vDto => vDto.EnginePower, cfg => cfg.MapFrom(v => v.Engine.Power))
                .ForMember(vDto => vDto.EngineVolume, cfg => cfg.MapFrom(v => v.Engine.Volume))
                .ForMember(vDto => vDto.EnginePetrol, cfg => cfg.MapFrom(v => v.Engine.PetrolType.Name))
                .ForMember(vDto => vDto.EnginePetrolId, cfg => cfg.MapFrom(v => v.Engine.PetrolType.Id))
                .ForMember(vDto => vDto.EmployeeId, cfg => cfg.MapFrom(v => v.Employee.Id));

            CreateMap<Engine, EngineDto>()
                .ForMember(eDto => eDto.PetrolType, cfg => cfg.MapFrom(e => e.PetrolType.Name));

            CreateMap<Petrol, PetrolDto>();

            CreateMap<IdentityRole, RoleDto>();
                
        }
    }
}
