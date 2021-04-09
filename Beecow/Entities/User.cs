using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beecow.Entities
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public bool Blocked { get; set; }
        public string Update_Date { get; set; }
        public string Create_Date { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
