namespace Kolokwium.Dtos;

public class CourseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public CategoryDto Category { get; set; } = null!;

    public InstructorDto Instructor { get; set; } = null!;
    
    public double AverageRating { get; set; }

    public virtual ICollection<LessonDto> Lessons { get; set; } = [];
}