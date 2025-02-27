using banca_finanzas_net.Application.Clientes;

namespace banca_finanzas_net.Application.CuentasCorrientes;

public class CuentaCorrienteResponse
{
    public Guid Cuenta_Corriente_UUIG { get; set; }
    public string? Estadp { get; set; }
    public DateTime Fecha_Emision { get; set; }
    public DateTime Fecha_Cobro { get; set; }
    public decimal Debe { get; set; }
    public decimal Haber { get; set; }
    public decimal Saldo { get; set; }
    public int Active { get; set; }
}
