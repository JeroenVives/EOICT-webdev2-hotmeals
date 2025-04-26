using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HotMeals.Data.School;

public partial class SchoolUser : IdentityUser<int>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual Child? Child { get; set; }

    public virtual Parent? Parent { get; set; }

    public virtual Staff? Staff { get; set; }
}
