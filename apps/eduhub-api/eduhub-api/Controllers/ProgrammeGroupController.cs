using EduhubDotnet.Application.Features.ProgrammeGroups.Commands.CreateProgrammeGroup;
using EduhubDotnet.Application.Features.ProgrammeGroups.Commands.DeleteProgrammeGroup;
using EduhubDotnet.Application.Features.ProgrammeGroups.Commands.UpdateProgrammeGroup;
using EduhubDotnet.Application.Features.ProgrammeGroups.Queries.GetProgrammeGroupsList;
using EduhubDotnet.Application.Features.Programmes.Queries.GetProgrammesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduhubDotnet.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProgrammeGroupController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ProgrammeGroupController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("all", Name = "GetAllProgrammeGroups")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProgrammeGroupListVm>>> GetAllProgrammeGroups()
    {
      var dtos = await _mediator.Send(new GetProgrammeGroupsListQuery());
      return Ok(dtos);
    }

    [HttpPost(Name = "AddProgrammeGroup")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProgrammeGroupCommand createProgrammeGroupCommand)
    {
      var id = await _mediator.Send(createProgrammeGroupCommand);
      return Ok(id);
    }

    [HttpPut(Name = "UpdateProgrammeGroup")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateProgrammeGroupCommand updateProgrammeGroupCommand)
    {
      await _mediator.Send(updateProgrammeGroupCommand);
      return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteProgrammeGroup")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
      var deleteProgrammeGroupCommand = new DeleteProgrammeGroupCommand() { Id = id };
      await _mediator.Send(deleteProgrammeGroupCommand);
      return NoContent();
    }
  }
}
