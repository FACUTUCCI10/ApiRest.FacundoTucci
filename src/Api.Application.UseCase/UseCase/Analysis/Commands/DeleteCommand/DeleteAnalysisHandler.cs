using Api.application.Interface;
using Api.Application.UseCase.Commons.Bases;
using MediatR;

namespace Api.Application.UseCase.UseCase.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;

        public DeleteAnalysisHandler(IAnalysisRepository analysisRepository)
        {
            _analysisRepository = analysisRepository;
        }
        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.data = await _analysisRepository.AnalysisRemove(request.AnalysisId);

                if (response.data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
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
