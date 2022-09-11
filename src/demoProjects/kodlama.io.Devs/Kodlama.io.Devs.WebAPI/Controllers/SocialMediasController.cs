using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediasController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand createSocialMediaCommand)
        {
            CreatedSocialMediaDto result = await Mediator.Send(createSocialMediaCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            DeletedSocialMediaDto result = await Mediator.Send(deleteSocialMediaCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            UpdatedSocialMediaDto result = await Mediator.Send(updateSocialMediaCommand);
            return Ok(result);
        }
    }
}
