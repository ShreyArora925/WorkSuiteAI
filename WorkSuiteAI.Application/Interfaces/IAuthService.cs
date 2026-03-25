using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login (LoginRequest request);

        Task<AuthResponse> Register (RegisterRequest request);
    }
}
