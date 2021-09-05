using Aromas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Infra.Data.Mapping
{
    class MenuMapping
    {
        public MenuMapping(EntityTypeBuilder<Menu> entity)
        {
            entity.ToTable("Menu", "aromas");

            entity.HasKey(x => x.Id).HasName("PK_MENU");
            entity.HasIndex(x => x.Name).HasDatabaseName("IX_MENU_NAME").IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(100);

            entity.Property(x => x.Path)
                .IsRequired()
                .HasColumnName("Path")
                .HasMaxLength(255);

            entity.Property(x => x.Active)
                .IsRequired()
                .HasColumnName("Active")
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
