using AutoMapper;
using Beecow.DTOs.Product;
using Beecow.Entities;
using Beecow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Services
{
    public class ProductsService : IProductService
    {
        private readonly BeecowDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductsService(BeecowDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProductResponse> AddProduct(ProductModel model)
        {

            var addProduct = new Product()
            {
                UserId = model.UserId,
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                FullDescription = model.FullDescription,
                Price = model.Price,
                PriceCurrency = model.PriceCurrency,
                PriceDiscountValue = model.PriceDiscountValue,
                PriceDiscountPercentage = model.PriceDiscountPercentage,
                Unit = model.Unit,
                Category = model.Category,
                Size = model.Size,
                Weight = model.Weight,
                WeightUnit = model.WeightUnit,
                InventoryAmount = model.InventoryAmount,
                InventoryAdjustment = model.InventoryAdjustment,
                Status = model.Status
            };

            await _dbContext.Products.AddAsync(addProduct);
            await _dbContext.SaveChangesAsync();

            return new ProductResponse { Status = "200", Message = "Add Success" };

        }
        public async Task<ProductResponse> EditProduct(EditProductModel edit_model)
        {
            //loop for product by id
            var existProduct = await _dbContext.Products.FindAsync(edit_model.Id);

            if (existProduct == null)
                return null;

            //update
            //existProduct = _mapper.Map<Product>(edit_model);
            existProduct.Title = edit_model.Title;
            existProduct.ShortDescription = edit_model.ShortDescription;
            existProduct.FullDescription = edit_model.FullDescription;
            existProduct.Price = edit_model.Price;
            existProduct.PriceCurrency = edit_model.PriceCurrency;
            existProduct.PriceDiscountValue = edit_model.PriceDiscountValue;
            existProduct.PriceDiscountPercentage = edit_model.PriceDiscountPercentage;
            existProduct.Unit = edit_model.Unit;
            existProduct.Category = edit_model.Category;
            existProduct.Size = edit_model.Size;
            existProduct.Weight = edit_model.Weight;
            existProduct.WeightUnit = edit_model.WeightUnit;
            existProduct.InventoryAmount = edit_model.InventoryAmount;
            existProduct.InventoryAdjustment = edit_model.InventoryAdjustment;

            _dbContext.Products.Update(existProduct);
            await _dbContext.SaveChangesAsync();

            return new ProductResponse { Status = "200", Message = "Success" };

        }

        public async Task<ProductResponse> DeleteProduct(DeleteProductModel del_model)
        {
            //Check product_id
            var checkPruductId = _dbContext.Products.FirstOrDefault(UserId => (UserId.Id == del_model.Id));

            if (checkPruductId != null)
            {
                _dbContext.Products.Remove(checkPruductId);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return null;
            }

            return new ProductResponse { Status = "200", Message = "Delete success" };

        }

    }

    
}
