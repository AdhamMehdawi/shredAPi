using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities;
using Shared.Core.Interfaces.Employess;
using Shared.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Core.HelperModels;

namespace Shared.Infrastructure.Persistence.EmployeesRepository
{
    public class EmployeeRepository : Repo<EmpMaster>, IEmployeeRepository
    {
        private readonly SharedContext _db;

        public EmployeeRepository(SharedContext context, UserService userService)
            : base(context, userService)
        {
            _db = context;
        }

        public async Task<IEnumerable<EmpMaster>> GetEmployeesForSelectAsync()
        {
            return await _db.EmpMaster.Where(w => !w.IsDeleted).Select(s => new EmpMaster()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                SecondName = s.SecondName,
                ThirdName = s.ThirdName,
                LastName = s.LastName
            }).ToListAsync();
        }
    }
}
