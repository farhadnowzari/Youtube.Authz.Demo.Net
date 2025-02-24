namespace Youtube.Service.Database.Entities;

public class Student : Person {
    public List<Enrollment> Enrollments { get; private set; } = [];
}