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
    public class CityService:ICityService
    {
        private ICityDAL CityDal { get; }
        
        public CityService(ICityDAL cityDal)
        {
            this.CityDal = cityDal;
        }
        
        public async Task<City> CreateAsync(CityUpdateModel city) {
            return await this.CityDal.InsertAsync(city);
        }
        
        public async Task<City> UpdateAsync(CityUpdateModel city) {
            return await this.CityDal.UpdateAsync(city);
        }
        
        public Task<IEnumerable<City>> GetAsync() {
            return this.CityDal.GetAsync();
        }
        
        public Task<City> GetAsync(ICityIdentity id)
        {
            return this.CityDal.GetAsync(id);
        }
        public async Task ValidateAsync(ICityContainer cityContainer){
            if (cityContainer == null)
            {
                throw new ArgumentNullException(nameof(cityContainer));
            }
            else
            {
                if (cityContainer.CityId.HasValue)
                {
                    var department = await this.CityDal.GetAsync(new CityIdentityModel(cityContainer.CityId.Value));
                    if (department == null)
                        throw new InvalidOperationException($"City not found by id {cityContainer.CityId}");
                }
            }
        }
    }
}