using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Entities
{
    public class ImagesProduct
    {
        
        public Guid Product_id { get; set; }
        public byte[] Product_images { get; set; }
    }
}
