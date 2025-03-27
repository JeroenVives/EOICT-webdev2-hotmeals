using HotMeals.Data.School;

namespace HotMeals.Models.DTOs
{
    public class ClassDto
    {
        public int? Id { get; set; }
        public string Description { get; set; } = null!;
        public Class ToDbo()
        {
            var classDbo = new Class
            {
                Description = Description
            };
            if (Id != null)
            {
                classDbo.Id = (int)Id;
            }
            return classDbo;
        }
        public static ClassDto FromDbo(Class classDbo)
        {
            return new ClassDto
            {
                Id = classDbo.Id,
                Description = classDbo.Description
            };
        }
    }
}
