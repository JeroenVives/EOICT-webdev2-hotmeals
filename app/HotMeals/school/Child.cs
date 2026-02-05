using System;
using System.Collections.Generic;

namespace HotMeals.school;

public partial class Child
{
    public int UserId { get; set; }

    public int ClassId { get; set; }

    public string FoodPreference { get; set; } = null!;
}
