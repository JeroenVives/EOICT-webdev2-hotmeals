using HotMeals.Data.School;
using HotMeals.Models.DTOs;
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
            await _schoolContext.Users.AddAsync(userDbo);
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
            var userDbo = await _schoolContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (userDbo == null)
            {
                return NotFound();
            }
            return UserDto.FromDbo(userDbo);
        }

        [HttpPost]
        [Route("classes")]
        public async Task<ActionResult<ClassDto>> CreateClass(ClassDto classDto)
        {
            var classDbo = classDto.ToDbo();
            await _schoolContext.Classes.AddAsync(classDbo);
            await _schoolContext.SaveChangesAsync();
            return CreatedAtAction
                (
                    nameof(GetClass),
                    new { id = classDbo.Id },
                    ClassDto.FromDbo(classDbo)
                );
        }

        [HttpGet]
        [Route("classes/{id}")]
        public async Task<ActionResult<ClassDto>> GetClass(int id)
        {
            var classDbo = await _schoolContext.Classes.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (classDbo == null)
            {
                return NotFound();
            }
            return ClassDto.FromDbo(classDbo);
        }

        [HttpPost]
        [Route("children")]
        public async Task<ActionResult<ChildPostDto>> CreateChild(ChildPostDto childDto)
        {
            var childDbo = childDto.ToDbo();
            await _schoolContext.Children.AddAsync(childDbo);
            await _schoolContext.SaveChangesAsync();
            var userDbo = await _schoolContext.Users.Where(u => u.Id == childDto.UserId).FirstOrDefaultAsync();
            if (userDbo == null)
            {
                return BadRequest($"User ID {childDto.UserId} does not exist.");
            }
            var classDbo = await _schoolContext.Classes.Where(c => c.Id == childDto.ClassId).FirstOrDefaultAsync();
            if (classDbo == null)
            {
                return BadRequest($"Class ID {childDto.ClassId} does not exist.");
            }
            childDbo.User = userDbo;
            childDbo.Class = classDbo;
            return CreatedAtAction
                (
                    nameof(GetChild),
                    new { id = childDbo.User.Id },
                    ChildGetDto.FromDbo(childDbo)
                );
        }

        [HttpPost]
        [Route("children/{childId}/allergens/{allergenId}")]
        public async Task<IActionResult> RegisterAllergenSensitivity(int childId, int allergenId)
        {
            var childDbo = await GetChildDbo(childId);
            if (childDbo == null)
            {
                return BadRequest($"Child ID {childId} does not exist.");
            }
            var allergenDbo = await MealsController.GetAllergenDbo(_schoolContext, allergenId);
            if (allergenDbo == null)
            {
                return BadRequest($"Allergen ID {allergenId} does not exist.");
            }
            childDbo.Allergens.Add(allergenDbo);
            await _schoolContext.SaveChangesAsync();
            return Created();
        }

        [HttpGet]
        [Route("children")]
        public async Task<ActionResult<IEnumerable<ChildGetDto>>> GetAllChildren([FromQuery(Name = "class-id")] int classId, [FromQuery(Name = "allergen-id")] int allergenId)
        {
            return await _schoolContext.Children.Include(c => c.User).Include(c => c.Class).Select(c => ChildGetDto.FromDbo(c)).ToListAsync();
        }

        public async Task<Child?> GetChildDbo(int id)
        {
            return await _schoolContext.Children.Include(c => c.User).Include(c => c.Class).Where(c => c.UserId == id).FirstOrDefaultAsync();
        }

        [HttpGet]
        [Route("children/{id}")]
        public async Task<ActionResult<ChildGetDto>> GetChild(int id)
        {
            var childDbo = await GetChildDbo(id);
            if (childDbo == null)
            {
                return NotFound();
            }
            return ChildGetDto.FromDbo(childDbo);
        }

        [HttpGet]
        [Route("children/count")]
        public async Task<ActionResult<int>> GetNumberOfChildren([FromQuery(Name = "class-id")] int? classId, [FromQuery(Name = "allergen-id")] int? allergenId)
        {
            IQueryable<Child> children = _schoolContext.Children.Include(c => c.Allergens);
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
