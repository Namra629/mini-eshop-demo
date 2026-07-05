using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.API.Data;

public class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
{
    public CatalogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=CatalogDb;Username=postgres;Password=postgres"
        );

        return new CatalogDbContext(optionsBuilder.Options);
    }
}
