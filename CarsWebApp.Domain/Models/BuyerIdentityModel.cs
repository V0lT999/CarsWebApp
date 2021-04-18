using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class BuyerIdentityModel:IBuyerIdentity
    {
        public int Id { get; }

        public BuyerIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}