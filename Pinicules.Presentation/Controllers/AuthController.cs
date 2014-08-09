using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pinicules.Presentation.Identity;
using Pinicules.Presentation.Models;

namespace Pinicules.Presentation.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        UserManager<AppUser> userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            var model = new RegisterModel();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel userRegistered)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new AppUser
            {
                UserName = userRegistered.UserName,
            };

            var result = await userManager.CreateAsync(user, userRegistered.Password);

            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignIn(identity);
        }
    }
}