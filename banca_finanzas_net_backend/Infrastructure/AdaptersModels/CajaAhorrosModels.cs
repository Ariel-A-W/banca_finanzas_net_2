using banca_finanzas_net.Domain.CajaAhorros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banca_finanzas_net.Infrastructure.AdaptersModels;

public class CajaAhorrosModels : IEntityTypeConfiguration<CajaAhorro>
{
    public void Configure(EntityTypeBuilder<CajaAhorro> builder)
    {
        builder.ToTable("cajasahorros");

        builder
            .HasKey(k => k.Caja_Ahorro_Id)
            .HasName("caja_ahorro_id");

        builder.Property(p => p.Caja_Ahorro_UUID);
        builder.Property(p => p.Cliente_Id);
        builder.Property(p => p.NroCuenta);
        builder.Property(p => p.Movimiento);
        builder.Property(p => p.Debe);
        builder.Property(p => p.Haber);

        // Saldo (No Mappeado)

        builder.Property(p => p.Fecha);
    }
}
