using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsWebApp.BLL.Contracts;
using CarsWebApp.Client.DTO.Create;
using CarsWebApp.Client.DTO.Read;
using CarsWebApp.Client.DTO.Update;
using CarsWebApp.DAL;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/dealer")]
    public class DealerApiController : ControllerBase
    {
        private IDealerService DealerService{ get;}
        private ILogger<DealerApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public DealerApiController(ILogger<DealerApiController> logger, IMapper mapper, IDealerService dealerService)
        {
            this.Logger = logger;
            this.DealerService = dealerService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DealerDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for ");
            return this.Mapper.Map<IEnumerable<DealerDTO>>(await this.DealerService.GetAsync());
        }
        
        [HttpGet("{dealerId}")]
        public async Task<DealerDTO> GetAsync(int dealerId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<DealerDTO>(await this.DealerService.GetAsync(new DealerIdentityModel(dealerId)));
        }
        
        [HttpPatch]
        public async Task<DealerDTO> PatchAsync(DealerUpdateDto dealer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.DealerService.UpdateAsync(this.Mapper.Map<DealerUpdateModel>(dealer));
            return this.Mapper.Map<DealerDTO>(result);
        }
        
        [HttpPut]
        public async Task<DealerDTO> PutAsync(DealerCreateDTO dealer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.DealerService.CreateAsync(this.Mapper.Map<DealerUpdateModel>(dealer));
            return this.Mapper.Map<DealerDTO>(result);
        }
    }
}