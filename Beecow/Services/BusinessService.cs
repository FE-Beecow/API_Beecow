using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beecow.Entities;
using Beecow.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Beecow.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly BeecowDbContext _dbContext;

        public BusinessService(BeecowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Business>> GetAllBusinesses()
        {
            return await _dbContext.Business.Where(x => x.IsActive).ToListAsync();
        }
    }
}
