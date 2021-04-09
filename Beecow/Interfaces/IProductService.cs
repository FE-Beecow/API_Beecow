using Beecow.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beecow.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductByCustomerId(int id);
    }
}
