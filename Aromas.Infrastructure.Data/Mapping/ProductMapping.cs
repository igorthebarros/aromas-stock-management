using Aromas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Infra.Data.Mapping
{
    class ProductMapping
    {

        public ProductMapping(EntityTypeBuilder<Product> entity)
        {

            entity.ToTable("Product", "aromas");

            entity.HasKey(x => x.Id).HasName("PK_PRODUCT");
            entity.HasIndex(x => x.Name).HasDatabaseName("IX_PRODUCT_NAME").IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(100);

            entity.Property(x => x.IsInStock)
                .HasColumnName("IsInStock")
                .HasDefaultValue(false);

            entity.Property(x => x.StockQuantity)
                .IsRequired()
                .HasColumnName("StockQuantity");

            entity.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("now()");

            entity.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt");

            entity.Property(x => x.CategoryId)
                .IsRequired()
                .HasColumnName("Category");
        }
    }
}
