﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Seguimiento.Models;

namespace Seguimiento.Migrations
{
    [DbContext(typeof(SeguimientoContext))]
    partial class SeguimientoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Seguimiento.Models.Cliente", b =>
                {
                    b.Property<int>("dni")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("direccionId")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("dni");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Seguimiento.Models.Direccion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("localidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.Property<string>("provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("referencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("Seguimiento.Models.Empleado", b =>
                {
                    b.Property<int>("legajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("legajo");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Seguimiento.Models.Pedido", b =>
                {
                    b.Property<int>("nroTraking")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("clientedni")
                        .HasColumnType("int");

                    b.Property<string>("comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("direccionid")
                        .HasColumnType("int");

                    b.Property<int?>("encargadolegajo")
                        .HasColumnType("int");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaEnvio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("nroTraking");

                    b.HasIndex("clientedni");

                    b.HasIndex("direccionid");

                    b.HasIndex("encargadolegajo");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Seguimiento.Models.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PedidonroTraking")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<string>("imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.Property<int>("talle")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PedidonroTraking");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Seguimiento.Models.Pedido", b =>
                {
                    b.HasOne("Seguimiento.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clientedni");

                    b.HasOne("Seguimiento.Models.Direccion", "direccion")
                        .WithMany()
                        .HasForeignKey("direccionid");

                    b.HasOne("Seguimiento.Models.Empleado", "encargado")
                        .WithMany()
                        .HasForeignKey("encargadolegajo");

                    b.Navigation("cliente");

                    b.Navigation("direccion");

                    b.Navigation("encargado");
                });

            modelBuilder.Entity("Seguimiento.Models.Producto", b =>
                {
                    b.HasOne("Seguimiento.Models.Pedido", null)
                        .WithMany("productos")
                        .HasForeignKey("PedidonroTraking");
                });

            modelBuilder.Entity("Seguimiento.Models.Pedido", b =>
                {
                    b.Navigation("productos");
                });
#pragma warning restore 612, 618
        }
    }
}
