using Kodlama.io.Devs.Application.Features.Authentications.Commands.Login;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.Register;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationsController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            CreatedUserDto result = await Mediator.Send(registerCommand);
            return Created("", result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            AccessTokenDto result = await Mediator.Send(loginCommand);
            return Created("", result);
        }
    }
}
