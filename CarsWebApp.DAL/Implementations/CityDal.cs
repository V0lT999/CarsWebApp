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
    public class CityDal:ICityDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public CityDal(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Domain.City> InsertAsync(CityUpdateModel city)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<City>(city));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.City>(result.Entity);
        }

        public async Task<IEnumerable<Domain.City>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.City>>(
                await this.Context.City.ToListAsync());
        }

        public async Task<Domain.City> GetAsync(ICityIdentity cityId)
        {
            var result = await this.Get(cityId);

            return this.Mapper.Map<Domain.City>(result);
        }

        private async Task<City> Get(ICityIdentity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            
            return await this.Context.City.FirstOrDefaultAsync(x => x.Id == city.Id);
        }

        public async Task<Domain.City> UpdateAsync(CityUpdateModel city)
        {
            var existing = await this.Get(city);

            var result = this.Mapper.Map(city, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.City>(result);
        }
    }
}