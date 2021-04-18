using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.BLL.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAsync();
        Task<City> GetAsync(ICityIdentity id);
        Task<City> CreateAsync(CityUpdateModel city);
        Task<City> UpdateAsync(CityUpdateModel city);
        Task ValidateAsync(ICityContainer cityContainer);
    }
}