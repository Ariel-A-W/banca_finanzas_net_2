using banca_finanzas_net.Application.CajaAhorros;
using banca_finanzas_net.Application.CuentasCorrientes;
using banca_finanzas_net.Application.PlazosFijos;

namespace banca_finanzas_net.Application.Clientes;

public class ClientesResponse
{
    public Guid Cliente_UUID { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? Email { get; set; }
    public int Active { get; set; }

    public IEnumerable<CajaAhorrosResponse>? CajaAhorros { get; set; }
    public IEnumerable<CuentaCorrienteResponse>? CuentasCorrientes { get; set; }
    public IEnumerable<PlazosFijosResponse>? PlazosFijos { get; set; }
}
