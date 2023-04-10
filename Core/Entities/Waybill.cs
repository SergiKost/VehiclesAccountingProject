using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{ 
    public class Waybill : BaseEntity
    {
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public double? StartPetrol { get; set; }

        public double? PetrolRefueling { get; set; }

        public double? PetrolConsumption { get; set; }

        public double? FinishPetrol { get; set; }

        public string CityFrom { get; set; }

        public string CityTo { get; set; }

        public int? RefuelingPriceId { get; set; }

        /// <summary>
        /// Заправочная цена: цена за литр топлива, тип топлива.
        /// </summary>
        public RefuelingPrice RefuelingPrice { get; set; }

        /// <summary>
        /// Стоимость залитого в бак топлива в период поездки.
        /// </summary>
        public double? TotalCost { get; set; }

        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
