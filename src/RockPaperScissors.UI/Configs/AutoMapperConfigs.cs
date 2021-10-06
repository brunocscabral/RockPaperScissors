using AutoMapper;
using RockPaperScissors.Business.Models;
using RockPaperScissors.UI.ViewModels;

namespace RockPaperScissors.UI.Configs
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<Move, MoveViewModel>().ReverseMap();
        }
    }
}
