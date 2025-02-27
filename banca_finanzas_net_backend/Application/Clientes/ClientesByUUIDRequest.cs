using System.ComponentModel.DataAnnotations;

namespace banca_finanzas_net.Application.Clientes;

public class ClientesByUUIDRequest
{
    [Required(ErrorMessage = "{0} es requerido.")]
    [RegularExpression(
        @"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$",
        ErrorMessage = "{0} debe contener un formato UUID válido."
    )]
    public Guid Cliente_UUID { get; set; }
}
