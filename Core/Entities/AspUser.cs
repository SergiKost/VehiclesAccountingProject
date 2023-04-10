using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Core.Entities
{
    public class AspUser : IdentityUser
    {
        public override string Id { get; set; }
        public override string Email { get => base.Email; set => base.Email = value; }
        public override string UserName { get; set; } 

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
