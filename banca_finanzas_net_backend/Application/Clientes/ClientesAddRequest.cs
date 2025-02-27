using System.ComponentModel.DataAnnotations;

namespace banca_finanzas_net.Application.Clientes;

public class ClientesAddRequest
{
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
}
