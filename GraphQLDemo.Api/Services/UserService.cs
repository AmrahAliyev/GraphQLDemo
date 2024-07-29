using GraphQLDemo.Api.Model.DTOs;
using GraphQLDemo.Api.Repositories.Interfaces;
using GraphQLDemo.Api.Services.Interfaces;

namespace GraphQLDemo.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService([Service]IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddUser(string name, string email)
        {
          return await _userRepository.AddUser(name,email);
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            return new UserDto()
            {
                Id = user.Id,
                Contracts = user.Contracts.Select(x =>
                {
                    return new ContractDto()
                    {
                        Id = x.Id,
                        ContractNumber = x.ContractNumber,
                    };
                }),
                Email = user.Email,
                Name = user.Name,
            };
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Contracts = user?.Contracts?.Select(contract => new ContractDto
                {
                    Id = contract.Id,
                    ContractNumber = contract.ContractNumber
                }).ToList()
            }).ToList();
        }
    }
}