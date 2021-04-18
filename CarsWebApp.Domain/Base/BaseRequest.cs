using System;

namespace CarsWebApp.Domain.Base
{
    public class BaseRequest
    {
        public int? BuyerId { get; set; }
        public int? DealerId { get; set; }
        
        public int? CarId { get; set; }
    
    }
}