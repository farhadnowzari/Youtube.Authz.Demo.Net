namespace Youtube.Domain.Database.Entities;

public abstract class Person : EntityBase
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserId { get; set; }
}