using CarsWebApp.Domain.Base;
using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain
{
    public class Buyer:BaseBuyer,ICityContainer
    {
        
        public int Id { get; set; }
        public int? CityId { get; set; }
    }
}