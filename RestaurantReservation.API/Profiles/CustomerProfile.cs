using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));
            CreateMap<CustomerWithoutIdDTO, Customer>();
        }
    }
}