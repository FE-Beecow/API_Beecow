using Beecow.DTOs.Product;
using Beecow.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Beecow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("addproduct")]
        public async Task<IActionResult> AddProduct(ProductModel productRequest)
        {
            try
            {

                var productResponse = await _productService.AddProduct(productRequest);

                if (productResponse == null)
                {
                    return Ok(new { status = 999, message = $"system error" });
                }

                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("editproduct")]
        public async Task<IActionResult> EditProduct(EditProductModel productRequest)
        {
            try
            {

                var productResponse = await _productService.EditProduct(productRequest);

                if (productResponse == null)
                {
                    return Ok(new { status = 999, message = $"system error" });
                }

                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("deleteproduct")]
        public async Task<IActionResult> DeleteProduct(DeleteProductModel productRequest)
        {
            try
            {

                var productResponse = await _productService.DeleteProduct(productRequest);

                if (productResponse == null)
                {
                    return Ok(new { status = 999, message = $"system error" });
                }

                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
