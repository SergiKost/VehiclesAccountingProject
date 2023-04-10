using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class RefuelingPrice : BaseEntity
    {
        /// <summary>
        /// Номер заправочной карты.
        /// </summary>
        // public string CardNumber { get; set; }


        // public string StationName { get; set; }
        /// <summary>
        /// Топливо.
        /// </summary>
        public int? PetrolTypeId { get; set; }

        /// <summary>
        /// Тип топлива.
        /// </summary>
        public Petrol PetrolType { get; set; }

        /// <summary>
        /// Цена за литр.
        /// </summary>
        public double? PetrolPrice { get ; set; }

        /// <summary>
        /// Дата, начиная с которой действует определенная цена на данный вид топлива.
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата, по которую действует определенная цена на данный вид топлива.
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
