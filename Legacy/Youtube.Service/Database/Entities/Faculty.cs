namespace Youtube.Service.Database.Entities;

public class Faculty : EntityBase
{
    public string Name { get; set; }
    public Guid? ManagerId { get; set; }
    public Employee Manager { get; set; }

    public List<Course> Courses { get; init; } = [];
}