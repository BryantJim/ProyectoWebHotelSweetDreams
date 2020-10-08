﻿// <auto-generated />
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
#pragma warning restore 612, 618
        }
    }
}
