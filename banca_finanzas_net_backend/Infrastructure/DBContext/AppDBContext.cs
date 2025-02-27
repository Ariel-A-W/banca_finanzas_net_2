using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.DBContext;

public class AppDBContext : DbContext, IUnitOfWork
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Adapta las entidades de Domain a Models automáticamente.
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDBContext).Assembly
        );
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException(
                "Infrastructure: Fallo en la concurrencia de los datos. Detalle:", ex
            );
        }
        catch (Exception ex)
        {
            throw new ConcurrencyException(
                "Infrastructure: Fallo genérico. Detalle:", ex
            );
        }
    }
}
