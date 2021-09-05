using Aromas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Infra.Data.Mapping
{
    class CategoryMapping
    {
        public CategoryMapping(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Category", "aromas");

            entity.HasKey(x => x.Id).HasName("PK_CATEGORY");
            entity.HasIndex(x => x.Name).HasDatabaseName("IX_CATEGORY_NAME").IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(200);

            entity.Property(x => x.SubCategory)
                .IsRequired()
                .HasColumnName("SubCategory")
                .HasMaxLength(200);

            entity.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("now()");

            entity.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt");
        }
    }
}
