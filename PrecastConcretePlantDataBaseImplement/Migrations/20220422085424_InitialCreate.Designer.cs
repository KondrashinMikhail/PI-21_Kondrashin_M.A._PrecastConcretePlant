﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrecastConcretePlantDataBaseImplement;

#nullable disable

namespace PrecastConcretePlantDatabaseImplement.Migrations
{
    [DbContext(typeof(PrecastConcretePlantDatabase))]
    [Migration("20220422085424_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ComponentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReinforcedId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ReinforcedId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Reinforced", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReinforcedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reinforceds");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.ReinforcedComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ReinforcedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("ReinforcedId");

                    b.ToTable("ReinforcedComponents");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WarehouseManagerFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.WarehouseComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseComponents");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Reinforced", "Reinforced")
                        .WithMany("Orders")
                        .HasForeignKey("ReinforcedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reinforced");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.ReinforcedComponent", b =>
                {
                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Component", "Component")
                        .WithMany("ReinforcedComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Reinforced", "Reinforced")
                        .WithMany("ReinforcedComponents")
                        .HasForeignKey("ReinforcedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");

                    b.Navigation("Reinforced");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.WarehouseComponent", b =>
                {
                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Component", "Component")
                        .WithMany("WarehouseComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Warehouse", "Warehouse")
                        .WithMany("WarehouseComponents")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Component", b =>
                {
                    b.Navigation("ReinforcedComponents");

                    b.Navigation("WarehouseComponents");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Reinforced", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ReinforcedComponents");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Warehouse", b =>
                {
                    b.Navigation("WarehouseComponents");
                });
#pragma warning restore 612, 618
        }
    }
}
