using CarsWebApp.Domain.Base;
using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class BuyerUpdateModel: BaseBuyer, IBuyerIdentity, ICityContainer
    {
        public int Id { get; set; }
        public int? CityId { get; set; }
    }
}