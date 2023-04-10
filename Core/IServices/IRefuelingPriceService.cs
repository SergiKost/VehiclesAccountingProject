using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IServices
{
    public interface IRefuelingPriceService
    {
        public IEnumerable<RPSimpleDto> GetRPSimpleDtos();

        public IEnumerable<PetrolDto> GetPetrolDtos();

        public IEnumerable<RefuelingPriceDto> GetRefuelingPriceDtos();
    }
}
