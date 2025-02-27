using banca_finanzas_net.Application.Abstractions;

namespace banca_finanzas_net.Application.Clientes;

public interface IClientesUseCase : ICRUDUsesCases
    <
        ClientesResponse,
        ClientesAddRequest,
        ClientesDeleteRequest,
        ClientesUpdateRequest
    >
{
}
