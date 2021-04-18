using CarsWebApp.Domain.Base;
using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain.Models
{
    public class RequestUpdateModel:BaseRequest, IRequestIdentity, IBuyerContainer,IDealerContainer, ICarContainer
    {
        public int Id { get; set; }
        
    }
}