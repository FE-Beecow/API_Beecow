using System;
using System.ComponentModel.DataAnnotations;

namespace Beecow.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string CreatedUser { get; set; }
        public string UpdatedUser { get; set; }
        public bool IsActive { get; set; }
    }
}
