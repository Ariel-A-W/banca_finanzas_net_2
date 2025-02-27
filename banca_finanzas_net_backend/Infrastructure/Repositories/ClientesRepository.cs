using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.Clientes;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class ClientesRepository : ICRUD<Cliente>
{
    private readonly AppDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<Cliente> _dbSet;

    public ClientesRepository(AppDBContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Cliente>();
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Cliente> GetList()
    {
        return _dbSet!.ToList();
    }

    public Cliente GetById(int value)
    {
        return _dbSet.ToList().SingleOrDefault(x => x.Cliente_Id == value)!;
    }

    public Cliente GetByUUID(Guid value)
    {
        return _dbSet.ToList().SingleOrDefault(x => x.Cliente_UUID == value)!;
    }

    public Task<int> Add(Cliente entity, CancellationToken cancellationToken)
    {
        try
        {
            _dbSet.Add(
                new Cliente() 
                { 
                    Cliente_Id = entity.Cliente_Id, 
                    Cliente_UUID = entity.Cliente_UUID, 
                    Nombres = entity.Nombres, 
                    Apellidos = entity.Apellidos, 
                    Email = entity.Email,
                    Telefono = entity.Telefono, 
                    Active = entity.Active
                }    
            );
            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task.FromResult((int)result.Result);
        }
        catch
        {
            return Task.FromResult(0);
        }
    }

    public Task<int> Delete(int value, CancellationToken cancellationToken)
    {
        try
        {
            var usuario = _dbSet.FirstOrDefault(x => x.Cliente_Id == value);

            if (usuario == null)
                return Task<int>.FromResult(0);

            _dbSet.Remove(usuario);

            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task.FromResult(result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }

    public Task<int> Update(Cliente entity, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = _dbSet.FirstOrDefault(x => x.Cliente_Id == entity.Cliente_Id);

            if (cliente == null)
                return Task.FromResult(0);

            cliente.Cliente_Id = entity.Cliente_Id;
            cliente.Cliente_UUID = entity.Cliente_UUID;
            cliente.Nombres = entity.Nombres;
            cliente.Apellidos = entity.Apellidos;
            cliente.Email = entity.Email;
            cliente.Telefono = entity.Telefono;
            cliente.Active = entity.Active;

            var result = _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task.FromResult((int)result.Result);
        }
        catch
        {
            return Task.FromResult(0);
        }
    }
}
