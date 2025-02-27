namespace banca_finanzas_net.Domain.PlazosFijos;

public record Plazo(int Value) 
{
    /**
     * Importante
     * 
     * Las directivas del banco nos piden que el rango de cantidad 
     * de días para la operación, debería estar comprendida entre 
     * la cantidad de 30 días como mínimo y 180 días máximo.
     */
    public int GetPlazo()
    {
        if (Value >= 30 && Value <= 180)
        {
            return Value;
        }
        else
        {
            return Value >= 180 ? 180 : 30;
        }
    }
}