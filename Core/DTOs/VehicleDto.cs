using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Core.DTOs
{
    public class VehicleDto : BaseDto
    {
        [Display(Name = "Марка")]
        public string Brand { get; set; }

        [Display(Name = "Модель")]
        public string Model { get; set; }

        [Display(Name = "Тип")]
        public string Type { get; set; }

        [Display(Name = "ВИН-код ТС")]
        public string VINCode { get; set; }

        [Display(Name = "Гос. номер")]
        public string RegistPlate { get; set; }

        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [Display(Name = "Двигатель")]
        public int? EngineId { get; set; }

        [Display(Name = "Наименование двигателя")]
        public string Engine { get; set; }

        [Display(Name = "Год выпуска")]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Масса без нагрузки, кг.")]
        public int? StockMass { get; set; }

        [Display(Name = "Масса под нагрузкой, кг.")]
        public int? MaxMass { get; set; }

        [Display(Name = "ФИО сотрудника-водителя")]
        public string FullNameOfDriver { get; set; }

        [Display(Name = "Номер шасси")]
        public string ChassisNumber { get; set; }

        [Display(Name = "Номер кузова")]
        public string HullNumber { get; set; }

        [Display(Name = "Пробег")]
        public string Mileage { get; set; }

        [Display(Name = "Сотрудник")]
        public int? EmpoyeeId { get; set; }

        [Display(Name = "ФИО сотрудника")]
        public string Employee { get; set; }

        [Display(Name = "Тип топлива")]
        public string Petrol { get; set; }
    }
}
