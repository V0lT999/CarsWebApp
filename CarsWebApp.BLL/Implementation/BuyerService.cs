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
    public class BuyerService: IBuyerService
    {
        private IBuyerDAL BuyerDAL { get; }
        private ICityService CityService { get; }
        
        public BuyerService(IBuyerDAL BuyerDAL, ICityService cityService)
        {
            this.BuyerDAL = BuyerDAL;
            this.CityService = cityService;
        }
        
        public async Task<Buyer> CreateAsync(BuyerUpdateModel buyer) {
            await this.CityService.ValidateAsync(buyer);
            return await this.BuyerDAL.InsertAsync(buyer);
        }
        
        public async Task<Buyer> UpdateAsync(BuyerUpdateModel buyer) {
            await this.CityService.ValidateAsync(buyer);
            return await this.BuyerDAL.UpdateAsync(buyer);
        }
        
        public Task<IEnumerable<Buyer>> GetAsync() {
            return this.BuyerDAL.GetAsync();
        }
        
        public Task<Buyer> GetAsync(IBuyerIdentity id)
        {
            return this.BuyerDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IBuyerContainer BuyerContainer)
        {
            if (BuyerContainer == null)
            {
                throw new ArgumentNullException(nameof(BuyerContainer));
            }
            if (BuyerContainer.BuyerId.HasValue)
            {
                var department = await this.BuyerDAL.GetAsync(new BuyerIdentityModel(BuyerContainer.BuyerId.Value));
                if( department == null)
                    throw new InvalidOperationException($"Department not found by id {BuyerContainer.BuyerId}");
            }
        }
    }
}