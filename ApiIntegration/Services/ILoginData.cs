using ApiIntegration.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiIntegration
{
     public interface ILoginData
    {
        LoginDto GetUser(LoginDto login);
        LoginDto Create(LoginDto login);
    }
}
