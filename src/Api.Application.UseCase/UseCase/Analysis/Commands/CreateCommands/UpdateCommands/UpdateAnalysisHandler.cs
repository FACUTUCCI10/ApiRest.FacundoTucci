using Api.application.Interface;
using Api.Application.UseCase.Commons.Bases;
using AutoMapper;
using MediatR;
using Entity = Api.Domain.Entities;

namespace Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands.UpdateCommands
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    { 
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;
        public UpdateAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;

        }
        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var Analysis = _mapper.Map<Entity.Analysis>(request);
                response.data = await _analysisRepository.AnalysisEdit(Analysis);

                if (response.data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa!";
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
