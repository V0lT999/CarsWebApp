using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarsWebApp.DAL.Contracts;
using CarsWebApp.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.DAL.Implementations
{
    public class CarDal:ICarDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public CarDal(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Domain.Car> InsertAsync(CarUpdateModel car)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Car>(car));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Car>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Car>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Car>>(
                await this.Context.Car.ToListAsync());
        }

        public async Task<Domain.Car> GetAsync(ICarIdentity carId)
        {
            var result = await this.Get(carId);

            return this.Mapper.Map<Domain.Car>(result);
        }

        private async Task<Car> Get(ICarIdentity car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            
            return await this.Context.Car.FirstOrDefaultAsync(x => x.Id == car.Id);
        }

        public async Task<Domain.Car> UpdateAsync(CarUpdateModel car)
        {
            var existing = await this.Get(car);

            var result = this.Mapper.Map(car, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Car>(result);
        }
    }
}