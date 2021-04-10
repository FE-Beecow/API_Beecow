using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Entities
{
    public class Business : BaseEntity
    {
        public string Name { get; set; }

        public User User { get; set; }
    }
}
