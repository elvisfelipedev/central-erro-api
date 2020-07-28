using CentralErros.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralErros.Data.Mappings
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeUsuario)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Origem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1500)");

            builder.ToTable("Logs");
        }
    }
}
