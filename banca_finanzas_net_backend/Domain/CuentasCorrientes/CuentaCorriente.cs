using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.Clientes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace banca_finanzas_net.Domain.CuentasCorrientes;

public class CuentaCorriente
{
    [Key]
    public int Cuenta_Corriente_Id { get; set; }
    public Guid Cuenta_Corriente_UUID { get; set; }
    public int Cliente_Id { get; set; }
    public string? Estado { get; set; }
    public DateTime Fecha_Emision { get; set; }
    public DateTime Fecha_Cobro { get; set; }
    public decimal Debe { get; set; }
    public decimal Haber { get; set; }

    [NotMapped]
    public Saldo? Saldo { get; set; }

    public int Active { get; set; }

    public ICollection<Cliente>? Clientes { get; set; }
}
