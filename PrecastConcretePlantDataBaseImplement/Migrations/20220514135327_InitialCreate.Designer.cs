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
    [Migration("20220514135327_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

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

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Implementer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImplementerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PauseTime")
                        .HasColumnType("int");

                    b.Property<int>("WorkingTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Implementers");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.MessageInfo", b =>
                {
                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDelivery")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ClientId");

                    b.ToTable("MessagesInfo");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImplementerId")
                        .HasColumnType("int");

                    b.Property<int>("ReinforcedId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ImplementerId");

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

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.MessageInfo", b =>
                {
                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Client", "Client")
                        .WithMany("MessagesInfo")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Implementer", "Implementer")
                        .WithMany("Orders")
                        .HasForeignKey("ImplementerId");

                    b.HasOne("PrecastConcretePlantDatabaseImplement.Models.Reinforced", "Reinforced")
                        .WithMany("Orders")
                        .HasForeignKey("ReinforcedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Implementer");

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

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Client", b =>
                {
                    b.Navigation("MessagesInfo");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Component", b =>
                {
                    b.Navigation("ReinforcedComponents");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Implementer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PrecastConcretePlantDatabaseImplement.Models.Reinforced", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ReinforcedComponents");
                });
#pragma warning restore 612, 618
        }
    }
}
