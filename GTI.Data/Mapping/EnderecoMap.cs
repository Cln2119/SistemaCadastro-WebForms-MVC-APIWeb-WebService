using GTI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoClienteEntity>
    {
        public void Configure(EntityTypeBuilder<EnderecoClienteEntity> builder)
        {
            builder.ToTable("Endereco_Cliente");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
            .UseIdentityColumn();

            builder.Property(e => e.Logradouro)
               .HasColumnName("Logradouro");

            builder.Property(e => e.Numero)
               .HasColumnName("Numero");

            builder.Property(e => e.Complemento)
                .HasColumnName("Complemento");

            builder.Property(e => e.Cidade)
                .HasColumnName("Cidade");

            builder.Property(e => e.Bairro)
                .HasColumnName("Bairro");

            builder.Property(e => e.UF)
                .HasColumnName("UF");

            builder.Property(e => e.Id_Cliente)
                .HasColumnName("Id_Cliente");
        }
    }
}
