using Kolokwium.Dtos;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CoursesController(ICoursesService coursesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> FindAllCourses([FromQuery] string? title, [FromQuery] string? category)
    {
        return Ok(await coursesService.FindAllCoursesAsync(title, category));
    }
}