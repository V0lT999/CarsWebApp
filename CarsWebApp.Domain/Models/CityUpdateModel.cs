using CarsWebApp.Domain.Base;
using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class CityUpdateModel:BaseCity, ICityIdentity
    {
        public int Id { get; set; }
    }
}