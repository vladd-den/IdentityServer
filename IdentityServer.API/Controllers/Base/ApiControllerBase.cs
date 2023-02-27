using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
