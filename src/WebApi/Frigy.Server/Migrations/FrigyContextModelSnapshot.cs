﻿// <auto-generated />
using System;
using Frigy.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Frigy.Server.Migrations
{
    [DbContext(typeof(FrigyContext))]
    partial class FrigyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Frigy.Server.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("discriminator");

                    b.Property<bool>("IsImportant")
                        .HasColumnType("boolean")
                        .HasColumnName("is_important");

                    b.Property<int>("MaxCount")
                        .HasColumnType("integer")
                        .HasColumnName("max_count");

                    b.Property<int>("ProductCategory")
                        .HasColumnType("integer")
                        .HasColumnName("product_category");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTimeOffset?>("Updated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.ToTable("products", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Frigy.Server.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_product_categories");

                    b.ToTable("product_categories", (string)null);
                });

            modelBuilder.Entity("Frigy.Server.Models.ProductToBuy", b =>
                {
                    b.HasBaseType("Frigy.Server.Models.Product");

                    b.Property<bool>("IsBuy")
                        .HasColumnType("boolean")
                        .HasColumnName("is_buy");

                    b.HasDiscriminator().HasValue("ProductToBuy");
                });
#pragma warning restore 612, 618
        }
    }
}
