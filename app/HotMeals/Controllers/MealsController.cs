using HotMeals.Data.School;
using HotMeals.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotMeals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly SchoolContext _schoolContext;

        public MealsController(ILogger<UsersController> logger, SchoolContext schoolContext)
        {
            _logger = logger;
            _schoolContext = schoolContext;
        }

        [HttpPost]
        [Route("allergens")]
        public async Task<ActionResult<AllergenDto>> CreateAllergen(AllergenDto allergenDto)
        {
            var allergenDbo = allergenDto.ToDbo();
            await _schoolContext.Allergens.AddAsync(allergenDbo);
            await _schoolContext.SaveChangesAsync();
            return CreatedAtAction
                (
                    nameof(GetAllergen),
                    new { id = allergenDbo.Id },
                    AllergenDto.FromDbo(allergenDbo)
                );
        }

        public static Task<Allergen?> GetAllergenDbo(SchoolContext schoolContext, int id)
        {
            return schoolContext.Allergens.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        [HttpGet]
        [Route("allergens/{id}")]
        public async Task<ActionResult<AllergenDto>> GetAllergen(int id)
        {
            var allergenDbo = await GetAllergenDbo(_schoolContext, id);
            if (allergenDbo == null)
            {
                return NotFound();
            }
            return AllergenDto.FromDbo(allergenDbo);
        }

        [HttpGet]
        [Route("allergens")]
        public async Task<ActionResult<IEnumerable<AllergenDto>>> GetAllAllergens()
        {
            return await _schoolContext.Allergens.Select(a => AllergenDto.FromDbo(a)).ToListAsync();
        }

        [HttpGet]
        [Route("hotmeals")]
        public async Task<ActionResult<IEnumerable<HotMealDto>>> GetHotMeals()
        {
            return await _schoolContext.HotMeals.Select(dbo => HotMealDto.FromDbo(dbo)).ToListAsync();
        }

        public Task<HotMeal?> GetHotMealDbo(int id)
        {
            return _schoolContext.HotMeals.Where(h => h.Id == id).FirstOrDefaultAsync();
        }

        [HttpGet]
        [Route("hotmeals/{id}")]
        public async Task<ActionResult<HotMealDto>> GetHotMeal(int id) {
            var hotMealDbo = await GetHotMealDbo(id);
            if (hotMealDbo == null)
            {
                return NotFound();
            }
            return HotMealDto.FromDbo(hotMealDbo);
        }

        [HttpGet]
        [Route("hotmeals/scheduled/{dateStart}:{dateEnd}")]
        public async Task<ActionResult<IEnumerable<ScheduledHotMealDto>>> GetHotMealsForDateRange(DateTime dateStart, DateTime dateEnd)
        {
            return await _schoolContext.ScheduledHotMeals.Include(s => s.HotMeal).Where(s => s.Date >= dateStart && s.Date <= dateEnd).Select(dbo => ScheduledHotMealDto.FromDbo(dbo)).ToListAsync();
        }

        [HttpGet]
        [Route("hotmeals/scheduled/{date}")]
        public Task<ActionResult<IEnumerable<ScheduledHotMealDto>>> GetHotMealsForDate(DateTime date)
        {
            return GetHotMealsForDateRange(date, date);
        }

        [HttpPost]
        [Route("hotmeals")]
        public async Task<ActionResult<HotMealDto>> CreateHotMeal(HotMealDto hotMealDto)
        {
            var hotMealDbo = hotMealDto.ToDbo();
            await _schoolContext.HotMeals.AddAsync(hotMealDbo);
            await _schoolContext.SaveChangesAsync();
            return CreatedAtAction
                (
                    nameof(GetHotMeal),
                    new { id = hotMealDbo.Id },
                    HotMealDto.FromDbo(hotMealDbo)
                );
        }

        [HttpPost]
        [Route("hotmeals/schedule/{id}/{date}")]
        public async Task<ActionResult<ScheduledHotMealDto>> ScheduleHotMeal(int id, DateTime date)
        {
            var hotMealDbo = await GetHotMealDbo(id);
            if (hotMealDbo == null)
            {
                return BadRequest($"Meal ID {id} does not exist.");
            }
            var scheduledHotMealDto = new ScheduledHotMealDto
            {
                Date = date,
                HotMeal = HotMealDto.FromDbo(hotMealDbo)
            };
            var scheduledHotMealDbo = scheduledHotMealDto.ToDbo();
            await _schoolContext.ScheduledHotMeals.AddAsync(scheduledHotMealDbo);
            await _schoolContext.SaveChangesAsync();
            return CreatedAtAction
                (
                    nameof(GetHotMealsForDate),
                    new { date = scheduledHotMealDbo.Date },
                    ScheduledHotMealDto.FromDbo(scheduledHotMealDbo)
                );
        }
    }
}
