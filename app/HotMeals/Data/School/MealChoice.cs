using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class MealChoice
{
    public DateTime Date { get; set; }

    public int ChildId { get; set; }

    public string Choice { get; set; } = null!;

    public virtual Child Child { get; set; } = null!;

    public virtual ICollection<HotMealChoice> HotMealChoices { get; set; } = new List<HotMealChoice>();
}
