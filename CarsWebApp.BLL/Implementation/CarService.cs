using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.BLL.Contracts;
using CarsWebApp.DAL.Contracts;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.BLL.Implementation
{
    public class CarService:ICarService
    {
        private ICarDAL CarDal { get; }
        
        public CarService(ICarDAL carDal)
        {
            this.CarDal = carDal;
        }
        
        public async Task<Car> CreateAsync(CarUpdateModel Car) {
            return await this.CarDal.InsertAsync(Car);
        }
        
        public async Task<Car> UpdateAsync(CarUpdateModel Car) {
            return await this.CarDal.UpdateAsync(Car);
        }
        
        public Task<IEnumerable<Car>> GetAsync() {
            return this.CarDal.GetAsync();
        }
        
        public Task<Car> GetAsync(ICarIdentity id)
        {
            return this.CarDal.GetAsync(id);
        }
        
        public async Task ValidateAsync(ICarContainer CarContainer)
        {
            if (CarContainer == null)
            {
                throw new ArgumentNullException(nameof(CarContainer));
            }
            if (CarContainer.CarId.HasValue )
            {
                var department = await this.CarDal.GetAsync(new CarIdentityModel(CarContainer.CarId.Value));
                if(department == null)
                    throw new InvalidOperationException($"Department not found by id {CarContainer.CarId}");
            }
        }
    }
}