using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.Clientes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace banca_finanzas_net.Domain.CajaAhorros;

public class CajaAhorro
{
    [Key]
    public int Caja_Ahorro_Id { get; set; }
    public Guid Caja_Ahorro_UUID { get; set; }
    public int Cliente_Id { get; set; }
    public string? NroCuenta { get; set; }
    public string? Movimiento { get; set; }
    public decimal Debe { get; set; }
    public decimal Haber { get; set; }

    [NotMapped]
    public Saldo? Saldo { get; set; }

    public DateTime Fecha { get; set; }

    public ICollection<Cliente>? Clientes { get; set; }
}
