﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SAbadBurguerPromoCF.Data;

#nullable disable

namespace SAbadBurguerPromoCF.Migrations
{
    [DbContext(typeof(SAbadBurguerPromoCFContext))]
    [Migration("20241021155449_SegundoCambio")]
    partial class SegundoCambio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SAbadBurguerPromoCF.Models.Burguer", b =>
                {
                    b.Property<int>("BurguerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurguerId"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("WithCheese")
                        .HasColumnType("bit");

                    b.HasKey("BurguerId");

                    b.ToTable("Burguer");
                });

            modelBuilder.Entity("SAbadBurguerPromoCF.Models.Promo", b =>
                {
                    b.Property<int>("PromoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromoID"));

                    b.Property<int>("BurguerID")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("FechaPromo")
                        .HasColumnType("date");

                    b.HasKey("PromoID");

                    b.HasIndex("BurguerID");

                    b.ToTable("Promo");
                });

            modelBuilder.Entity("SAbadBurguerPromoCF.Models.Promo", b =>
                {
                    b.HasOne("SAbadBurguerPromoCF.Models.Burguer", "Burguer")
                        .WithMany("Promos")
                        .HasForeignKey("BurguerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burguer");
                });

            modelBuilder.Entity("SAbadBurguerPromoCF.Models.Burguer", b =>
                {
                    b.Navigation("Promos");
                });
#pragma warning restore 612, 618
        }
    }
}
