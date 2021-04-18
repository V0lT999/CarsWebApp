using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.DAL.Contracts
{
    public interface ICityDAL
    {
        Task<City> InsertAsync(CityUpdateModel city);
        Task<IEnumerable<City>> GetAsync();
        Task<City> GetAsync(ICityIdentity cityId);
        Task<City> UpdateAsync(CityUpdateModel city);
    }
}