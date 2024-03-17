using Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands;
using Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands.UpdateCommands;
using Api.Application.UseCase.UseCase.Analysis.Commands.DeleteCommand;
using Api.Application.UseCase.UseCase.Analysis.Queries.GetAlllQuery;
using Api.Application.UseCase.UseCase.Analysis.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ListAnalysis()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());
            return Ok(response);
        }
        [HttpGet("{AnalysisId:int}")]
        public async Task<IActionResult> AnalysisById(int AnalysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId=AnalysisId });

            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditAnalysis([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("Remove/{AnalysisId:int}")]
        public async Task<IActionResult> RemoveAnalysis(int AnalysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = AnalysisId });
           
            return Ok(response);
        }
    }
}
