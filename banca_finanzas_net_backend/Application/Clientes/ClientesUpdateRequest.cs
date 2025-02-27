using System.ComponentModel.DataAnnotations;

namespace banca_finanzas_net.Application.Clientes;

public class ClientesUpdateRequest
{
    [Required(ErrorMessage = "{0} es requerido.")]
    [RegularExpression(
        @"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$",
        ErrorMessage = "{0} debe contener un formato UUID válido."
    )]
    public Guid Cliente_UUID { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [StringLength(255, ErrorMessage = "{0} no puede superar los 255 caracteres.")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [StringLength(255, ErrorMessage = "{0} no puede superar los 255 caracteres.")]
    public string? Apellidos { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [StringLength(255, ErrorMessage = "{0} no puede superar los 255 caracteres.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [StringLength(255, ErrorMessage = "{0} no puede superar los 255 caracteres.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [Range(0, 1, ErrorMessage = "El campo {0} requiere valores entre 0 y 1")]
    public int Active { get; set; }
}
