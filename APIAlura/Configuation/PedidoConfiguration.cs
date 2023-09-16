using APIAlura.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIAlura.Configuation
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.NomeProduto).HasColumnType("VARCHAR(100)");
            builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasPrincipalKey(u => u.Id);

        }
    }
}
