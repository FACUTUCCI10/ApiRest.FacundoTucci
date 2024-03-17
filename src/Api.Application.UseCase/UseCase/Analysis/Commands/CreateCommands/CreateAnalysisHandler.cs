using Api.application.Interface;
using Api.Application.UseCase.Commons.Bases;
using AutoMapper;
using MediatR;
using Entity = Api.Domain.Entities;

namespace Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public CreateAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
                _analysisRepository = analysisRepository;
                _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
           var response = new BaseResponse<bool>();
            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.data = await _analysisRepository.AnalysisRegister(analysis);
                if (response.data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se registró correctamente!";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
