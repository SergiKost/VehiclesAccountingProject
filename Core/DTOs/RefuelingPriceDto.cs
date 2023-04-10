using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
    public class RefuelingPriceDto : BaseDto
    {
        [Display(Name="Топливо")]
        public int? PetrolTypeId { get; set; }

        /// <summary>
        /// Тип топлива.
        /// </summary>
        [Display(Name="Тип топлива")]
        public string PetrolType { get; set; }

        /// <summary>
        /// Цена за литр.
        /// </summary>
        [Display(Name = "Цена за литр топлива, руб")]
        public double? PetrolPrice { get; set; }

        /// <summary>
        /// Дата, начиная с которой действует определенная цена на данный вид топлива.
        /// </summary>
        [Display(Name="Действие цены с этой даты")]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата, по которую действует определенная цена на данный вид топлива.
        /// </summary>
        [Display(Name = "Действие цены по эту дату")]
        public DateTime? DateTo { get; set; }
    }
}
