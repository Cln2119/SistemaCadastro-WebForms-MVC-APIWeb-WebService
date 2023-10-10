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
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email)
                    .IsUnique();

            builder.HasIndex(u => u.CpfCnpj)
                    .IsUnique();

            builder.Property(u => u.Email)
                  .HasMaxLength(100);

            builder.Property(u => u.CpfCnpj)
                   .HasMaxLength(11);

        }
    }
}
