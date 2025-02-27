namespace banca_finanzas_net.Infrastructure.DBContext;

public sealed class ConcurrencyException : Exception
{
    public ConcurrencyException(
        string message, Exception innerException
    ) : base(message, innerException)
    { }
}
