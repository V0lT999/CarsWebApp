namespace CarsWebApp.Client.DTO.Read
{
    public class BuyerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string PassportNumber{ get; set; }
        
        public int CityId { get; set; }
    }
}