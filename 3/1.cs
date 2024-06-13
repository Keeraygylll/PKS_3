using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

public class YourDbContext : DbContext
{
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<EducationalProgram> EducationalPrograms { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<SubjectRequirement> SubjectRequirements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("my_database");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new YourDbContext())
        {
            // Пример выполнения запроса на выборку всех факультетов
            var faculties = context.Faculties.ToList();
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"FacultyId: {faculty.FacultyId}, Name: {faculty.Name}");
            }
        }
    }
}
