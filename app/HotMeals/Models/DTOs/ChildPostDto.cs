using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class ChildPostDto
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string FoodPreference { get; set; } = null!;
        public Child ToDbo()
        {
            var childDbo = new Child
            {
                UserId = UserId,
                ClassId = ClassId,
                FoodPreference = FoodPreference
            };
            return childDbo;
        }
    }
}
