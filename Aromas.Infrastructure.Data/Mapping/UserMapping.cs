using Aromas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Infra.Data.Mapping
{

    class UserMapping
    {
        public UserMapping(EntityTypeBuilder<User> entity)
        {

            entity.ToTable("User", "aromas");

            entity.HasKey(x => x.Id).HasName("PK_USER");
            entity.HasIndex(x => x.Name).HasDatabaseName("IX_USER_NAME").IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(100);

            entity.Property(x => x.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(100);

            entity.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(200);

            entity.Property(x => x.Password)
                .HasColumnName("Password")
                .HasMaxLength(50);

            entity.Property(x => x.Active)
                .IsRequired()
                .HasColumnName("Enable")
                .HasDefaultValue(false);

            entity.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("now()");

            entity.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt");
        }

    }
}
