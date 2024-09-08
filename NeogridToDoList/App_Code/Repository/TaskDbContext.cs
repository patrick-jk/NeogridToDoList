using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System.Data.Entity;

[DbConfigurationType(typeof(MySqlConfiguration))]
public class TaskDbContext : DbContext
{
    public TaskDbContext() : base("name=TaskDbConnection")
    {
        Database.SetInitializer(new CreateDatabaseIfNotExists<TaskDbContext>());
    }

    public DbSet<Task> Tasks { get; set; }
}