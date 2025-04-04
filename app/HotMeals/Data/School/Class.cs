using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class Class
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Child> Children { get; set; } = new List<Child>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
