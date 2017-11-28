using AutoMapper;
using Muzzo.Main.Dtos;
using Muzzo.Main.Models;

namespace Muzzo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<ApplicationUser, UserDto>();
                CreateMap<Gig, GigDto>();
                CreateMap<Notification, NotificationDto>();
            

            //configStack = new MapperConfiguration(cfg => { cfg.CreateMap<StackInfoVM, StackNameVM>()
            //.ForMember(dest => dest.stackId, opts => opts.MapFrom(src => src.itemId)); } );

        }




    }
}