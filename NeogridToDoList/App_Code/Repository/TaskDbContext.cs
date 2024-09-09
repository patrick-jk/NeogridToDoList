using System.Data.Entity;
using Domain;
using MySql.Data.MySqlClient;

namespace Repository
{
    [DbConfigurationType(typeof(MySqlConfiguration))]
    public class TaskDbContext : DbContext
    {
        public TaskDbContext() : base("name=TaskDbConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TaskDbContext>());
        }

        public DbSet<Task> Tasks { get; set; }
    }
}