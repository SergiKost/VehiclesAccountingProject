using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Vehicle : BaseEntity
    {
        /// <summary>
        /// Наименование ТС (транспортного средства) как объекта учета.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Марка ТС.
        /// </summary>
        public string Brand  { get; set; }

        /// <summary>
        /// Модель.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Тип ТС.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Идентификационный номер ТС.
        /// </summary>
        public string VINCode { get; set; }

        /// <summary>
        /// Автомобильный государственный регистрационный номер.
        /// </summary>
        public string RegistPlate { get; set; }

        /// <summary>
        /// Цвет кузова.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Год выпуска ТС.
        /// </summary>
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Масса без нагрузки.
        /// </summary>
        public int StockMass { get; set; }   

        /// <summary>
        /// Макс. масса под нагрузкой.
        /// </summary>
        public int MaxMass { get; set; }    

        /// <summary>
        /// Номер и модель двигателя.
        /// </summary>
        public Engine Engine { get; set; }

        /// <summary>
        /// Номер шасси (ходовой или рамы).
        /// </summary>
        public string ChassisNumber { get; set; }  

        /// <summary>
        /// Номер кузова.
        /// </summary>
        public string HullNumber { get; set; }

        /// <summary>
        /// Пробег.
        /// </summary>
        public string Mileage { get; set; }

        /// <summary>
        /// Фото авто (путь к файлу фото).
        /// </summary>
        public string PhotoPath { get; set; }

        public int? EmployeeId { get; set; }

        /// <summary>
        /// Работник, за которым закреплено ТС
        /// </summary>
        public Employee Employee { get; set; }
    }
}
