namespace Youtube.Service.Database.Entities;

public class Employee : Person {
    public List<Faculty> Faculties { get; private set; } = [];
}