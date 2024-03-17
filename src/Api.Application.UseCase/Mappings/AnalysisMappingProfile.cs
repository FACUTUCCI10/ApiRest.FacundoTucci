using Api.Application.Dtos.Analysis.Response;
using Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands;
using Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands.UpdateCommands;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
            .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "Activo" : "Inactivo"))
            .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();
            CreateMap<UpdateAnalysisCommand, Analysis>();
        }
    }
}
