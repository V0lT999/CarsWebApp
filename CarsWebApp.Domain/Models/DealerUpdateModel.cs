using CarsWebApp.Domain.Base;
using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class DealerUpdateModel:BaseDealer, IDealerIdentity
    {
        public int Id { get; set; }
    }
}