using Kolokwium.Data;
using Kolokwium.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services;

public class CoursesService(DbFirstContext dbContext) : ICoursesService
{
    public async Task<List<CourseDto>> FindAllCoursesAsync()
    {
        return await dbContext.Courses
            .Select(c => new CourseDto()
            {
                Id = c.Id,
                Title = c.Title,
                Category = new CategoryDto()
                {
                    Id = c.Category.Id,
                    Name = c.Category.Name
                },
                Instructor = new InstructorDto()
                {
                    Id = c.Instructor.Id,
                    FirstName = c.Instructor.FirstName,
                    LastName = c.Instructor.LastName
                },
                Lessons = c.Lessons.Select(l => new LessonDto()
                {
                    Id = l.Id,
                    Title = l.Title,
                    DurationMinutes = l.DurationMinutes
                }).ToList(),
                AverageRating = c.Reviews.Average(r => r.Rating)
            })
            .ToListAsync();
    }
}