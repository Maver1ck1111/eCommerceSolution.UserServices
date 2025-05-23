using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(destination => destination.UserID,
                opt => opt.MapFrom(src => src.UserID))
            .ForMember(destination => destination.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(destination => destination.PersonName,
                opt => opt.MapFrom(src => src.PersonName))
            .ForMember(destination => destination.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ForMember(destination => destination.Success,
                opt => opt.Ignore())
            .ForMember(destination => destination.Token,
                opt => opt.Ignore());

        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(destination => destination.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(destination => destination.Password,
                opt => opt.MapFrom(src => src.Password))
            .ForMember(destination => destination.PersonName,
                opt => opt.MapFrom(src => src.PersonName))
            .ForMember(destination => destination.Gender,
                opt => opt.MapFrom(src => src.Gender.ToString()))
            .ForMember(destination => destination.UserID,
                opt => opt.Ignore());
    }
}