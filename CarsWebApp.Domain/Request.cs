using System;
using CarsWebApp.Domain.Base;
using CarsWebApp.Domain.Contracts;

namespace CarsWebApp.Domain
{
    public class Request:BaseRequest, IBuyerContainer,IDealerContainer
    {
        public int Id { get; set; }
        
        public DateTime DateBuy { get; set; }
    }
}