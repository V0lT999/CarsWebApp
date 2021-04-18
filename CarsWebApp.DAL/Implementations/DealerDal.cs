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
    public class DealerDal:IDealerDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public DealerDal(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Domain.Dealer> InsertAsync(DealerUpdateModel dealer)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Dealer>(dealer));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Dealer>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Dealer>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Dealer>>(
                await this.Context.Dealer.ToListAsync());
        }

        public async Task<Domain.Dealer> GetAsync(IDealerIdentity dealerId)
        {
            var result = await this.Get(dealerId);

            return this.Mapper.Map<Domain.Dealer>(result);
        }

        private async Task<Dealer> Get(IDealerIdentity dealer)
        {
            if (dealer == null)
            {
                throw new ArgumentNullException(nameof(dealer));
            }
            
            return await this.Context.Dealer.FirstOrDefaultAsync(x => x.Id == dealer.Id);
        }

        public async Task<Domain.Dealer> UpdateAsync(DealerUpdateModel dealer)
        {
            var existing = await this.Get(dealer);

            var result = this.Mapper.Map(dealer, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Dealer>(result);
        }
    }
}