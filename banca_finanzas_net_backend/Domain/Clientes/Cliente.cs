using banca_finanzas_net.Domain.CajaAhorros;
using banca_finanzas_net.Domain.CuentasCorrientes;
using banca_finanzas_net.Domain.PlazosFijos;
using System.ComponentModel.DataAnnotations;

namespace banca_finanzas_net.Domain.Clientes;

public class Cliente
{
    [Key]
    public int Cliente_Id { get; set; }
    public Guid Cliente_UUID { get; set; } 
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int Active { get; set; }

    public PlazoFijo? PlazosFijos { get; set; }
    public CajaAhorro? CajaAhorros { get; set; }
    public CuentaCorriente? CuentasCorrientes { get; set; }
}
