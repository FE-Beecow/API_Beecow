using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Entities
{
    public class Product:  BaseEntity
    {
        public string Product_title { get; set; }
        public string Product_short_description { get; set; }
        public string Product_full_description { get; set; }
        public float Product_price { get; set; }
        public string Product_price_currency { get; set; }
        public float Product_price_discount_value { get; set; }
        public Decimal Product_price_discount_percentage { get; set; }
        public string Product_unit { get; set; }
        public string Product_category { get; set; }
        public string Product_size { get; set; }
        public float Product_weight { get; set; }
        public string Product_weight_unit { get; set; }
        public float Product_inventory_amount { get; set; }
        public float Product_inventory_adjustment { get; set; }
        public bool Product_status { get; set; }
        public ICollection<ImagesProduct> ImagesProduct { get; set; }

    }
}
