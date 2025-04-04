using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class ScheduledHotMealDto
    {
        public DateTime Date { get; set; }
        public HotMealDto HotMeal { get; set; } = null!;
        public ScheduledHotMeal ToDbo()
        {
            return new ScheduledHotMeal
            {
                Date = Date,
                HotMealId = HotMeal.ToDbo().Id
            };
        }
        public static ScheduledHotMealDto FromDbo(ScheduledHotMeal scheduledHotMeal)
        {
            return new ScheduledHotMealDto
            {
                Date = scheduledHotMeal.Date,
                HotMeal = HotMealDto.FromDbo(scheduledHotMeal.HotMeal)
            };
        }
    }
}
