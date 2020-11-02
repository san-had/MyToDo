using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDo.Domain.Database.Model;
using ToDo.Extensibility.Dto;

namespace ToDo.Domain.Database.Providers
{
    public class MsSqlDatabaseContext : DbContext
    {
        private readonly string sqlConnectionString;

        public MsSqlDatabaseContext(IOptionsSnapshot<ConfigurationSettings> configurationSettings)
        {
            sqlConnectionString = configurationSettings.Value.MsSqlConnectionString;
        }

        public DbSet<ToDoDbModel> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlServer(sqlConnectionString);
    }
}