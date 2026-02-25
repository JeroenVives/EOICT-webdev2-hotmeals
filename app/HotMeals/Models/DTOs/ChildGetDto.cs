using HotMeals.Data.School;
using HotMeals.Models.Enums;

namespace HotMeals.Models.DTOs
{
    public class ChildGetDto
    {
        public required UserDto User { get; set; }
        public required ClassDto Class { get; set; }
        public required string FoodPreference { get; set; }
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