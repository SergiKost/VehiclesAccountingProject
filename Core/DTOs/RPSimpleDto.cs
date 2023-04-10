using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class RPSimpleDto : BaseDto
    {
        public int? PetrolTypeId { get; set; }

        public string PetrolType { get; set; }
    }
}
