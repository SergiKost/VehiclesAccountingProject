using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Petrol : BaseEntity
    {
        /// <summary>
        /// Наименование вида топлива.
        /// </summary>
        public string Name { get; set; }
    }
}
