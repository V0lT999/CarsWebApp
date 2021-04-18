using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsWebApp.DAL.Entity
{
    public class Buyer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string PassportNumber{ get; set; }
        public int? CityId { get; set; }

        public List<Request> Requests { get; set; } = new List<Request>();
    }
}