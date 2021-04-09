using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Beecow.Interfaces;

namespace Beecow.Controllers
{
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet()]
        //[Authorize(Policy = "OnlyNonBlockedCustomer")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                return Unauthorized("Invalid customer");
            }

            var products = await productService.GetProductByCustomerId(int.Parse(claim.Value));

            if (products == null || !products.Any())
            {
                return BadRequest($"No product was found");
            }

            return Ok(products);
        }
    }
}
