using Identity.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.Api.Factories;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var contextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        contextOptionsBuilder.UseNpgsql(
            "Server=localhost;Port=1432;Database=IdentityDb;User Id=postgres;Password=Pass@word;",
            builder => builder.MigrationsAssembly("Identity.Api"));

        return new ApplicationDbContext(contextOptionsBuilder.Options);
    }
}