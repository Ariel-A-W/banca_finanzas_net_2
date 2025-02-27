using banca_finanzas_net.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banca_finanzas_net.Infrastructure.AdaptersModels;

public class ClientesModels : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("clientes");

        builder
            .HasKey(k => k.Cliente_Id)
            .HasName("clientes_id");

        builder
            .HasOne(o => o.CajaAhorros)
            .WithMany(x => x.Clientes)
            .HasForeignKey(f => f.Cliente_Id);

        builder
            .HasOne(o => o.CuentasCorrientes)
            .WithMany(x => x.Clientes)
            .HasForeignKey(f => f.Cliente_Id);

        builder
            .HasOne(o => o.PlazosFijos)
            .WithMany(x => x.Clientes)
            .HasForeignKey(f => f.Cliente_Id);

        builder.Property(p => p.Cliente_UUID);
        builder.Property(p => p.Nombres);
        builder.Property(p => p.Apellidos);
        builder.Property(p => p.Email);
        builder.Property(p => p.Telefono);
        builder.Property(p => p.Active);
    }
}
