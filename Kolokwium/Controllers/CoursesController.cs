using Kolokwium.Dtos;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CoursesController(ICoursesService coursesService) : ControllerBase
{
    [HttpGet]
    public async Task<List<CourseDto>> FindAllCourses()
    {
        return await coursesService.FindAllCoursesAsync();
    }
}