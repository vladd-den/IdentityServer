using IdentityServer.Application.Common.Interfaces;
using IdentityServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignInResult = IdentityServer.Domain.Entities.SignInResult;

namespace IdentityServer.Application.Users.Commands.SignInUser
{
    public record SignInUserCommand : IRequest<SignInResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, SignInResult>
    {
        private UserManager<User> _userManager;
        private IJwtFactory _jwtFactory;

        public SignInUserCommandHandler(UserManager<User> userManager, IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }

        public async Task<SignInResult> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                SignInResult signInResult = new()
                {
                    Succeeded = false
                };

                return signInResult;
            }

            IList<string> userRoles = await _userManager.GetRolesAsync(user);

            var token = _jwtFactory.GenerateJwtToken(user, userRoles.ToList());

            SignInResult result = new()
            {
                AccessToken = token,
                Succeeded = true,
                ErrorMessage = null,
            };

            return result;
        }
    }
}
