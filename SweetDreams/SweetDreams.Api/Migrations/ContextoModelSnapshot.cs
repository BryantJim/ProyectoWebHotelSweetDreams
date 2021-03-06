﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SweetDreams.Api.DAL;

namespace SweetDreams.Api.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("SweetDreams.Api.Models.Administrador.Actividades", b =>
                {
                    b.Property<int>("ActividadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Accesibilidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Encargado")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HoraFinal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lugar")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreActividad")
                        .HasColumnType("TEXT");

                    b.HasKey("ActividadId");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("SweetDreams.Api.Models.Administrador.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Accesibilidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SweetDreams.Api.Models.Administrador.Habitacion", b =>
                {
                    b.Property<int>("HabitacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Accesibilidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Caracteriscas")
                        .HasColumnType("TEXT");

                    b.Property<string>("CaracteristicasSelecciones")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Foto")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroHabitacion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("HabitacionId");

                    b.ToTable("Habitacion");
                });

            modelBuilder.Entity("SweetDreams.Api.Models.Administrador.Reservaciones", b =>
                {
                    b.Property<int>("ReservacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Accesibilidad")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClienteUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tarjeta")
                        .HasColumnType("TEXT");

                    b.HasKey("ReservacionId");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("SweetDreams.Api.Models.Administrador.ReservacionesDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadAdultos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadNinos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HabitacionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumeroHabitacion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReservacionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("DetalleId");

                    b.HasIndex("ReservacionId");

                    b.ToTable("ReservacionesDetalle");
                });

            modelBuilder.Entity("SweetDreams.Api.Models.Administrador.ReservacionesDetalle", b =>
                {
                    b.HasOne("SweetDreams.Api.Models.Administrador.Reservaciones", null)
                        .WithMany("ReservacionDetalle")
                        .HasForeignKey("ReservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
