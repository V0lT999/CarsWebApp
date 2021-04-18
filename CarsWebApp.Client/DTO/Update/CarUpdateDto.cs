using CarsWebApp.Client.DTO.Create;

namespace CarsWebApp.Client.DTO.Update
{
    public class CarUpdateDto: CarCreateDTO
    {
        public int Id { get; set; }
    }
}