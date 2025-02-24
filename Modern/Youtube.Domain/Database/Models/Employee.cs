namespace Youtube.Domain.Database.Entities;

public class Employee : Person {
    public List<Faculty> Faculties { get; private set; } = [];
}