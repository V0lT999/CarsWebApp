using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsWebApp.BLL.Contracts;
using CarsWebApp.Client.DTO.Create;
using CarsWebApp.Client.DTO.Update;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/city")]
    public class CityApiController: ControllerBase
    {
        private ICityService CityService{ get;}
        private ILogger<CityApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public CityApiController(ILogger<CityApiController> logger, IMapper mapper, ICityService cityService)
        {
            this.Logger = logger;
            this.CityService = cityService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CityDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<CityDTO>>(await this.CityService.GetAsync());
        }
        
        [HttpGet("{cityId}")]
        public async Task<CityDTO> GetAsync(int cityId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {cityId}");
            return this.Mapper.Map<CityDTO>(await this.CityService.GetAsync(new CityIdentityModel(cityId)));
        }
        
        [HttpPatch]
        public async Task<CityDTO> PatchAsync(CityUpdateDto city)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.CityService.UpdateAsync(this.Mapper.Map<CityUpdateModel>(city));
            return this.Mapper.Map<CityDTO>(result);
        }
        
        [HttpPut]
        public async Task<CityDTO> PutAsync(CityCreateDTO city)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.CityService.CreateAsync(this.Mapper.Map<CityUpdateModel>(city));
            return this.Mapper.Map<CityDTO>(result);
        }
    }
}