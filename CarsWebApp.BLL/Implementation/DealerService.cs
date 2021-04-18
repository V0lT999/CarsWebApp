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
    public class DealerService:IDealerService
    {
        private IDealerDAL DealerDal { get; }
        
        public DealerService(IDealerDAL dealerDal)
        {
            this.DealerDal = dealerDal;
        }
        
        public async Task<Dealer> CreateAsync(DealerUpdateModel Dealer) {
            return await this.DealerDal.InsertAsync(Dealer);
        }
        
        public async Task<Dealer> UpdateAsync(DealerUpdateModel Dealer) {
            return await this.DealerDal.UpdateAsync(Dealer);
        }
        
        public Task<IEnumerable<Dealer>> GetAsync() {
            return this.DealerDal.GetAsync();
        }
        
        public Task<Dealer> GetAsync(IDealerIdentity id)
        {
            return this.DealerDal.GetAsync(id);
        }
        
        public async Task ValidateAsync(IDealerContainer DealerContainer)
        {
            if (DealerContainer == null)
            {
                throw new ArgumentNullException(nameof(DealerContainer));
            }
     
            if (DealerContainer.DealerId.HasValue)
            {
                var department = await this.DealerDal.GetAsync(new DealerIdentityModel((int) DealerContainer.DealerId));
                if(department == null) 
                    throw new InvalidOperationException($"Dealer not found by id {DealerContainer.DealerId}");
            }
        }
    }
}