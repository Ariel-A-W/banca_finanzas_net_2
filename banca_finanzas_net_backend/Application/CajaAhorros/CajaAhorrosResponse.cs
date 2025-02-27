using banca_finanzas_net.Application.Clientes;

namespace banca_finanzas_net.Application.CajaAhorros;

public class CajaAhorrosResponse
{
    public string? NroCuenta { get; set; }
    public string? Movimiento { get; set; }
    public decimal Debe { get; set; }
    public decimal Haber { get; set; }
    public decimal Saldo { get; set; }
}
