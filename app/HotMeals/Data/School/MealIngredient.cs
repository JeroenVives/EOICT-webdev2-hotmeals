using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class MealIngredient
{
    public int HotMealId { get; set; }

    public int IngredientId { get; set; }

    public float Quantity { get; set; }

    public virtual HotMeal HotMeal { get; set; } = null!;

    public virtual Ingredient Ingredient { get; set; } = null!;
}
