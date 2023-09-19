using Application.Shared;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public record GetResponse
    {
        public Guid Id { get; init; }
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required string Email { get; init; }
    }


    public record GetAllQuery : IRequest<IEnumerable<GetResponse>>
    {

    }
    public record GetByUsernameQuery : IRequest<GetResponse>
    {
        public required string Username { get; init; }
    }

    internal class GetByUsernameHabdler : IRequestHandler<GetByUsernameQuery, GetResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetByUsernameHabdler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetResponse> Handle(GetByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            var response = new GetResponse
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
            };
            return response;
        }
    }

    internal class GetAllRequestHandler : IRequestHandler<GetAllQuery, IEnumerable<GetResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GetResponse>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            List<GetResponse> responses = new();

            foreach (var user in users)
            {
                var responce = new GetResponse
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                };
                responses.Add(responce);
            }
            return responses;
        }
    }
}
