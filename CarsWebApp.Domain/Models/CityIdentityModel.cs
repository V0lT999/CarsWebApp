using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class CityIdentityModel:ICityIdentity
    {
        public int Id { get; }

        public CityIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}