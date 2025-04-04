using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class Parent
{
    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Child> Children { get; set; } = new List<Child>();
}
