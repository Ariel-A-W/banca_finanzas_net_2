using System.ComponentModel.DataAnnotations;

namespace banca_finanzas_net.Application.CajaAhorros;

public class CajaAhorrosAddRequest
{
    [Required(ErrorMessage = "{0} es requerido.")]
    [RegularExpression(
        @"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$",
        ErrorMessage = "{0} debe contener un formato UUID válido."
    )]
    public int Cliente_UUID { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [StringLength(255, ErrorMessage = "{0} no puede superar los 255 caracteres.")]
    public string? Movimiento { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser un valor positivo.")]
    public decimal Ingreso { get; set; }    
}