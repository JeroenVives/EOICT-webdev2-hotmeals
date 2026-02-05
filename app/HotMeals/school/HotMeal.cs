using System;
using System.Collections.Generic;

namespace HotMeals.school;

public partial class HotMeal
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Recipe { get; set; } = null!;
}
