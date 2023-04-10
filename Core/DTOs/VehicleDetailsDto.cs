using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
    public class VehicleDetailsDto : BaseDto
    {
        [Display(Name = "Наименование")]
        public override string Name { get; set; }

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

        [Display(Name = "Год выпуска")]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Масса без нагрузки, кг.")]
        public int? StockMass { get; set; }

        [Display(Name = "Масса с нагрузкой, кг.")]
        public int? MaxMass { get; set; }

        [Display(Name = "Сотрудник")]
        public int? EmployeeId { get; set; }

        [Display(Name = "ФИО Сотрудника")]
        public string FullNameOfDriver { get; set; }

        [Display(Name = "Номер шасси")]
        public string ChassisNumber { get; set; }

        [Display(Name = "Номер кузова")]
        public string HullNumber { get; set; }

        [Display(Name = "Пробег")]
        public string Mileage { get; set; }

        [Display(Name = "Наименование двигателя")]
        public string EngineName { get; set; }

        [Display(Name = "Номер двигателя")]
        public string EngineNumber { get; set; }

        [Display(Name = "Мощность двигателя, л.с.")]
        public double EnginePower { get; set; }

        [Display(Name = "Объем двигателя, л.")]
        public double EngineVolume { get; set; }

        [Display(Name = "Тип топлива")]
        public string EnginePetrol { get; set; }

        [Display(Name = "Топливо")]
        public int? EnginePetrolId { get; set; }


    }
}
