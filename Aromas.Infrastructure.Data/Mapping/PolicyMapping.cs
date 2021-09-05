using Aromas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Infra.Data.Mapping
{
    class PolicyMapping
    {
        public PolicyMapping(EntityTypeBuilder<Policy> entity)
        {
            entity.ToTable("Policy", "aromas");

            entity.HasKey(x => x.Id).HasName("PK_POLICY");
            entity.HasIndex(x => x.Name).HasDatabaseName("IX_POLICY_NAME").IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(200);

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
