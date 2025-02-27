using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.DIP;

public static class PostgreSQLDIP
{

    public static IServiceCollection AddPostgreSQLConnection(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("BancoNetConnectionString")
            ?? throw new ArgumentException(nameof(configuration));

        services.AddDbContext<AppDBContext>(options => {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        return services;
    }
}
