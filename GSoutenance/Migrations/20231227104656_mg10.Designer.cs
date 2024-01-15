﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GSoutenance.Migrations
{
    [DbContext(typeof(SoutenanceContext))]
    [Migration("20231227104656_mg10")]
    partial class mg10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GSoutenance.Models.Ensignant", b =>
                {
                    b.Property<int>("EncadreurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EncadreurID"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EncadreurID");

                    b.ToTable("Ensignant");
                });

            modelBuilder.Entity("GSoutenance.Models.Etudiant", b =>
                {
                    b.Property<int>("EtudiantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EtudiantId"));

                    b.Property<DateOnly>("DateN")
                        .HasColumnType("date");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EtudiantId");

                    b.ToTable("Etudiant");
                });

            modelBuilder.Entity("GSoutenance.Models.Pfe", b =>
                {
                    b.Property<int>("PFEID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PFEID"));

                    b.Property<DateTime>("DateF")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dated")
                        .HasColumnType("datetime2");

                    b.Property<int>("EncadrantID")
                        .HasColumnType("int");

                    b.Property<int>("SocieteID")
                        .HasColumnType("int");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("titre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PFEID");

                    b.HasIndex("EncadrantID");

                    b.HasIndex("SocieteID");

                    b.ToTable("Pfe");
                });

            modelBuilder.Entity("GSoutenance.Models.Pfe_Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EtudiantId")
                        .HasColumnType("int");

                    b.Property<int>("PFEID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EtudiantId");

                    b.HasIndex("PFEID");

                    b.ToTable("Pfe_Etudiant");
                });

            modelBuilder.Entity("GSoutenance.Models.Societe", b =>
                {
                    b.Property<int>("SocieteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocieteID"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibSociete")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Tel")
                        .HasColumnType("int");

                    b.HasKey("SocieteID");

                    b.ToTable("Societe");
                });

            modelBuilder.Entity("GSoutenance.Models.Pfe", b =>
                {
                    b.HasOne("GSoutenance.Models.Ensignant", "Encadrant")
                        .WithMany("Pfes")
                        .HasForeignKey("EncadrantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GSoutenance.Models.Societe", "Societe")
                        .WithMany("Pfes")
                        .HasForeignKey("SocieteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encadrant");

                    b.Navigation("Societe");
                });

            modelBuilder.Entity("GSoutenance.Models.Pfe_Etudiant", b =>
                {
                    b.HasOne("GSoutenance.Models.Etudiant", "Etudiant")
                        .WithMany("Pfe_etudiants")
                        .HasForeignKey("EtudiantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GSoutenance.Models.Pfe", "Pfe")
                        .WithMany("Pfe_Etudiants")
                        .HasForeignKey("PFEID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etudiant");

                    b.Navigation("Pfe");
                });

            modelBuilder.Entity("GSoutenance.Models.Ensignant", b =>
                {
                    b.Navigation("Pfes");
                });

            modelBuilder.Entity("GSoutenance.Models.Etudiant", b =>
                {
                    b.Navigation("Pfe_etudiants");
                });

            modelBuilder.Entity("GSoutenance.Models.Pfe", b =>
                {
                    b.Navigation("Pfe_Etudiants");
                });

            modelBuilder.Entity("GSoutenance.Models.Societe", b =>
                {
                    b.Navigation("Pfes");
                });
#pragma warning restore 612, 618
        }
    }
}
