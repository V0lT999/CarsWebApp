using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.BLL.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAsync();
        Task<Car> GetAsync(ICarIdentity id);
        Task<Car> CreateAsync(CarUpdateModel car);
        Task<Car> UpdateAsync(CarUpdateModel car);
        Task ValidateAsync(ICarContainer carContainer);
    }
}