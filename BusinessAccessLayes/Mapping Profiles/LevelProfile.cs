using AutoMapper;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Levels;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObjects.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Mapping_Profiles
{
    public class LevelProfile:Profile
    {
        public LevelProfile()
        {
            CreateMap<CreateOrUpdateLevelDto, Level>().
                ForMember(dest => dest.PicUrl, opt => opt.Ignore()).ReverseMap();


            CreateMap<Level,LevelDto>().
                ForMember(dist=>dist.PicUrl, src =>src.MapFrom<PictureLevelResolver<LevelDto>>());
        }
    }

    public class PictureLevelResolver<TDestination> : IValueResolver<Level, TDestination, string>
    {
        private readonly IConfiguration _configuration;

        public PictureLevelResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Level source, TDestination destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PicUrl))
                return string.Empty;

            return $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.PicUrl}";
        }
    }
}
