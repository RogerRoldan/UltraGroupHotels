using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UltraGroupHotels.Application.Users.Login;
using UltraGroupHotels.Application.Users.Register;

namespace UltraGroupHotels.WebAPI.Controllers.Authorization;


[ApiController]
[Route("api/authorization")]
public class AuthorizationController : ApiController
{
    private ISender _mediator;

    public AuthorizationController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
            token => Ok(token),
            errors => Problem(errors)
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);

        var jsonId = new { Id = result.Value };

        return result.Match(
            success => Created(nameof(Register), jsonId),
            errors => Problem(errors)
        );
    }



}
