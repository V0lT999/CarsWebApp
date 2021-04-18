using System;
using CarsWebApp.Client.DTO.Create;
using CarsWebApp.Domain;

namespace CarsWebApp.Client.DTO.Read
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public int DealerId { get; set; }
        public int BuyerId { get; set; }
        public int CarId { get; set; }
        
        public DateTime DateBuy { get; set; }
    }
}