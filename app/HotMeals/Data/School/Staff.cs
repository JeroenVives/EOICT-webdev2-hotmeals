using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class Staff
{
    public int UserId { get; set; }

    public string Role { get; set; } = null!;

    public virtual SchoolUser User { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
