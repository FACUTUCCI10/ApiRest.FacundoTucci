using Api.Application.Dtos.Analysis.Response;
using Api.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.UseCase.UseCase.Analysis.Queries.GetAlllQuery
{
    public class GetAllAnalysisQuery : IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        public int AnalysisId { get; set; }
    }
}
