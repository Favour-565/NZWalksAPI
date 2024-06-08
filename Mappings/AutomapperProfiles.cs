using AutoMapper;
using NzApp.Model.Domain;
using NzApp.Model.Dtos;

namespace NzApp.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles() 
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
           
        }
    }
}
