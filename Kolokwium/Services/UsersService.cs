using Kolokwium.Data;
using Kolokwium.Dtos;
using Kolokwium.Exceptions;

namespace Kolokwium.Services;

public class UsersService(DbFirstContext dbContext) : IUsersService
{
    public async Task CreateUser(CreateUserDto createUserDto)
    {
        var transaction =  await dbContext.Database.BeginTransactionAsync();
        try
        {
            var duplicatedEmail = dbContext.Users.Any(u => u.Email == createUserDto.Email);
            throw new DuplicatedEmailException($"Email {createUserDto.Email} already exists!");
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}