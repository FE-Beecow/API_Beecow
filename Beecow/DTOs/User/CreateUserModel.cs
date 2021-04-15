using System;

namespace Beecow.DTOs.User
{
    public class CreateUserModel
    {
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public bool Blocked { get; set; }
        public Guid BusinessId { get; set; }
    }
}
