using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string UnitOfMeasurement { get; set; } = null!;

    public virtual ICollection<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();

    public virtual ICollection<Allergen> Allergens { get; set; } = new List<Allergen>();
}
