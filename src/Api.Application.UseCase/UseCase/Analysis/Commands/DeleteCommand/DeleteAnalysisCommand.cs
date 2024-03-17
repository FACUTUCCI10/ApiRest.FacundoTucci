using Api.Application.UseCase.Commons.Bases;
using MediatR;

namespace Api.Application.UseCase.UseCase.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}
