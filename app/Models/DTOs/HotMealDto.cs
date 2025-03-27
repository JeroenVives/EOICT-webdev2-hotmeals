using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class HotMealDto
    {
        public int? Id { get; set; }
        public string Description { get; set; } = null!;
        public string Recipe { get; set; } = null!;
        public HotMeal ToDbo() {
            var hotMealDbo = new HotMeal
            {
                Description = Description,
                Recipe = Recipe
            };
            if (Id != null)
            {
                hotMealDbo.Id = (int) Id;
            }
            return hotMealDbo;
        }
        public static HotMealDto FromDbo(HotMeal hotMealDbo)
        {
            return new HotMealDto
            {
                Id = hotMealDbo.Id,
                Description = hotMealDbo.Description,
                Recipe = hotMealDbo.Recipe
            };
        }
    }
}
