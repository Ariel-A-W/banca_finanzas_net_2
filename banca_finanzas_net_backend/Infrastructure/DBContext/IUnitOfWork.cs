namespace banca_finanzas_net.Infrastructure.DBContext;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
