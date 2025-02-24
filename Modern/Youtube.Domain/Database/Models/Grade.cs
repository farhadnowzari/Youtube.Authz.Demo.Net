namespace Youtube.Domain.Database.Entities;

public class Grade: EntityBase {
    public float Value { get; set; }
    public Guid EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }
    public Guid ProfessorId { get; set; }
    public Professor Professor { get; set; }
}