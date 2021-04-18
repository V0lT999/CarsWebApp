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
    public class RequestService:IRequestService
    {
        private IRequestDAL RequestDal { get; }
        private IBuyerService BuyerService { get; }
        private IDealerService DealerService { get; }
        private ICarService CarService { get; }
        public RequestService(IRequestDAL requestDal, IBuyerService buyerService, IDealerService dealerService, ICarService carService)
        {
            this.RequestDal = requestDal;
            this.BuyerService = buyerService;
            this.DealerService = dealerService;
            this.CarService = carService;
        }
        
        public async Task<Request> CreateAsync(RequestUpdateModel request) {
            await this.BuyerService.ValidateAsync(request);
            await this.DealerService.ValidateAsync(request);
            await this.CarService.ValidateAsync(request);
            return await this.RequestDal.InsertAsync(request);
        }
        
        public async Task<Request> UpdateAsync(RequestUpdateModel request) {
            return await this.RequestDal.UpdateAsync(request);
        }
        
        public Task<IEnumerable<Request>> GetAsync() {
            return this.RequestDal.GetAsync();
        }
        
        public Task<Request> GetAsync(IRequestIdentity id)
        {
            return this.RequestDal.GetAsync(id);
        }
    }
}