using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.WaybillViewModels
{
    public class AddNewWaybillViewModel
    {
        public WaybillDetailsDto WaybillDetails { get; set; }
        public IEnumerable<EmployeeSimpleDto> EmployeeSimpleModels { get; set; }

        public string SelectedEmployee { get; set; }

        public IEnumerable<RPSimpleDto> RpSimpleModels { get; set; }

        public string SelectedRp { get; set; }

        public IEnumerable<VehicleSimpleDto> VehicleSimplesModels { get; set; }

        public string SelectedVehicle { get; set; }
    }
}
