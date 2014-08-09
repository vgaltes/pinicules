using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
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

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindAsync(model.UserName, model.Password);

            if (user != null)
            {
                var identity = await userManager.CreateIdentityAsync(
                    user, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
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
                return RedirectToAction("Search", "Movies");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }

        public ActionResult Logout()
        {
            GetAuthenticationManager().SignOut();
            return RedirectToAction("Search", "Movies");
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            GetAuthenticationManager().SignIn(identity);
        }

        IAuthenticationManager GetAuthenticationManager()
        {
            return HttpContext.GetOwinContext().Authentication;
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Search", "Movies");
            }

            return returnUrl;
        }
    }
}