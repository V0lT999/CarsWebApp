using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class DealerIdentityModel:IDealerIdentity
    {
        public int Id { get; }

        public DealerIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}