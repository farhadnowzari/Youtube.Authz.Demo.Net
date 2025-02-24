using Microsoft.EntityFrameworkCore;
using Youtube.Domain.Database.Entities;

namespace Youtube.Domain.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; protected set; }
    public DbSet<Enrollment> Enrollments { get; protected set; }
    internal DbSet<Faculty> Faculties { get; set; }
    public DbSet<Employee> Employees { get; protected set; }
    public DbSet<Professor> Professors { get; protected set; }
    public DbSet<Student> Students { get; protected set; }
    public DbSet<Grade> Grades { get; protected set; }

    public override int SaveChanges()
    {
        SetTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity is EntityBase && entry.State == EntityState.Modified))
        {
            ((EntityBase)entry.Entity).UpdatedAt = DateTime.UtcNow;
        }
    }
}