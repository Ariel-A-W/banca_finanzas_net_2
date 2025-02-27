namespace banca_finanzas_net.Domain.CuentasCorrientes;

public interface ICuentaCorriente
{
    public IEnumerable<CuentaCorriente> GetClienteMovsByID(int clienteId);
}
