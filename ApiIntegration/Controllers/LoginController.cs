
using System.Linq;
using System.Threading.Tasks;
using ApiIntegration.Entities;
using ApiIntegration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiIntegration.Controllers
{
    [Authorize()]
    public class LoginController : Controller
    {
        private ILoginData _loginData;

        public LoginController(ILoginData loginData)
        {
             _loginData = loginData;
        }
        
        [HttpPost]
        [AllowAnonymous]
        public JsonResult New(LoginDto login)
        {
            var user = _loginData.Create(login);
            if (user == null)
            {
                return new JsonResult("error user already ccreated");
            }
            return new JsonResult("you exst! grazts");
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get(LoginDto login)
        {
            var user = _loginData.GetUser(login);
            if (user == null)
            {
                return new JsonResult("error not found");
            }
            return new JsonResult("you exist!");
        }
        

    }
}
