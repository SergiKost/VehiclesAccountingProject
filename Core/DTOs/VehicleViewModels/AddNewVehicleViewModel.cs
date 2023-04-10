using Core.DTOs;
using System.Collections.Generic;

namespace Core.DTOs.VehicleViewModels
{
    public class AddNewVehicleViewModel
    {
        public VehicleDetailsDto VehicleDetailsModel { get; set; }

        public IEnumerable<PetrolDto> PetrolModels { get; set; }

        public string SelectedPetrol { get; set; }

        public IEnumerable<EmployeeSimpleDto> EmployeeSimpleModels { get; set; }

        public string SelectedEmployee { get; set; }
    }
}
