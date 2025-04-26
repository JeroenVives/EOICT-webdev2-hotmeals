using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public SchoolUser ToDbo()
        {
            var userDbo = new SchoolUser
            {
                FirstName = FirstName,
                LastName = LastName
            };
            if (Id != null)
            {
                userDbo.Id = (int)Id;
            }
            return userDbo;
        }
        public static UserDto FromDbo(SchoolUser userDbo)
        {
            return new UserDto
            {
                Id = userDbo.Id,
                FirstName = userDbo.FirstName,
                LastName = userDbo.LastName
            };
        }
    }
}
