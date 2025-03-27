using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class Allergen
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Child> Children { get; set; } = new List<Child>();

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
