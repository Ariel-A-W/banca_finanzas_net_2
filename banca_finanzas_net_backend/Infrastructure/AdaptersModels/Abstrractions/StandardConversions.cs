using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.PlazosFijos;

namespace banca_finanzas_net.Infrastructure.AdaptersModels.Abstrractions;

public static class StandardConversions
{
    public static Saldo ConvertToSaldo(string? values)
    {
        if (string.IsNullOrWhiteSpace(values))
            return new Saldo(0, 0); // Valor por defecto

        var parts = values.Split('|');

        if (parts.Length != 2)
            throw new InvalidOperationException(
                "El valor almacenado no tiene el formato correcto."
            );

        if (
            decimal.TryParse(parts[0], out var debe) 
            && 
            decimal.TryParse(parts[1], out var haber)
        )
            return new Saldo(debe, haber);

        throw new InvalidOperationException(
            "Error al convertir los valores almacenados."
        );
    }

    public static Capital ConvertToCapital(string? values)
    {
        if (string.IsNullOrWhiteSpace(values))
            return new Capital(0, 0, 0);

        var parts = values.Split('|'); 

        if (parts.Length != 3)
            throw new InvalidOperationException(
                "El valor almacenado no tiene el formato correcto."
            );

        if (
            decimal.TryParse(parts[0], out var monto)
            &&
            int.TryParse(parts[1], out var plazo)
            &&
            decimal.TryParse(parts[2], out var interes)
        )
            return new Capital(monto, plazo, interes);

        throw new InvalidOperationException(
            "Error al convertir los valores almacenados."
        );
    }
}
