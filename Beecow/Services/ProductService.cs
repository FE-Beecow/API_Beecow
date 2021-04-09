using Beecow.Entities;
using Beecow.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Services
{
    public class ProductService : IProductService
    {
        private readonly CustomersDbContext customersDbContext;

        public ProductService(CustomersDbContext customersDbContext)
        {
            this.customersDbContext = customersDbContext;
        }
        public async Task<List<Product>> GetProductByCustomerId(int id)
        {
            var products = await customersDbContext.Products.Where(product => product.CustomerId == id).ToListAsync();

            return products;
        }
    }
}
