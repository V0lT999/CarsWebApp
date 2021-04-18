using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Client.DTO.Create
{
    public class CityCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Annotation { get; set;}
    }
}