namespace Youtube.Service.Database.Entities;

public class Professor: Person {
    public List<Course> Courses { get; private set; } = [];
    public List<Grade> Grades { get; private set; } = [];   
}