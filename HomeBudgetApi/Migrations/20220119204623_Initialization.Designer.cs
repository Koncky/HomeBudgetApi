﻿// <auto-generated />
using System;
using HomeBudgetApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeBudgetApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220119204623_Initialization")]
    partial class Initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("HomeBudgetApi.Models.Fee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<short>("IsArchival")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NoAccount")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RecipientAddress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RecipientName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Fee");
                });

            modelBuilder.Entity("HomeBudgetApi.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("FeeId")
                        .HasColumnType("int");

                    b.Property<short>("Month")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<short>("Realized")
                        .HasColumnType("bit");

                    b.Property<string>("TransferTitle")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeeId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("HomeBudgetApi.Models.Payment", b =>
                {
                    b.HasOne("HomeBudgetApi.Models.Fee", "Fee")
                        .WithMany("Payments")
                        .HasForeignKey("FeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fee");
                });

            modelBuilder.Entity("HomeBudgetApi.Models.Fee", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}