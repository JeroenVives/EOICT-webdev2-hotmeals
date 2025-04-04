using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class ScheduledHotMeal
{
    public DateTime Date { get; set; }

    public int HotMealId { get; set; }

    public virtual HotMeal HotMeal { get; set; } = null!;

    public virtual ICollection<HotMealChoice> HotMealChoices { get; set; } = new List<HotMealChoice>();
}
