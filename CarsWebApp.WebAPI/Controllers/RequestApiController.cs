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
    [Route("api/request")]
    public class RequestApiController:ControllerBase
    {
        private IRequestService RequestService{ get;}
        private ILogger<RequestApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public RequestApiController(ILogger<RequestApiController> logger, IMapper mapper, IRequestService requestService)
        {
            this.Logger = logger;
            this.RequestService = requestService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<RequestDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<RequestDTO>>(await this.RequestService.GetAsync());
        }
        
        [HttpGet("{requestId}")]
        public async Task<RequestDTO> GetAsync(int requestId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {requestId}");
            return this.Mapper.Map<RequestDTO>(await this.RequestService.GetAsync(new RequestIdentityModel(requestId)));
        }
        
        [HttpPatch]
        public async Task<RequestDTO> PatchAsync(RequestUpdateDto request)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.RequestService.UpdateAsync(this.Mapper.Map<RequestUpdateModel>(request));
            return this.Mapper.Map<RequestDTO>(result);
        }
        
        [HttpPut]
        public async Task<RequestDTO> PutAsync(RequestCreateDTO request)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.RequestService.CreateAsync(this.Mapper.Map<RequestUpdateModel>(request));
            return this.Mapper.Map<RequestDTO>(result);
        }
    }
}