﻿// <auto-generated />
using System;
using ApiCRUDWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiCRUDWeb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240616062021_ConectToPGSql")]
    partial class ConectToPGSql
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiCRUDWeb.Models.Pet", b =>
                {
                    b.Property<Guid?>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirh")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("PetId");

                    b.HasIndex("UserId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("ApiCRUDWeb.Models.PetDetails", b =>
                {
                    b.Property<Guid>("PetDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EyesColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Heigth")
                        .HasColumnType("double precision");

                    b.Property<string>("NonPredominantColor")
                        .HasColumnType("text");

                    b.Property<string>("Pelage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PetId")
                        .HasColumnType("uuid");

                    b.Property<string>("PredominantColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TongueColor")
                        .HasColumnType("text");

                    b.HasKey("PetDetailsId");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.ToTable("PetsDetails");
                });

            modelBuilder.Entity("ApiCRUDWeb.Models.User", b =>
                {
                    b.Property<Guid?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ApiCRUDWeb.Models.Institution", b =>
                {
                    b.HasBaseType("ApiCRUDWeb.Models.User");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Institution");
                });

            modelBuilder.Entity("ApiCRUDWeb.Models.Owner", b =>
                {
                    b.HasBaseType("ApiCRUDWeb.Models.User");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Owner");
                });

            modelBuilder.Entity("ApiCRUDWeb.Models.Pet", b =>
                {
                    b.HasOne("ApiCRUDWeb.Models.User", "Tutor")
                        .WithMany("Pets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("ApiCRUDWeb.Models.PetDetails", b =>
                {
                    b.HasOne("ApiCRUDWeb.Models.Pet", "Pet")
                        .WithOne("Details")
                        .HasForeignKey("ApiCRUDWeb.Models.PetDetails", "PetId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("ApiCRUDWeb.Models.Pet", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ApiCRUDWeb.Models.User", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
