using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class HotMealDto
    {
        public int? Id { get; set; }
        public required string Description { get; set; }
        public required string Recipe { get; set; }
        public HotMeal ToDbo()
        {
            var hotMealDbo = new HotMeal
            {
                Description = Description,
                Recipe = Recipe
            };
            if (Id != null)
            {
                hotMealDbo.Id = (int)Id;
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