using banca_finanzas_net.Application.Abstractions;
using banca_finanzas_net.Application.Clientes;
using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CajaAhorros;
using banca_finanzas_net.Domain.Clientes;
using banca_finanzas_net.Domain.CuentasCorrientes;
using banca_finanzas_net.Domain.PlazosFijos;
using banca_finanzas_net.Infrastructure.DBContext;
using banca_finanzas_net.Infrastructure.Repositories;

namespace banca_finanzas_net.DIP;

public static class AllServicesDIP
{
    public static IServiceCollection AddServicesDIP(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Añadir todas las dependencias aquí.

        // Dependencia para la gestión de cancelaciones y operaciones.
        services.AddScoped<IUnitOfWork>(
            sp => (IUnitOfWork)sp.GetRequiredService<AppDBContext>()
        );

        // Pila para las inyecciones de dependencias del proyecto.
        services.AddScoped<ICRUD<Cliente>, ClientesRepository>();
        services.AddScoped<ICRUDUsesCases
        <
            ClientesResponse,
            ClientesAddRequest,
            ClientesDeleteRequest,
            ClientesUpdateRequest
        >, ClientesUseCase>();

        services.AddScoped<ICRUD<CajaAhorro>, CajaAhorrosRepository>();
        services.AddScoped<ICajaAhorro, CajaAhorrosRepository>();

        services.AddScoped<ICRUD<CuentaCorriente>, CuentasCorrientesRepository>();
        services.AddScoped<ICuentaCorriente, CuentasCorrientesRepository>();

        services.AddScoped<ICRUD<PlazoFijo>, PlazosFijosRepository>();

        return services;
    }
}
