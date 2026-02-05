using System;
using System.Collections.Generic;

namespace HotMeals.school;

public partial class MealIngredient
{
    public int HotMealId { get; set; }

    public int IngredientId { get; set; }

    public float Quantity { get; set; }
}
