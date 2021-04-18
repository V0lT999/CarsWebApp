using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.BLL.Contracts
{
    public interface IBuyerService
    {
        Task<IEnumerable<Buyer>> GetAsync();
        Task<Buyer> GetAsync(IBuyerIdentity id);
        Task<Buyer> CreateAsync(BuyerUpdateModel buyer);
        Task<Buyer> UpdateAsync(BuyerUpdateModel buyer);
        Task ValidateAsync(IBuyerContainer buyerContainer);
    }
}