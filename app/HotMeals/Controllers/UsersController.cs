using HotMeals.Data.school;
using HotMeals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotMeals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly SchoolContext _schoolContext;

        public UsersController(ILogger<UsersController> logger, SchoolContext schoolContext)
        {
            _logger = logger;
            _schoolContext = schoolContext;
        }

        [HttpPost]
        [Route("users")]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
        {
            var userDbo = userDto.ToDbo();
            await _schoolContext.AddAsync(userDbo);
            await _schoolContext.SaveChangesAsync();
            return CreatedAtAction
                (
                    nameof(GetUser),
                    new { id = userDbo.Id },
                    UserDto.FromDbo(userDbo)
                );
        }

        [HttpGet]
        [Route("users/{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _schoolContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            return UserDto.FromDbo(user);
        }

        [HttpGet]
        [Route("children/count")]
        public async Task<ActionResult<int>> GetNumberOfChildren([FromQuery(Name = "class-id")] int? classId, [FromQuery(Name = "allergen-id")] int? allergenId)
        {
            IQueryable<Child> children = _schoolContext.Children;
            if (classId != null)
            {
                children = children.Where(c => c.ClassId == classId);
            }
            if (allergenId != null)
            {
                children = children.Where(c => c.Allergens.Select(a => a.Id).Contains((int)allergenId));
            }
            return await children.CountAsync();
        }
    }
}
