using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class EngineDto : BaseDto
    {
        public override string Name { get; set; }

        
        public string Number { get; set; }

        
        public double Power { get; set; }

        
        public double Volume { get; set; }

        

        
        public string PetrolType { get; set; }
    }
}
