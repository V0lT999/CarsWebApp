using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.BLL.Contracts
{
    public interface IDealerService
    {
        Task<IEnumerable<Dealer>> GetAsync();
        Task<Dealer> GetAsync(IDealerIdentity id);
        Task<Dealer> CreateAsync(DealerUpdateModel dealer);
        Task<Dealer> UpdateAsync(DealerUpdateModel dealer);
        Task ValidateAsync(IDealerContainer dealerContainer);
    }
}