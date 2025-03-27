using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class HotMealChoice
{
    public DateTime Date { get; set; }

    public int MealChoiceChildId { get; set; }

    public int HotMealId { get; set; }

    public virtual MealChoice MealChoice { get; set; } = null!;

    public virtual ScheduledHotMeal ScheduledHotMeal { get; set; } = null!;
}
