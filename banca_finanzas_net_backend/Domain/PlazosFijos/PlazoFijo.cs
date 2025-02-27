using banca_finanzas_net.Domain.Clientes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace banca_finanzas_net.Domain.PlazosFijos;

public class PlazoFijo 
{
    [Key]
    public int Plazofijo_Id { get; set; }
    public Guid Plazofijo_UUID { get; set; }
    public string? Nrocuenta { get; set; }
    public int Cliente_Id { get; set; }
    public decimal Monto { get; set; }
    public Plazo? Plazo { get; set; }
    public decimal Interes { get; set; }

    [NotMapped]
    public Capital Capital
    {
        get => new Capital(Monto, Plazo!.Value, Interes);
        set
        {
            Monto = value.Monto;
            Plazo = new Plazo(Plazo!.Value);
            Interes = value.Interes;
        }
    }

    public DateTime Fecha_Inicio { get; set; }

    [NotMapped]
    public Fecha_Vencimiento? Fecha_Vencimiento
    {
        get => new Fecha_Vencimiento(Fecha_Inicio, Plazo!.Value);
        set
        {
            Fecha_Inicio = value!.Fecha_Inicio;
            Plazo = new Plazo(Plazo!.Value);
        }
    }

    public int Active { get; set; }

    public ICollection<Cliente>? Clientes { get; set; }
}