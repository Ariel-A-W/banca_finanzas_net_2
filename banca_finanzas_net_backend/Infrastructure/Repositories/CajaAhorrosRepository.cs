using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CajaAhorros;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class CajaAhorrosRepository : ICRUD<CajaAhorro>, ICajaAhorro
{
    private readonly AppDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<CajaAhorro> _dbSet;

    public CajaAhorrosRepository(AppDBContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<CajaAhorro>();
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<CajaAhorro> GetList()
    {
        return _dbSet!.ToList();
    }

    public IEnumerable<CajaAhorro> GetClienteMovsByID(int clienteId)
    {
        return _dbSet!.ToList().Where(x => x.Cliente_Id == clienteId);
    }

    public CajaAhorro GetById(int value)
    {
        return _dbSet.SingleOrDefault(x => x.Caja_Ahorro_Id == value)!;
    }

    public CajaAhorro GetByUUID(Guid value)
    {
        return _dbSet.SingleOrDefault(x => x.Caja_Ahorro_UUID == value)!; 
    }

    public Task<int> Add(CajaAhorro entity, CancellationToken cancellationToken)
    {
        try
        {
            _dbSet.Add(
                new CajaAhorro() 
                { 
                    Caja_Ahorro_Id = entity.Caja_Ahorro_Id, 
                    Caja_Ahorro_UUID = entity.Caja_Ahorro_UUID, 
                    Cliente_Id = entity.Cliente_Id, 
                    NroCuenta = entity.NroCuenta,
                    Movimiento = entity.Movimiento, 
                    Debe = entity.Debe, 
                    Haber = entity.Haber, 
                    Saldo = entity.Saldo, 
                    Fecha = entity.Fecha
                }    
            );
            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task<int>.FromResult(result.Result);
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
            var cajaAhorro = _dbSet.FirstOrDefault(x => x.Caja_Ahorro_Id == value);

            if (cajaAhorro == null)
                return Task<int>.FromResult(0);

            _dbSet.Remove(cajaAhorro);

            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }

    public Task<int> Update(CajaAhorro entity, CancellationToken cancellationToken)
    {
        try
        {
            var cajaAhorro = _dbSet.FirstOrDefault(x => x.Caja_Ahorro_Id == entity.Caja_Ahorro_Id);

            if (cajaAhorro == null)
                return Task<int>.FromResult(0);

            cajaAhorro.Caja_Ahorro_Id = entity.Caja_Ahorro_Id;
            cajaAhorro.Caja_Ahorro_UUID = entity.Caja_Ahorro_UUID;
            cajaAhorro.Cliente_Id = entity.Cliente_Id;
            cajaAhorro.NroCuenta = entity.NroCuenta;
            cajaAhorro.Movimiento = entity.Movimiento;
            cajaAhorro.Debe = entity.Debe;
            cajaAhorro.Haber = entity.Haber;
            cajaAhorro.Saldo = entity.Saldo;
            cajaAhorro.Fecha = entity.Fecha;

            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }
}
