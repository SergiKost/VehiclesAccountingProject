using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class RefuelingPriceService : BaseService<RefuelingPrice>, IRefuelingPriceService
    {
        private readonly IMapper _mapper;

        private readonly IPetrolService _petrolService;

        public RefuelingPriceService(IRepository<RefuelingPrice> repository, IPetrolService petrolService, IMapper mapper) : base(repository)
        {
            this._mapper = mapper;
            this._petrolService = petrolService;
        }

        public IEnumerable<PetrolDto> GetPetrolDtos()
        {
            return _petrolService.GetPetrolDtos();
        }

        public IEnumerable<RPSimpleDto> GetRPSimpleDtos()
        {
            var RpList = repository.GetAll().Include(rp => rp.PetrolType).Select(rp => new RPSimpleDto
            {
                Id = rp.Id,
                PetrolTypeId = rp.PetrolTypeId,
                PetrolType = rp.PetrolType.Name,
                Name = $"{rp.PetrolPrice} {rp.PetrolType.Name} {rp.DateFrom} {rp.DateTo}"
            }).ToList();

            return RpList;
        }

        public IEnumerable<RefuelingPriceDto> GetRefuelingPriceDtos()
        {
            var prices = repository.GetAll().Include(rp => rp.PetrolType).Select(rp => new RefuelingPriceDto()
            {
                Id = rp.Id,
                DateFrom = rp.DateFrom,
                DateTo = rp.DateTo,
                PetrolPrice = rp.PetrolPrice,
                PetrolType = rp.PetrolType.Name,
                PetrolTypeId = rp.PetrolTypeId,                
            }).ToList();

            return prices;
        }
    }
}
