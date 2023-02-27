using IdentityServer.Application.Common.Interfaces;
using IdentityServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Users.Commands.CreateUser
{
    public record CreateuserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateuserCommand, string>
    {
        public IApplicationDbContext _context;
        public UserManager<User> _userManager;

        public CreateUserCommandHandler(IApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<string> Handle(CreateuserCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.FirstName + '.' + request.LastName,
            };

            await _userManager.CreateAsync(user, request.Password);
            await _userManager.AddToRoleAsync(user, request.Role);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
