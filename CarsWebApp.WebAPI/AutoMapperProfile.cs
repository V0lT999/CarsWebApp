using AutoMapper;
using CarsWebApp.Client.DTO;
using CarsWebApp.Client.DTO.Create;
using CarsWebApp.Client.DTO.Read;
using CarsWebApp.Client.DTO.Update;
using CarsWebApp.Domain.Models;

namespace CarsWebApp.WebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<CarsWebApp.DAL.Entity.Buyer, CarsWebApp.Domain.Buyer>();
            this.CreateMap<CarsWebApp.Domain.Buyer, BuyerDTO>();
            this.CreateMap<BuyerCreateDTO, BuyerUpdateModel>();
            this.CreateMap<BuyerUpdateDto, BuyerUpdateModel>();
            this.CreateMap<BuyerUpdateModel, CarsWebApp.DAL.Entity.Buyer>();
            
            this.CreateMap<CarsWebApp.DAL.Entity.City, CarsWebApp.Domain.City>();
            this.CreateMap<CarsWebApp.Domain.City, CityDTO>();
            this.CreateMap<CityCreateDTO, CityUpdateModel>();
            this.CreateMap<CityUpdateDto, CityUpdateModel>();
            this.CreateMap<CityUpdateModel, CarsWebApp.DAL.Entity.City>();
            
            this.CreateMap<CarsWebApp.DAL.Entity.Car, CarsWebApp.Domain.Car>();
            this.CreateMap<CarsWebApp.Domain.Car, CarDTO>();
            this.CreateMap<CarCreateDTO, CarUpdateModel>();
            this.CreateMap<CarUpdateDto, CarUpdateModel>();
            this.CreateMap<CarUpdateModel, CarsWebApp.DAL.Entity.Car>();
            
            this.CreateMap<CarsWebApp.DAL.Entity.Dealer, CarsWebApp.Domain.Dealer>();
            this.CreateMap<CarsWebApp.Domain.Dealer, DealerDTO>();
            this.CreateMap<DealerCreateDTO, DealerUpdateModel>();
            this.CreateMap<DealerUpdateDto, DealerUpdateModel>();
            this.CreateMap<DealerUpdateModel, CarsWebApp.DAL.Entity.Dealer>();
            
            this.CreateMap<CarsWebApp.DAL.Entity.Request, CarsWebApp.Domain.Request>();
            this.CreateMap<CarsWebApp.Domain.Request, RequestDTO>();
            this.CreateMap<RequestCreateDTO, RequestUpdateModel>();
            this.CreateMap<RequestUpdateDto, RequestUpdateModel>();
            this.CreateMap<RequestUpdateModel, CarsWebApp.DAL.Entity.Request>();
        }
    }
}