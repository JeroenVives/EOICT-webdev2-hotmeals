using HotMeals.Data.School;
using HotMeals.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotMeals.Controllers
{
    [Route("mvc/[controller]")]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly SchoolContext _schoolContext;

        public DashboardController(ILogger<DashboardController> logger, SchoolContext schoolContext)
        {
            _logger = logger;
            _schoolContext = schoolContext;
        }

        [Route("mealchoices")]
        public async Task<IActionResult> MealChoices([FromQuery] DateTime? date)
        {
            var scheduledHotMeals = new List<ScheduledHotMeal>();
            var dateFormat = "yyyy-MM-dd";
            var dateString = date?.ToString(dateFormat);
            if (date != null)
            {
                scheduledHotMeals = await _schoolContext.ScheduledHotMeals.Include(s => s.HotMeal).Include(s => s.HotMealChoices).Where(s => s.Date == date).ToListAsync();
            }
            var viewModel = new MealChoicesViewModel
            {
                HotMealCounts = scheduledHotMeals.Select(s => (s.HotMeal.Description, s.HotMealChoices.Count)).ToList(),
                DateChoices = await _schoolContext.ScheduledHotMeals.Select(s => s.Date).Distinct().Select(d => d.ToString(dateFormat)).Select(ds => new SelectListItem { Value = ds, Text = ds, Selected = ds == dateString }).ToListAsync(),
            };
            return View(viewModel);
        }
    }
}
