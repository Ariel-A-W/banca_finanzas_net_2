using System.ComponentModel.DataAnnotations;

namespace banca_finanzas_net.Application.CajaAhorros;

public class CajaAhorrosDeleteRequest
{
    [Required(ErrorMessage = "{0} es requerido.")]
    public string? NroCuenta { get; set; }
}
