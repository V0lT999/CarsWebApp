using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Client.DTO.Create
{
    public class CarCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set;}
    }
}