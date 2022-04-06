using KUSYS.Core.Contracts;
using KUSYS.Core.Service;
using Microsoft.AspNetCore.Mvc;
using KUSYS.Web.Api.Models;

namespace KUSYS.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: User/Login
        [HttpPost("Login")]
        public ServiceResponse<bool> Login(LoginUser user)
        {
            return _userService.Login(user.UserName, user.Password).Result;
        }
    }
}