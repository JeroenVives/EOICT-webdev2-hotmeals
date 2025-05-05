using HotMeals.Data.School;
using HotMeals.Models.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotMeals.Controllers
{
    [Route("mvc/[controller]")]
    public class IdentityController : Controller
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly SchoolContext _schoolContext;
        private readonly UserManager<SchoolUser> _userManager;
        private readonly SignInManager<SchoolUser> _signInManager;

        public IdentityController(ILogger<IdentityController> logger, SchoolContext schoolContext, UserManager<SchoolUser> userManager, SignInManager<SchoolUser> signInManager)
        {
            _logger = logger;
            _schoolContext = schoolContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("register")]
        public IActionResult RegisterGet()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterPost(RegisterGetViewModel registerGetViewModel)
        {
            var identityResult = await _userManager.CreateAsync(new SchoolUser { FirstName = registerGetViewModel.FirstName, LastName = registerGetViewModel.LastName, Email = registerGetViewModel.Email, UserName = registerGetViewModel.Email }, registerGetViewModel.Password);
            ViewBag.IdentityResult = identityResult;
            return View();
        }

        [HttpGet]
        [Route("loginout")]
        public async Task<IActionResult> LogInOutGet([FromQuery(Name = "ReturnUrl")] string? redirectPath)
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;
            ViewBag.RedirectPath = redirectPath;
            return View();
        }

        [HttpGet]
        [Route("accessdenied")]
        public ActionResult AccessDenied([FromQuery(Name = "ReturnUrl")] string path)
        {
            ViewBag.Path = path;
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogInPost([FromForm(Name = "email-address")] string email, string password, [FromForm(Name = "redirect-path")] string? redirectPath)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(email, password, false, false);
            if (!string.IsNullOrEmpty(redirectPath) && signInResult.Succeeded)
            {
                return Redirect(redirectPath);
            }
            else
            {
                ViewBag.SignInResult = signInResult;
                var user = await _userManager.GetUserAsync(User);
                ViewBag.User = user;
                return View();
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogOutPost()
        {
            await _signInManager.SignOutAsync();
            return View();
        }
    }
}
