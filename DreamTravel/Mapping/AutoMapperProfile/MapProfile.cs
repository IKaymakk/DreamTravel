using AutoMapper;
using DTOLayer.DTOs.AdminDTOs;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using DTOLayer.DTOs.DestinationDTOs;
using EntityLayer.Concrete;

namespace DreamTravel.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();

            CreateMap<AppUserRegisterDTOs, Announcement>().ReverseMap();

            CreateMap<AppUserLoginDTOs, Announcement>().ReverseMap();

            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();

            CreateMap<AnnouncementUpdateDTO, Announcement>().ReverseMap();
           
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();
            CreateMap<CreateRoleDto, AppRole>().ReverseMap();

        }
    }
}
