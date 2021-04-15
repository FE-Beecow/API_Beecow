using System;
using System.ComponentModel.DataAnnotations;

namespace Beecow.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; }
        public string LastSavedUser { get; set; }
        public DateTime LastSavedTime { get; set; } = DateTime.Now;
        public string CreatedUser { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
