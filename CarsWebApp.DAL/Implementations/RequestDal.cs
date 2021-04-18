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
    public class RequestDal:IRequestDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public RequestDal(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Domain.Request> InsertAsync(RequestUpdateModel request)
        {
            Request new_obj = this.Mapper.Map<Request>(request);
            new_obj.DateBuy = DateTime.Today;
            var result = await this.Context.AddAsync(new_obj);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Request>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Request>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Request>>(
                await this.Context.Request.ToListAsync());
        }

        public async Task<Domain.Request> GetAsync(IRequestIdentity requestId)
        {
            var result = await this.Get(requestId);

            return this.Mapper.Map<Domain.Request>(result);
        }

        private async Task<Request> Get(IRequestIdentity request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            
            return await this.Context.Request.FirstOrDefaultAsync(x => x.Id == request.Id);
        }

        public async Task<Domain.Request> UpdateAsync(RequestUpdateModel request)
        {
            var existing = await this.Get(request);
            
            var result = this.Mapper.Map(request, existing);
            
            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Request>(result);
        }
    }
}