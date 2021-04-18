using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.BLL.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetAsync();
        Task<Request> GetAsync(IRequestIdentity id);
        Task<Request> CreateAsync(RequestUpdateModel request);
        Task<Request> UpdateAsync(RequestUpdateModel request);
    }
}