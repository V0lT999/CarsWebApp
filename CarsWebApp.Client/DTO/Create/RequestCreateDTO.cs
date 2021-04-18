using System.ComponentModel.DataAnnotations;
using CarsWebApp.Domain;

namespace CarsWebApp.Client.DTO.Create
{
    public class RequestCreateDTO
    {
        [Required(ErrorMessage = "DealerId is required")]
        public int DealerId { get; set; }
        [Required(ErrorMessage = "BuyerId is required")]
        public int BuyerId { get; set; }
        [Required(ErrorMessage = "CarId is required")]
        public int CarId { get; set; }
    }
}