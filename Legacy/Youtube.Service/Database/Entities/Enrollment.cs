namespace Youtube.Service.Database.Entities;

public class Enrollment: EntityBase {
    public Guid StudentId { get; set; }
    public Student Student { get; set; }

    public Guid CourseId { get; set; }
    public Course Course { get; set; }

    public List<Grade> Grades { get; private set; } = [];
}