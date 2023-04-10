using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeSimpleDto> GetEmployeeSimpleDtos();
    }
}
