using GraphQLDemo.Api.Model.DTOs;
using GraphQLDemo.Api.Repositories.Interfaces;
using GraphQLDemo.Api.Services.Interfaces;

namespace GraphQLDemo.Api.Services
{
   public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> AddUser(string name, string email)
    {
        return await _userRepository.AddUser(name, email);
    }

    public async Task<UserDto> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        return users.Select(user => new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        }).ToList();
    }

    public async Task<IEnumerable<ContractDto>> GetContractsByUserId(Guid userId)
    {
        var contracts = await _userRepository.GetContractsByUserId(userId);
        return contracts.Select(contract => new ContractDto
        {
            Id = contract.Id,
            ContractNumber = contract.ContractNumber
        }).ToList();
    }
}

}