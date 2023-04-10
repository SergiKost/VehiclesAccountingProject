using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
    public class WaybillDetailsDto : BaseDto
    {
        [Required]
        [Display(Name = "Дата отправления")]
        public DateTime DateFrom { get; set; }

        [Required]
        [Display(Name = "Дата прибытия")]
        public DateTime DateTo { get; set; }

        [Required]
        [Display(Name = "Начальный уровень топлива, л.")]
        public double? StartPetrol { get; set; }

        [Required]
        [Display(Name = "Пополнено топлива, л.")]
        public double? PetrolRefueling { get; set; }

        [Required]
        [Display(Name = "Cожжено топлива, л.")]
        public double? PetrolConsumption { get; set; }

        [Required]
        [Display(Name = "Конечный уровень топлива, л.")]
        public double? FinishPetrol { get; set; }

        [Required]
        [Display(Name = "Город отправления")]
        public string CityFrom { get; set; }

        [Required]
        [Display(Name = "Город прибытия")]
        public string CityTo { get; set; }

        [Required]
        [Display(Name = "Цена топлива за литр")]
        public int? RefuelingPriceId { get; set; }

        /// <summary>
        /// Заправочная цена: цена за литр топлива, тип топлива.
        /// </summary>
        
        [Display(Name = "Цена за выбранный вид топлива ")]
        public string RefuelingPrice { get; set; }

        
        [Display(Name = "Стоимость поездки (купленное топливо)")]
        public double? TotalCost { get; set; }

        [Required]
        [Display(Name = "Транспорт")]
        public int? VehicleId { get; set; }

       
        [Display(Name = "Наименование ТС")]
        public string Vehicle { get; set; }

        [Required]
        [Display(Name = "Сотрудник")]
        public int? EmployeeId { get; set; }

        
        [Display(Name = "ФИО сотрудника")]
        public string Employee { get; set; }
    }
}
