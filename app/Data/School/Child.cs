using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class Child
{
    public int UserId { get; set; }

    public int ClassId { get; set; }

    public string FoodPreference { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<MealChoice> MealChoices { get; set; } = new List<MealChoice>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Allergen> Allergens { get; set; } = new List<Allergen>();

    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();
}
