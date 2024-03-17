using Api.Application.UseCase.Commons.Bases;
using MediatR;

namespace Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; } 
    }
}
