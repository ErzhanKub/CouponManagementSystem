using Application.Shared;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public record CreateUserResponse
    {
        public Guid Id { get; init; }
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required string Email { get; init; }
    }

    public record CreateUserCommand : IRequest<CreateUserResponse>
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required string Email { get; init; }
    }

    internal class CreateCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
            };

            await _userRepository.CreateAsync(user);
            await _unitOfWork.CommitAsync();

            var response = new CreateUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
            };
            return response;
        }
    }
}
