using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Application.DTO
{
    public class AuthResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public DateTime Expiry { get; set; }

    }
}
