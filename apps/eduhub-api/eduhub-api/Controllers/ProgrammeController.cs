using EduhubDotnet.Application.Features.Programmes.Queries.GetProgrammesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduhubDotnet.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProgrammeController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ProgrammeController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("all", Name = "GetAllProgrammes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProgrammeListVm>>> GetAllProgrammes()
    {
      var dtos = await _mediator.Send(new GetProgrammesListQuery());
      return Ok(dtos);
    }
  }
}
