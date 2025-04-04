using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public User ToDbo()
        {
            var userDbo = new User
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
        public static UserDto FromDbo(User userDbo)
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
