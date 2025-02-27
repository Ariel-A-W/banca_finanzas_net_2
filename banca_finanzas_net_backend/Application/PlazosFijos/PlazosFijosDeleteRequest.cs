using System.ComponentModel.DataAnnotations;

namespace banca_finanzas_net.Application.PlazosFijos;

public class PlazosFijosDeleteRequest
{
    [Required(ErrorMessage = "{0} es requerido.")]
    [RegularExpression(
        @"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$",
        ErrorMessage = "{0} debe contener un formato UUID válido."
    )]
    public Guid PlazoFijo_UUID { get; set; }
}
