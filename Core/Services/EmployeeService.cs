using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IMapper _mapper;
        public EmployeeService(IRepository<Employee> repository, IMapper mapper) : base(repository)
        {
            this._mapper = mapper;
        }

        public IEnumerable<EmployeeSimpleDto> GetEmployeeSimpleDtos()
        {
            var employees = repository.GetAll().Select(e => new EmployeeSimpleDto
            {
                Id = e.Id,
                FullName = $"{e.FirstName} {e.LastName}",
            }).ToList();

            return employees;
        }
    }
}
