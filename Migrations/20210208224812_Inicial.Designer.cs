﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcial1_ap1_2018_0553.DAL;

namespace Parcial1_ap1_2018_0553.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210208224812_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Parcial1_ap1_2018_0553.Entidades.Ciudad", b =>
                {
                    b.Property<int>("CiudadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre_Ciudad")
                        .HasColumnType("TEXT");

                    b.HasKey("CiudadID");

                    b.ToTable("Ciudad");
                });
#pragma warning restore 612, 618
        }
    }
}
