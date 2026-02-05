using System;
using System.Collections.Generic;

namespace HotMeals.school;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string UnitOfMeasurement { get; set; } = null!;
}
