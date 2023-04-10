using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Номер водительского удостоверения.
        /// </summary>
        public string DriveLicenseNumber { get; set; }
                
        
        /// <summary>
        /// Список закрепленных авто.
        /// </summary>
        public List<Vehicle> Vehicles { get; set; }

        public string AspUserId { get; set; }

        public AspUser AspUser { get; set; }    

               
    }
}
