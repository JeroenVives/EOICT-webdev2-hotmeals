using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class HotMeal
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Recipe { get; set; } = null!;

    public virtual ICollection<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();

    public virtual ICollection<ScheduledHotMeal> ScheduledHotMeals { get; set; } = new List<ScheduledHotMeal>();
}
