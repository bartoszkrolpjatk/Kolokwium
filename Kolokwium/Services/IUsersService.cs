using Kolokwium.Dtos;

namespace Kolokwium.Services;

public interface IUsersService
{
    public Task CreateUser(CreateUserDto createUserDto);
}