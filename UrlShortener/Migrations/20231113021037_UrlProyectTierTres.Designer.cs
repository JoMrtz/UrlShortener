﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.Data;

#nullable disable

namespace UrlShortener.Migrations
{
    [DbContext(typeof(UrlShortenerContext))]
    [Migration("20231113021037_UrlProyectTierTres")]
    partial class UrlProyectTierTres
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("UrlShortener.Entities.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Heores"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Accion"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gatos"
                        });
                });

            modelBuilder.Entity("UrlShortener.Entities.Url", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Counter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlOriginal")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlShort")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("UserId");

                    b.ToTable("Url");
                });

            modelBuilder.Entity("UrlShortener.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "juaneselmejor",
                            Username = "juan"
                        },
                        new
                        {
                            Id = 2,
                            Password = "joaeselmejor",
                            Username = "joaquin"
                        },
                        new
                        {
                            Id = 3,
                            Password = "laueselmejor",
                            Username = "lautaro"
                        });
                });

            modelBuilder.Entity("UrlShortener.Entities.Url", b =>
                {
                    b.HasOne("UrlShortener.Entities.Categories", "Categorie")
                        .WithMany("Urls")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UrlShortener.Entities.User", "User")
                        .WithMany("Urls")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UrlShortener.Entities.Categories", b =>
                {
                    b.Navigation("Urls");
                });

            modelBuilder.Entity("UrlShortener.Entities.User", b =>
                {
                    b.Navigation("Urls");
                });
#pragma warning restore 612, 618
        }
    }
}