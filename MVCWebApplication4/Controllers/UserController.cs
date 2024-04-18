using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication4.Models;

namespace MVCWebApplication4.Controllers
{

    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Username, Email = model.Email};


            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = await _userManager.AddToRoleAsync(user, "User");

                if (role.Succeeded)
                {
                    return RedirectToAction("Login");

                }
            }
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            var login = await _signInManager.PasswordSignInAsync(model.Username,
                model.Password, false, false);


            if (login != null && login.Succeeded)
            {
                return RedirectToAction("Index", "home");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()

        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "home");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult PlaceOrder()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Purchas() 
        {    


            return View();
        }
      
    }


}
    