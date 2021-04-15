using System;

namespace Beecow.DTOs.Product
{
    public class ProductModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public float Price { get; set; }
        public string PriceCurrency { get; set; }
        public float PriceDiscountValue { get; set; }
        public decimal PriceDiscountPercentage { get; set; }
        public string Unit { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public float Weight { get; set; }
        public string WeightUnit { get; set; }
        public float InventoryAmount { get; set; }
        public float InventoryAdjustment { get; set; }
        public bool Status { get; set; }
        public bool Blocked { get; set; }
        public Guid UserId { get; set; }
    }
}
