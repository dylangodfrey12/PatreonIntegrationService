
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ApiIntegration.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiIntegration.Controllers
{
    [Authorize]
    [Microsoft.AspNetCore.Mvc.Route("api/login")]
    public class LoginController : Controller
    {
        private LoginContext _loginContext;

        public LoginController(LoginContext loginContext)
          {
              _loginContext = loginContext;
          }
        [Microsoft.AspNetCore.Mvc.HttpPost()]
        public JsonResult PostAuthenticatedUser()
        {
            return new JsonResult(LoginDataSource.Account.Users);
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public JsonResult GetAuthenticatedUser(int id)
        {
            var result = LoginDataSource.Account.Users.FirstOrDefault(c => c.Id == id);
            return new JsonResult(result);
        }
    }
}
