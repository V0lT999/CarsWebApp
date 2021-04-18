using CarsWebApp.Client.DTO.Create;

namespace CarsWebApp.Client.DTO.Update
{
    public class RequestUpdateDto:RequestCreateDTO
    {
        public int Id { get; set; }
    }
}