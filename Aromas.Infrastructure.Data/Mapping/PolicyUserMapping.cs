using Aromas.Domain.Entities.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Infra.Data.Mapping
{
    class PolicyUserMapping
    {
        public PolicyUserMapping(EntityTypeBuilder<PolicyUser> entity)
        {
            entity.ToTable("PolicyUser", "aromas");

            entity.HasKey(x => x.Id).HasName("PK_POLICYUSER");
            entity.HasIndex(x => new { x.PolicyId, x.UserId }).HasDatabaseName("IX_POLICYUSER_IDAK").IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            entity.Property(x => x.PolicyId)
                .IsRequired()
                .HasColumnName("PolicyId");

            entity.HasOne(x => x.User)
                .WithMany(x => x.PolicyUser)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_POLICYUSER_USER")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Policy)
                .WithMany(x => x.PolicyUser)
                .HasForeignKey(x => x.PolicyId)
                .HasConstraintName("FK_POLICYUSER_POLICY")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
