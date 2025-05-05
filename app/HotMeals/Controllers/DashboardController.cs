using HotMeals.Data.School;
using HotMeals.Models.Enums;
using HotMeals.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [Authorize(Policy = "TeacherRole")]
        [Route("homemeals")]
        public async Task<IActionResult> HomeMeals([FromQuery(Name = "class-id")] int? classId)
        {
            var childrenUsers = new List<SchoolUser>();
            if (classId != null)
            {
                childrenUsers = await _schoolContext.MealChoices.Include(m => m.Child).ThenInclude(c => c.User).Where(m => m.Date.Date == DateTime.Now.Date && m.Child.ClassId == classId && m.Choice == MealChoiceEnum.home.ToString()).Select(m => m.Child.User).ToListAsync();
            }
            var viewModel = new HomeMealsViewModel
            {
                ChildrenNames = childrenUsers.Select(u => (u.FirstName, u.LastName)).ToList(),
                ClassChoices = await _schoolContext.Classes.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Description, Selected = c.Id == classId }).ToListAsync(),
            };
            return View(viewModel);
        }
    }
}
