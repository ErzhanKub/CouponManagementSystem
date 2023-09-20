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
    public record DeleteUserCommand : IRequest
    {
        public required string Username { get; init; }
    }

    internal class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _userRepository.Delete(request.Username);
             await _unitOfWork.CommitAsync();
        }
    }
}
