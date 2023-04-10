using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IServices
{
    public interface IPetrolService
    {
        IEnumerable<PetrolDto> GetPetrolDtos();
    }
}
