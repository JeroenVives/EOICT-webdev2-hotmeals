using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class UserDto
    {
        public int? Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

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

        public static UserDto FromDbo(SchoolUser user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
