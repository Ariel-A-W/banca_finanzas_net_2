using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.PlazosFijos;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class PlazosFijosRepository : ICRUD<PlazoFijo>
{
    private readonly AppDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<PlazoFijo> _dbSet;

    public PlazosFijosRepository(AppDBContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<PlazoFijo>();
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<PlazoFijo> GetList()
    {
        return _dbSet.ToList();
    }

    public PlazoFijo GetById(int value)
    {
        return _dbSet.SingleOrDefault(x => x.Plazofijo_Id == value)!;
    }

    public PlazoFijo GetByUUID(Guid value)
    {
        return _dbSet.SingleOrDefault(x => x.Plazofijo_UUID == value)!;
    }

    public Task<int> Add(PlazoFijo entity, CancellationToken cancellationToken)
    {
        try
        {
            _dbSet.Add(
                new PlazoFijo() 
                { 
                    Plazofijo_Id = entity.Plazofijo_Id, 
                    Plazofijo_UUID = entity.Plazofijo_UUID, 
                    Nrocuenta = entity.Nrocuenta, 
                    Cliente_Id = entity.Cliente_Id, 
                    Monto = entity.Monto, 
                    Plazo = entity.Plazo, 
                    Interes = entity.Interes, 
                    Capital = entity.Capital, 
                    Fecha_Inicio = entity.Fecha_Inicio, 
                    Fecha_Vencimiento = entity.Fecha_Vencimiento, 
                    Active = entity.Active
                }    
            );
            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }

    public Task<int> Delete(int value, CancellationToken cancellationToken)
    {
        try
        {
            var plazoFijo = _dbSet.FirstOrDefault(x => x.Plazofijo_Id == value);

            if (plazoFijo == null)
                return Task<int>.FromResult(0);

            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }

    public Task<int> Update(PlazoFijo entity, CancellationToken cancellationToken)
    {
        try
        {
            var plazoFijo = _dbSet.FirstOrDefault(x => x.Plazofijo_Id == entity.Plazofijo_Id);

            if (plazoFijo == null)
                return Task<int>.FromResult(0);

            plazoFijo.Plazofijo_Id = entity.Plazofijo_Id;
            plazoFijo.Plazofijo_UUID = entity.Plazofijo_UUID;
            plazoFijo.Nrocuenta = entity.Nrocuenta;
            plazoFijo.Cliente_Id = entity.Cliente_Id;
            plazoFijo.Monto = entity.Monto;
            plazoFijo.Interes = entity.Interes;
            plazoFijo.Capital = entity.Capital;
            plazoFijo.Fecha_Inicio = entity.Fecha_Inicio;
            plazoFijo.Fecha_Vencimiento = entity.Fecha_Vencimiento;
            plazoFijo.Active = entity.Active;

            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }
}
