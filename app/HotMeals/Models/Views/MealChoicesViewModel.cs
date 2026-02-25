using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotMeals.Models.Views
{
    public class MealChoicesViewModel
    {
        public required List<(string, int)> HotMealCounts { get; set; }
        public required List<SelectListItem> DateChoices { get; set; }
    }
}
