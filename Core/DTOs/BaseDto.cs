using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; } 

        public virtual string Name { get; set; }    

        public bool IsSelected { get; set; }
    }
}
