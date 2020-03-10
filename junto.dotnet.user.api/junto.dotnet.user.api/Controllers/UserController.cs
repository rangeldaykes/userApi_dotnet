using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using junto.dotnet.user.api.Dominio.UseCases;
using junto.dotnet.user.api.Dominio.UseCases.AddUser;
using junto.dotnet.user.api.Dominio.UseCases.AlterPassWord;
using junto.dotnet.user.api.Dominio.UseCases.Autenticate;
using junto.dotnet.user.api.Dominio.UseCases.DeleteUser;
using junto.dotnet.user.api.Dominio.UseCases.GetUserById;
using junto.dotnet.user.api.Dominio.UseCases.ListUsers;
using junto.dotnet.user.api.Dominio.UseCases.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace junto.dotnet.user.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<UserDTO>> Get()
        {
            var result = await _mediator.Send(new ListUserCommand(), CancellationToken.None);

            return result.Data;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetUserByIdCommand { Id = id }, CancellationToken.None);

            if (result.Data != null)
                return Ok(result.Data);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommand user)
        {
            var ret = await _mediator.Send(user, CancellationToken.None);

            if (!ret.HasValidation)
                return Ok();
            else
                return BadRequest(ret);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand user)
        {
            await _mediator.Send(user, CancellationToken.None);

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteUserCommand { Id = id });

            return Ok();
        }

        [Route("{id}/changepass")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] AlterPasswordCommand alterPass, [FromRoute] int Id)
        {
            alterPass.Id = Id;
            var ret = await _mediator.Send(alterPass, CancellationToken.None);

            if (!ret.HasValidation)
                return Ok();
            else
                return NotFound(ret);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateCommand userAuthenticate)
        {
            var user = await _mediator.Send(userAuthenticate, CancellationToken.None);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user.Data);
        }
    }
}