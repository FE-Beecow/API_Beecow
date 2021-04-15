using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Entities
{
    public class ImagesProduct:  BaseEntity
    {
        public Product Product { get; set; }
        public byte[] ProductImages { get; set; }
    }
}
