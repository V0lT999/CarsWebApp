using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;
using Buyer = CarsWebApp.Domain.Buyer;

namespace CarsWebApp.DAL.Contracts
{
    public interface IBuyerDAL
    {
        Task<Buyer> InsertAsync(BuyerUpdateModel buyer);
        Task<IEnumerable<Buyer>> GetAsync();
        Task<Buyer> GetAsync(IBuyerIdentity buyerId);
        Task<Buyer> UpdateAsync(BuyerUpdateModel buyer);
    }
}