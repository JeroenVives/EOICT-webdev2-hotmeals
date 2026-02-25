using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class ChildPostDto
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public required string FoodPreference { get; set; }
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