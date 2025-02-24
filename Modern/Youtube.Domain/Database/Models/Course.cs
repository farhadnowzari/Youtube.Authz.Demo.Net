namespace Youtube.Domain.Database.Entities;

public class Course: EntityBase {
    public string Name { get; set; }

    public Guid FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    public List<Professor> Professors { get; private set; } = [];
    public List<Enrollment> Enrollments { get; private set; } = [];
}