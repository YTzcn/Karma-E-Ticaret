﻿// <auto-generated />
using System;
using Karma.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Karma.DataAccess.Migrations
{
    [DbContext(typeof(KarmaContext))]
    partial class KarmaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Karma.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Karma.Entities.Concrete.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("Karma.Entities.Concrete.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentContext")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("Karma.Entities.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Karma.Entities.Concrete.Spesification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Depth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreshnessDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool>("QualityCheck")
                        .HasColumnType("bit");

                    b.Property<string>("QuantityPerBox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhenPacketing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Width")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Spesifications", (string)null);
                });

            modelBuilder.Entity("Karma.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("Karma.Entities.Concrete.Comment", b =>
                {
                    b.HasOne("Karma.Entities.Concrete.Product", "Products")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Karma.Entities.Concrete.Spesification", b =>
                {
                    b.HasOne("Karma.Entities.Concrete.Product", "Products")
                        .WithOne("Spesifications")
                        .HasForeignKey("Karma.Entities.Concrete.Spesification", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Karma.Entities.Image", b =>
                {
                    b.HasOne("Karma.Entities.Concrete.Product", "Products")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Karma.Entities.Concrete.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("Spesifications")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
