using System;

namespace Beecow.DTOs.User
{
    public class UserResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public Guid BusinessId { get; set; }
        public Guid UserId { get; set; }
    }
}
