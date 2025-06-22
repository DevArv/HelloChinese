using HelloChinese.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloChinese.DatabaseConnection;

public class HelloChineseContext : DbContext
{
    private static readonly IConfiguration _Configuration;

    static HelloChineseContext()
    {
        _Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
    {
        var connectionString = _Configuration.GetConnectionString(name: "DefaultConnection");
        OptionsBuilder.UseNpgsql(connectionString);
    }
    
    public DbSet<Dictionary> Dictionary { get; set; }
}