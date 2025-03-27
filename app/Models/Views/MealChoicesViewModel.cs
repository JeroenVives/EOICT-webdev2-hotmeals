using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotMeals.Models.Views
{
    public class MealChoicesViewModel
    {
        public List<(string, int)> HotMealCounts { get; set; } = null!;
        public List<SelectListItem> DateChoices { get; set; } = null!;
    }
}
