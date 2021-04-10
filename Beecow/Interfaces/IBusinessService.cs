using System.Collections.Generic;
using System.Threading.Tasks;
using Beecow.Entities;

namespace Beecow.Interfaces
{
    public interface IBusinessService
    {
        Task<List<Business>> GetAllBusinesses();
    }
}
