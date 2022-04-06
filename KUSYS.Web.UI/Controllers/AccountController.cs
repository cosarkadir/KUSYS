using KUSYS.Web.UI.Models;
using KUSYS.Web.UI.ProxyManagement;
using KUSYS.Web.UI.Models.ResponseModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KUSYS.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IProxyHelper _proxyHelper;
        public AccountController(IProxyHelper proxyHelper)
        {
            _proxyHelper = proxyHelper;
        }

        public async Task<IActionResult> Login(UserContext objLoginModel)
        {
            if (ModelState.IsValid)
            {
                LoginUser loginUser = new LoginUser()
                {
                    UserName = objLoginModel.UserName,
                    Password = objLoginModel.Password
                };
                ServiceResponse<bool> serviceResult = _proxyHelper.ExecuteCall<bool, LoginUser>(ProxyServiceUrl.LOGIN, loginUser, RequestMethod.POST);

                if (serviceResult == null || !serviceResult.IsSuccessfull)
                {
                    ViewBag.Message = serviceResult.Errors[0];
                    return View(objLoginModel);
                }
                else
                {
                    var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name, objLoginModel.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = objLoginModel.RememberLogin
                    });
                    return LocalRedirect("/");
                }
            }
            return View(objLoginModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}