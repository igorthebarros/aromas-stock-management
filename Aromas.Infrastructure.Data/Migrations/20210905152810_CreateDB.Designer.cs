﻿// <auto-generated />
using System;
using Aromas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aromas.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210905152810_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Aromas.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("Name");

                    b.Property<string>("SubCategory")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("SubCategory");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id")
                        .HasName("PK_CATEGORY");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_CATEGORY_NAME");

                    b.ToTable("Category", "aromas");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("Active");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Path");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id")
                        .HasName("PK_MENU");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_MENU_NAME");

                    b.ToTable("Menu", "aromas");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.Permissions.PolicyUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PolicyId")
                        .HasColumnType("integer")
                        .HasColumnName("PolicyId");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("Id")
                        .HasName("PK_POLICYUSER");

                    b.HasIndex("UserId");

                    b.HasIndex("PolicyId", "UserId")
                        .IsUnique()
                        .HasDatabaseName("IX_POLICYUSER_IDAK");

                    b.ToTable("PolicyUser", "aromas");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("Active");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("integer")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id")
                        .HasName("PK_POLICY");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_POLICY_NAME");

                    b.ToTable("Policy", "aromas");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.PolicyMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("MenuId")
                        .HasColumnType("integer")
                        .HasColumnName("MenuId");

                    b.Property<int>("PolicyId")
                        .HasColumnType("integer")
                        .HasColumnName("PolicyId");

                    b.HasKey("Id")
                        .HasName("PK_POLICYMENU");

                    b.HasIndex("MenuId");

                    b.HasIndex("PolicyId", "MenuId")
                        .IsUnique()
                        .HasDatabaseName("IX_POLICYMENU_IDAK");

                    b.ToTable("PolicyMenu", "aromas");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("Category");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("IsInStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("IsInStock");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Name");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("StockQuantity");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id")
                        .HasName("PK_PRODUCT");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_USER_NAME");

                    b.ToTable("Product", "aromas");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("Enable");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("integer")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Name");

                    b.Property<int>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("Password");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Surname");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id")
                        .HasName("PK_USER");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_USER_NAME");

                    b.ToTable("User", "aromas");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.Permissions.PolicyUser", b =>
                {
                    b.HasOne("Aromas.Domain.Entities.Policy", "Policy")
                        .WithMany("PolicyUser")
                        .HasForeignKey("PolicyId")
                        .HasConstraintName("FK_POLICYUSER_POLICY")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Aromas.Domain.Entities.User", "User")
                        .WithMany("PolicyUser")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_POLICYUSER_USER")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Policy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.PolicyMenu", b =>
                {
                    b.HasOne("Aromas.Domain.Entities.Menu", "Menu")
                        .WithMany("PolicyMenu")
                        .HasForeignKey("MenuId")
                        .HasConstraintName("FK_POLICYMENU_MENU")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Aromas.Domain.Entities.Policy", "Policy")
                        .WithMany("PolicyMenu")
                        .HasForeignKey("PolicyId")
                        .HasConstraintName("FK_POLICYMENU_POLICY")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.Menu", b =>
                {
                    b.Navigation("PolicyMenu");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.Policy", b =>
                {
                    b.Navigation("PolicyMenu");

                    b.Navigation("PolicyUser");
                });

            modelBuilder.Entity("Aromas.Domain.Entities.User", b =>
                {
                    b.Navigation("PolicyUser");
                });
#pragma warning restore 612, 618
        }
    }
}
