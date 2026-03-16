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
            var identityResult = await _userManager.CreateAsync(
                new SchoolUser {
                    FirstName = registerGetViewModel.FirstName,
                    LastName = registerGetViewModel.LastName,
                    Email = registerGetViewModel.Email,
                    UserName = registerGetViewModel.Email
                },
                registerGetViewModel.Password);
            ViewBag.IdentityResult = identityResult;
            return View();
        }
    }
}
