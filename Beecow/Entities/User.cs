using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beecow.Entities
{
    public class User: BaseEntity
    {
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public DateTime? DOB { get; set; }
    }
}
