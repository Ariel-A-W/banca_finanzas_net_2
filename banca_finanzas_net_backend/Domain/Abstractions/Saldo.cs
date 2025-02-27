namespace banca_finanzas_net.Domain.Abstractions;

public record Saldo(
    decimal Debe, decimal Haber
)
{
    public decimal GetSaldo() => Haber - Debe;
}