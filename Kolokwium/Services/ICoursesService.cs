using Kolokwium.Dtos;

namespace Kolokwium.Services;

public interface ICoursesService
{
    Task<List<CourseDto>> FindAllCoursesAsync();
}