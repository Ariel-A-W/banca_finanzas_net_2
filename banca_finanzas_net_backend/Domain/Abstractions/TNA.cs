namespace banca_finanzas_net.Domain.Abstractions;

public record TNA(decimal Interes)
{
    public decimal GetTNA() => Interes * 12;
}
