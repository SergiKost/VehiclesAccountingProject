using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Engine : BaseEntity
    {
        /// <summary>
        /// Наименование двигателя.
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// Номер двигателя.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Мощность (кВТ, л.с.).
        /// </summary>
        public double Power { get; set; }   

        /// <summary>
        /// Объем двигателя
        /// </summary>
        public double Volume { get; set; }  

        /// <summary>
        /// Авто, на которое установлен двигатель.
        /// </summary>
        public List<Vehicle> Vehicles { get; set; }  


        public int? PetrolTypeId { get; set; }

        /// <summary>
        /// Тип топлива.
        /// </summary>
        public Petrol PetrolType { get; set; }


    }
}
