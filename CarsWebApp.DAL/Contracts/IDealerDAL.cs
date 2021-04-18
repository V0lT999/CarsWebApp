using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.DAL.Contracts
{
    public interface IDealerDAL
    {
        Task<Dealer> InsertAsync(DealerUpdateModel dealer);
        Task<IEnumerable<Dealer>> GetAsync();
        Task<Dealer> GetAsync(IDealerIdentity dealerId);
        Task<Dealer> UpdateAsync(DealerUpdateModel dealer);
    }
}