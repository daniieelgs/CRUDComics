﻿// <auto-generated />
using System;
using ColeccionComics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ColeccionComics.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20220718044449_reset2")]
    partial class reset2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BBDD.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgnoNacimiento")
                        .HasColumnType("int");

                    b.Property<int>("NacionalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NacionalidadId");

                    b.HasIndex("RolId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("BBDD.Autor_Comic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("ComicId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("ComicId");

                    b.HasIndex("RolId");

                    b.ToTable("Autor_Comic");
                });

            modelBuilder.Entity("BBDD.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BBDD.Comic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EditorialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroPaginas")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EditorialId");

                    b.ToTable("Comics");
                });

            modelBuilder.Entity("BBDD.Editorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("PaisId");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("BBDD.Nacionalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("PaisId");

                    b.ToTable("Nacionalidades");
                });

            modelBuilder.Entity("BBDD.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("BBDD.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BBDD.Autor", b =>
                {
                    b.HasOne("BBDD.Nacionalidad", "Nacionalidad")
                        .WithMany("Autores")
                        .HasForeignKey("NacionalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BBDD.Rol", null)
                        .WithMany("Autores")
                        .HasForeignKey("RolId");

                    b.Navigation("Nacionalidad");
                });

            modelBuilder.Entity("BBDD.Autor_Comic", b =>
                {
                    b.HasOne("BBDD.Autor", "Autor")
                        .WithMany("Autores_Comics")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BBDD.Comic", "Comic")
                        .WithMany("Autores_Comics")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BBDD.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Comic");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("BBDD.Comic", b =>
                {
                    b.HasOne("BBDD.Categoria", "Categoria")
                        .WithMany("Comics")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BBDD.Editorial", "Editorial")
                        .WithMany("Comics")
                        .HasForeignKey("EditorialId");

                    b.Navigation("Categoria");

                    b.Navigation("Editorial");
                });

            modelBuilder.Entity("BBDD.Editorial", b =>
                {
                    b.HasOne("BBDD.Pais", "Pais")
                        .WithMany("Editoriales")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("BBDD.Nacionalidad", b =>
                {
                    b.HasOne("BBDD.Pais", "Pais")
                        .WithMany("Nacionalidades")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("BBDD.Autor", b =>
                {
                    b.Navigation("Autores_Comics");
                });

            modelBuilder.Entity("BBDD.Categoria", b =>
                {
                    b.Navigation("Comics");
                });

            modelBuilder.Entity("BBDD.Comic", b =>
                {
                    b.Navigation("Autores_Comics");
                });

            modelBuilder.Entity("BBDD.Editorial", b =>
                {
                    b.Navigation("Comics");
                });

            modelBuilder.Entity("BBDD.Nacionalidad", b =>
                {
                    b.Navigation("Autores");
                });

            modelBuilder.Entity("BBDD.Pais", b =>
                {
                    b.Navigation("Editoriales");

                    b.Navigation("Nacionalidades");
                });

            modelBuilder.Entity("BBDD.Rol", b =>
                {
                    b.Navigation("Autores");
                });
#pragma warning restore 612, 618
        }
    }
}
