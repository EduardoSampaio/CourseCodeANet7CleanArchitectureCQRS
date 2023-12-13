using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveTypesController>
    [HttpGet]
    public async Task<List<LeaveTypeDto>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
        return leaveTypes;
    }

    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    public async Task<LeaveTypesDetailsDto> Get(int id)
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
        return leaveTypes;
    }

    // POST api/<LeaveTypesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<LeaveTypesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<LeaveTypesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
