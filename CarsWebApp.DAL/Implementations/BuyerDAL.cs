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
    public class BuyerDAL:IBuyerDAL 
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public BuyerDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Domain.Buyer> InsertAsync(BuyerUpdateModel buyer)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Buyer>(buyer));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Buyer>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Buyer>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Buyer>>(
                await this.Context.Buyer.ToListAsync());
        }

        public async Task<Domain.Buyer> GetAsync(IBuyerIdentity buyerId)
        {
            var result = await this.Get(buyerId);

            return this.Mapper.Map<Domain.Buyer>(result);
        }

        private async Task<Buyer> Get(IBuyerIdentity Buyer)
        {
            if (Buyer == null)
            {
                throw new ArgumentNullException(nameof(Buyer));
            }
            
            return await this.Context.Buyer.FirstOrDefaultAsync(x => x.Id == Buyer.Id);
        }

        public async Task<Domain.Buyer> UpdateAsync(BuyerUpdateModel buyer)
        {
            var existing = await this.Get(buyer);

            var result = this.Mapper.Map(buyer, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Buyer>(result);
        }
    }
}