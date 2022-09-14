﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeApp.Data;

namespace RecipesApi.Migrations
{
    [DbContext(typeof(RecipesContext))]
    [Migration("20220708214832_add migrations")]
    partial class addmigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Diplome", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CodeDiplome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Diplomaid")
                        .HasColumnType("int");

                    b.Property<string>("Intitule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialiteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("Diplomaid");

                    b.ToTable("Diplomes");
                });

            modelBuilder.Entity("RecipeApp.Entities.Recipe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("imageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeApp.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Specialite", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Intitule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("Diplome", b =>
                {
                    b.HasOne("Diplome", "Diploma")
                        .WithMany()
                        .HasForeignKey("Diplomaid");

                    b.Navigation("Diploma");
                });

            modelBuilder.Entity("RecipeApp.Entities.Recipe", b =>
                {
                    b.HasOne("RecipeApp.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });
#pragma warning restore 612, 618
        }
    }
}
