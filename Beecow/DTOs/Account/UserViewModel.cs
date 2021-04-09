using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.DTOs.Account
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
    }
}
