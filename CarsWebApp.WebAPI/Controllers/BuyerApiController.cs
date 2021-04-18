using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsWebApp.BLL.Contracts;
using CarsWebApp.Client.DTO;
using CarsWebApp.Client.DTO.Create;
using CarsWebApp.Client.DTO.Read;
using CarsWebApp.Client.DTO.Update;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/buyer")]
    public class BuyerApiController : ControllerBase
    {
        private IBuyerService BuyerService{ get;}
        private ILogger<BuyerApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public BuyerApiController(ILogger<BuyerApiController> logger, IMapper mapper, IBuyerService buyerService)
        {
            this.Logger = logger;
            this.BuyerService = buyerService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BuyerDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<BuyerDTO>>(await this.BuyerService.GetAsync());
        }
        
        [HttpGet("{buyerId}")]
        public async Task<BuyerDTO> GetAsync(int buyerId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {buyerId}");
            return this.Mapper.Map<BuyerDTO>(await this.BuyerService.GetAsync(new BuyerIdentityModel(buyerId)));
        }
        
        [HttpPatch]
        public async Task<BuyerDTO> PatchAsync(BuyerUpdateDto buyer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.BuyerService.UpdateAsync(this.Mapper.Map<BuyerUpdateModel>(buyer));
            return this.Mapper.Map<BuyerDTO>(result);
        }
        
        [HttpPut]
        public async Task<BuyerDTO> PutAsync(BuyerCreateDTO buyer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.BuyerService.CreateAsync(this.Mapper.Map<BuyerUpdateModel>(buyer));
            return this.Mapper.Map<BuyerDTO>(result);
        }
    }
}