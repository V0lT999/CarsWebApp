using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class CarIdentityModel:ICarIdentity
    {
        public int Id { get; }

        public CarIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}