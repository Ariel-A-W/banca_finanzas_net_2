namespace banca_finanzas_net.Domain.PlazosFijos;

public record Fecha_Vencimiento(
    DateTime Fecha_Inicio, int Value    
)
{
    public DateTime GetFechaVencimiento() => Fecha_Inicio.AddDays(Value);
}