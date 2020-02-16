using Shared.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Interfaces.Employess
{
    public interface IEmployeeRepository : IRepo<EmpMaster>
    {
        Task<IEnumerable<EmpMaster>> GetEmployeesForSelectAsync();
    }
}
