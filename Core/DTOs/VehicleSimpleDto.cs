using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
    public class VehicleSimpleDto : BaseDto
    {

        [Display(Name = "Марка")]
        public string Brand { get; set; }

        [Display(Name = "Модель")]
        public string Model { get; set; }

        [Display(Name = "Гос. номер")]
        public string RegistPlate { get; set; }
    }
}
