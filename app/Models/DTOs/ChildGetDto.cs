using HotMeals.Data.School;
using HotMeals.Models.Enums;

namespace HotMeals.Models.DTOs
{
    public class ChildGetDto
    {
        public UserDto User { get; set; } = null!;
        public ClassDto Class { get; set; } = null!;
        public string FoodPreference { get; set; } = null!;
        public static ChildGetDto FromDbo(Child childDbo)
        {
            if (!Enum.TryParse(childDbo.FoodPreference, out FoodProfileEnum foodPreference))
            {
                throw new ArgumentException($"Invalid enum value \"{childDbo.FoodPreference}\".");
            }
            return new ChildGetDto
            {
                User = UserDto.FromDbo(childDbo.User),
                Class = ClassDto.FromDbo(childDbo.Class),
                FoodPreference = foodPreference.ToString()
            };
        }
    }
}
