namespace ToDo.Extensibility.Dto
{
    public class ConfigurationSettings
    {
        public string SqlLiteConnectionString { get; set; }

        public string MsSqlConnectionString { get; set; }

        public int PageSize { get; set; }
    }
}