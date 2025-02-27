namespace banca_finanzas_net.Domain.Abstractions;

public interface ICRUD<T>
    where T: class
{
    public IEnumerable<T> GetList();
    public T GetById(int value);

    public T GetByUUID(Guid value);
    public Task<int> Add(T entity, CancellationToken cancellationToken);
    public Task<int> Delete(int value, CancellationToken cancellationToken);
    public Task<int> Update(T entity, CancellationToken cancellationToken);
}
