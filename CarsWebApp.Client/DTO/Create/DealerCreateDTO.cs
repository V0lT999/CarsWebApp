using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Client.DTO.Create
{
    public class DealerCreateDTO
    {
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }
        public string Address { get; set; }
    }
}