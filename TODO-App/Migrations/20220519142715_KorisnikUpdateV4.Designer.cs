﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TODO_App.Data;

#nullable disable

namespace TODO_App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220519142715_KorisnikUpdateV4")]
    partial class KorisnikUpdateV4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TODO_App.Data.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImePrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("TODO_App.Data.Models.Zadatak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DatumZavrsetka")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ZavrsniDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Zadaci");
                });

            modelBuilder.Entity("TODO_App.Data.Models.Zadatak", b =>
                {
                    b.HasOne("TODO_App.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.Navigation("Korisnik");
                });
#pragma warning restore 612, 618
        }
    }
}