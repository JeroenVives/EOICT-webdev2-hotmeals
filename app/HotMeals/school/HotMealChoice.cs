using System;
using System.Collections.Generic;

namespace HotMeals.school;

public partial class HotMealChoice
{
    public DateTime Date { get; set; }

    public int MealChoiceChildId { get; set; }

    public int HotMealId { get; set; }
}
