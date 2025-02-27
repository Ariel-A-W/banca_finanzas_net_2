using System.ComponentModel.DataAnnotations;

namespace banca_finanzas_net.Application.PlazosFijos;

public class PlazosFijosAddRequest
{
    [Required(ErrorMessage = "{0} es requerido.")]
    [RegularExpression(
        @"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$",
        ErrorMessage = "{0} debe contener un formato UUID válido."
    )]
    public Guid Cliente_UUID { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser un valor positivo.")]
    public decimal Monto { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [Range(30, 180, ErrorMessage = "El campo {0} requiere valores entre 30 a 180")]
    public int Plazo { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser un valor positivo.")]
    public decimal Interes { get; set; }
}
