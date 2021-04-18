using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.DAL.Contracts
{
    public interface IRequestDAL
    {
        Task<Request> InsertAsync(RequestUpdateModel request);
        Task<IEnumerable<Request>> GetAsync();
        Task<Request> GetAsync(IRequestIdentity requestId);
        Task<Request> UpdateAsync(RequestUpdateModel request);
    }
}