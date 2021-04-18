using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsWebApp.BLL.Contracts;
using CarsWebApp.Client.DTO.Create;
using CarsWebApp.Client.DTO.Read;
using CarsWebApp.Client.DTO.Update;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarApiController: ControllerBase
    {
        private ICarService CarService{ get;}
        private ILogger<CarApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public CarApiController(ILogger<CarApiController> logger, IMapper mapper, ICarService carService)
        {
            this.Logger = logger;
            this.CarService = carService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CarDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<CarDTO>>(await this.CarService.GetAsync());
        }
        
        [HttpGet("{carId}")]
        public async Task<CarDTO> GetAsync(int carId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {carId}");
            return this.Mapper.Map<CarDTO>(await this.CarService.GetAsync(new CarIdentityModel(carId)));
        }
        
        [HttpPatch]
        public async Task<CarDTO> PatchAsync(CarUpdateDto car)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.CarService.UpdateAsync(this.Mapper.Map<CarUpdateModel>(car));
            return this.Mapper.Map<CarDTO>(result);
        }
        
        [HttpPut]
        public async Task<CarDTO> PutAsync(CarCreateDTO car)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.CarService.CreateAsync(this.Mapper.Map<CarUpdateModel>(car));
            return this.Mapper.Map<CarDTO>(result);
        }
    }
}