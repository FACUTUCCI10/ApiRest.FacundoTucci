using Api.application.Interface;
using Api.Application.Dtos.Analysis.Response;
using Api.Application.UseCase.Commons.Bases;
using AutoMapper;
using MediatR;

namespace Api.Application.UseCase.UseCase.Analysis.Queries.GetAlllQuery
{
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {  
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;
        public GetAllAnalysisHandler(IAnalysisRepository analysisRepository,IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>();

            try
            {
                var analysis = await _analysisRepository.ListAnalysis();
                if (analysis is not null)
                {
                    response.IsSuccess = true;
                    response.data=_mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {

                response.Message= ex.Message;
            }
            return response;
        }
    }
}
