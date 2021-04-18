using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Client.DTO.Create
{
    public class BuyerCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Passport is required")]
        public string PassportNumber{ get; set; }
        [Required(ErrorMessage = "CityID is required")]
        public int CityId { get; set; }
    }
}