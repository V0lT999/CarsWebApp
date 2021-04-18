using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.DAL.Contracts
{
    public interface ICarDAL
    {
        Task<Car> InsertAsync(CarUpdateModel car);
        Task<IEnumerable<Car>> GetAsync();
        Task<Car> GetAsync(ICarIdentity carId);
        Task<Car> UpdateAsync(CarUpdateModel car);
    }
}