using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.RefuelingPriceViewModel
{
    public class AddNewRefuelingPrice
    {
        public RefuelingPriceDto RefuelingPrices { get; set; }

        public IEnumerable<PetrolDto> Petrol { get; set; }
    }
}
