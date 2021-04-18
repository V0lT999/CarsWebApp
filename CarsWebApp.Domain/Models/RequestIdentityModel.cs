using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class RequestIdentityModel:IRequestIdentity
    {
        public int Id { get; }

        public RequestIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}