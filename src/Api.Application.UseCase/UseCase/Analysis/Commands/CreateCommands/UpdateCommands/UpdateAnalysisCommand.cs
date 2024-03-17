using Api.Application.UseCase.Commons.Bases;
using MediatR;

namespace Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands.UpdateCommands
{
    public class UpdateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
    }
}
