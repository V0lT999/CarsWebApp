using CarsWebApp.Domain.Base;
using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class CarUpdateModel: BaseCar, ICarIdentity
    {
        public int Id { get; set; }
    }
}