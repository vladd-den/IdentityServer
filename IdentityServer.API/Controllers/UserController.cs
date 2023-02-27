using IdentityServer.API.Controllers.Base;
using IdentityServer.Application.Users.Commands.CreateUser;
using IdentityServer.Application.Users.Commands.SignInUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class UserController : ApiControllerBase
    {
        public UserController()
        {

        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(CreateuserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
