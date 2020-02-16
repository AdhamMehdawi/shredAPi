﻿using AutoMapper;
using Shared.Core.Interfaces.Employess;
using Shared.Services.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.EmployeeServices
{
    public class EmployeeServices
    {
        private readonly IEmployeeRepository _employeesRepository;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepository employeesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<EmployeeVm>> GetAllEmployeesAsync()
        {
            var employees = await _employeesRepository.GetEmployeesForSelectAsync();
            var result = _mapper.Map<IEnumerable<EmployeeVm>>(employees);

            return result;
        }

        public async Task<EmployeeVm> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeesRepository.GetAsyncById(id);
            var result = _mapper.Map<EmployeeVm>(employee);

            return result;
        }
    }
}