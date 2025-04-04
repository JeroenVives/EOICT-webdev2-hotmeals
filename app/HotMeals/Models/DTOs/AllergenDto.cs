using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class AllergenDto
    {
        public int? Id { get; set; }
        public string Description { get; set; } = null!;
        public Allergen ToDbo()
        {
            var allergenDbo = new Allergen
            {
                Description = Description
            };
            if (Id != null)
            {
                allergenDbo.Id = (int)Id;
            }
            return allergenDbo;
        }
        public static AllergenDto FromDbo(Allergen allergenDbo)
        {
            return new AllergenDto
            {
                Id = allergenDbo.Id,
                Description = allergenDbo.Description
            };
        }
    }
}
