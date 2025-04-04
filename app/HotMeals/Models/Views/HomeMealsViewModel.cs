using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotMeals.Models.Views
{
    public class HomeMealsViewModel
    {
        public List<(string, string)> ChildrenNames { get; set; } = null!;
        public List<SelectListItem> ClassChoices { get; set; } = null!;
    }
}
