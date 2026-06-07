using Kolokwium.Dtos;
using Kolokwium.Exceptions;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController(IUsersService usersService) : ControllerBase
{
    [HttpPost("/register")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        try
        {
            await usersService.CreateUser(createUserDto);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (DuplicatedEmailException e)
        {
            return BadRequest(e.Message);
        }
    }
}