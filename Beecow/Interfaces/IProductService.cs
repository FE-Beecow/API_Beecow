using Beecow.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> AddProduct(ProductModel productRequest);
        Task<ProductResponse> EditProduct(EditProductModel editproductRequest);
        Task<ProductResponse> DeleteProduct(DeleteProductModel editproductRequest);
    }
}
