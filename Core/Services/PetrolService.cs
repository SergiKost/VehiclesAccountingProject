using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class PetrolService : BaseService<Petrol>, IPetrolService
    {
        private readonly IMapper _mapper;

        
        public PetrolService(IRepository<Petrol> repository, IMapper mapper) : base(repository)
        {
           
            this._mapper = mapper;
        }
        public IEnumerable<PetrolDto> GetPetrolDtos()
        {
          var petrols = repository.GetAll().Select(p => new PetrolDto
          {
              Id = p.Id,
              Name = p.Name,
          }).ToList();

           return petrols;
        }
    }
}
