using Aromas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Infra.Data.Mapping
{
    class PolicyMenuMapping
    {
        public PolicyMenuMapping(EntityTypeBuilder<PolicyMenu> entity)
        {
            entity.ToTable("PolicyMenu", "aromas");

            entity.HasKey(x => x.Id).HasName("PK_POLICYMENU");
            entity.HasIndex(x => new { x.PolicyId, x.MenuId }).HasDatabaseName("IX_POLICYMENU_IDAK").IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(x => x.PolicyId)
                .IsRequired()
                .HasColumnName("PolicyId");

            entity.Property(x => x.MenuId)
                .IsRequired()
                .HasColumnName("MenuId");

            entity.HasOne(x => x.Policy)
                .WithMany(x => x.PolicyMenu)
                .HasForeignKey(x => x.PolicyId)
                .HasConstraintName("FK_POLICYMENU_POLICY")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Menu)
                .WithMany(x => x.PolicyMenu)
                .HasForeignKey(x => x.MenuId)
                .HasConstraintName("FK_POLICYMENU_MENU")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
