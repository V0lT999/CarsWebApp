using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsWebApp.DAL.Entity
{
    public class Request
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
        public DateTime DateBuy { get; set; }
    }
}