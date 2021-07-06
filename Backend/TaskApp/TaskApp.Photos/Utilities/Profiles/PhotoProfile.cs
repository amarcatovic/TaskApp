using AutoMapper;
using TaskApp.Photos.Data.Dtos;
using TaskApp.Photos.Data.Models;

namespace TaskApp.Photos.Utilities.Profiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Photo, PhotoReturnDto>();
        }
    }
}
