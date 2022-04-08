﻿// <auto-generated />
using System;
using Mah.Tadbir.DAL.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mah.Tadbir.DAL.EF.Migrations
{
    [DbContext(typeof(TadbirContext))]
    [Migration("20220408070340_changeDescriptionType")]
    partial class changeDescriptionType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mah.Tadbir.Entity.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnName("CUSTOMER_NAME")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("nvarchar(MAX)")
                        .IsUnicode(true);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("REGISTER_DATE")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_INVOICE");
                });

            modelBuilder.Entity("Mah.Tadbir.Entity.InvoiceStuffs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId")
                        .HasColumnName("INVOICE_ID")
                        .HasColumnType("int");

                    b.Property<double>("OffPercent")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OFF_PERCENT")
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<int>("StuffId")
                        .HasColumnName("STUFF_ID")
                        .HasColumnType("int");

                    b.Property<double>("StuffPrice")
                        .HasColumnName("STUFF_PRICE")
                        .HasColumnType("float");

                    b.Property<double>("StuffQuantity")
                        .HasColumnName("STUFF_QUANTITY")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("StuffId");

                    b.ToTable("TB_INVOICE_STUFFS");
                });

            modelBuilder.Entity("Mah.Tadbir.Entity.Stuff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("STUFF_NAME")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<double>("Price")
                        .HasColumnName("STUFF_PRICE")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TB_STUFF");
                });

            modelBuilder.Entity("Mah.Tadbir.Entity.InvoiceStuffs", b =>
                {
                    b.HasOne("Mah.Tadbir.Entity.Invoice", null)
                        .WithMany("InvoiceStuffs")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_STUFF_INVOICE_INVOICE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mah.Tadbir.Entity.Stuff", "Stuff")
                        .WithMany()
                        .HasForeignKey("StuffId")
                        .HasConstraintName("FK_STUFF_INVOICE_STUFF")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}