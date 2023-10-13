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
    public class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
               .HasColumnName("id");

            builder.Property(e => e.CPF)
               .HasColumnName("CPF");

            builder.Property(e => e.RG)
                .HasColumnName("RG");

            builder.Property(e => e.Data_Expedicao)
                .HasColumnName("Data_Expedicao");

            builder.Property(e => e.Orgao_Expedicao)
                .HasColumnName("Orgao_Expedicao");

            builder.Property(e => e.DataNascimento)
                .HasColumnName("Data_Nascimento");

            builder.Property(e => e.Sexo)
                .HasColumnName("Sexo");

            builder.Property(e => e.Estado_Civil)
                .HasColumnName("Estado_Civil");      

        }
    }
}
