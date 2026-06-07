using Kolokwium.Data;
using Kolokwium.Dtos;
using Kolokwium.Exceptions;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services;

public class UsersService(DbFirstContext dbContext) : IUsersService
{
    public async Task CreateUser(CreateUserDto createUserDto)
    {
        var transaction =  await dbContext.Database.BeginTransactionAsync();
        try
        {
            var duplicatedEmail = await dbContext.Users.AnyAsync(u => u.Email == createUserDto.Email);
            if (duplicatedEmail)
                throw new DuplicatedEmailException($"Email {createUserDto.Email} already exists!");

            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == createUserDto.RoleId);
            if (role == null)
                throw new NotFoundException($"Role with id {createUserDto.RoleId} does not exist");

            var user = new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email
            };
            await dbContext.Users.AddAsync(user);

            var userRole = new UserRole()
            {
                AssignedAt = DateTime.Now,
                Role = role,
                User = user
            };
            await dbContext.UserRoles.AddAsync(userRole);
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
