using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDo.Domain.Database.Model;
using ToDo.Extensibility.Dto;

namespace ToDo.Domain.Database.Providers
{
    public class MsSqlLiteDatabaseContext : DbContext
    {
        private readonly string sqlLiteConnectionString;

        public MsSqlLiteDatabaseContext(IOptionsSnapshot<ConfigurationSettings> configurationSettings)
        {
            sqlLiteConnectionString = configurationSettings.Value.SqlLiteConnectionString;
        }

        public DbSet<ToDoDbModel> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlite(sqlLiteConnectionString);
    }
}