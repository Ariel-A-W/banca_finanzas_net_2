using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CuentasCorrientes;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class CuentasCorrientesRepository : ICRUD<CuentaCorriente>, ICuentaCorriente
{
    private readonly AppDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<CuentaCorriente> _dbSet;

    public CuentasCorrientesRepository(AppDBContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<CuentaCorriente>();
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<CuentaCorriente> GetList()
    {
        return _dbSet!.ToList();
    }

    public IEnumerable<CuentaCorriente> GetClienteMovsByID(int clienteId)
    {
        return _dbSet!.ToList().Where(x => x.Cliente_Id == clienteId);
    }

    public CuentaCorriente GetById(int value)
    {
        return _dbSet.SingleOrDefault(x => x.Cuenta_Corriente_Id == value)!;
    }

    public CuentaCorriente GetByUUID(Guid value)
    {
        return _dbSet.SingleOrDefault(x => x.Cuenta_Corriente_UUID == value)!;
    }

    public Task<int> Add(CuentaCorriente entity, CancellationToken cancellationToken)
    {
        try
        {
            _dbSet.Add(
                new CuentaCorriente() 
                { 
                    Cuenta_Corriente_Id = entity.Cuenta_Corriente_Id, 
                    Cuenta_Corriente_UUID = entity.Cuenta_Corriente_UUID, 
                    Cliente_Id = entity.Cliente_Id, 
                    Estado = entity.Estado, 
                    Fecha_Cobro = entity.Fecha_Cobro, 
                    Fecha_Emision = entity.Fecha_Emision, 
                    Debe = entity.Debe, 
                    Haber = entity.Haber, 
                    Saldo = entity.Saldo, 
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
            var cc = _dbSet.FirstOrDefault(x => x.Cuenta_Corriente_Id == value);

            if (cc == null)
                return Task<int>.FromResult(0);

            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }

    public Task<int> Update(CuentaCorriente entity, CancellationToken cancellationToken)
    {
        try
        {
            var cc = _dbSet.FirstOrDefault(x => x.Cuenta_Corriente_Id == entity.Cuenta_Corriente_Id);

            if (cc == null)
                return Task<int>.FromResult(0);

            cc.Cuenta_Corriente_Id = entity.Cuenta_Corriente_Id;
            cc.Cuenta_Corriente_UUID = entity.Cuenta_Corriente_UUID;
            cc.Cliente_Id = entity.Cliente_Id; 
            cc.Estado = entity.Estado;
            cc.Fecha_Cobro = entity.Fecha_Cobro;
            cc.Fecha_Emision = entity.Fecha_Emision;
            cc.Debe = entity.Debe;
            cc.Haber = entity.Haber;
            cc.Saldo = entity.Saldo;
            cc.Active = entity.Active;

            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }
}
