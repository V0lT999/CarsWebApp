using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsWebApp.DAL.Entity
{
    public class Dealer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Brand { get; set; }

        public string Address { get; set; }
        
        public List<Dealer> Buyers { get; set; } = new List<Dealer>();
    }
}