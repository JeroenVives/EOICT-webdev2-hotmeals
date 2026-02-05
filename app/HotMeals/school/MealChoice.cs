using System;
using System.Collections.Generic;

namespace HotMeals.school;

public partial class MealChoice
{
    public DateTime Date { get; set; }

    public int ChildId { get; set; }

    public string Choice { get; set; } = null!;
}
