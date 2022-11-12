﻿// <auto-generated />
using System;
using Homework6;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Homework6.Migrations
{
    [DbContext(typeof(EnergyContext))]
    partial class EnergyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Homework6.ApartmentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FirstDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("FirstMonthValue1")
                        .HasColumnType("bigint");

                    b.Property<long>("FirstMonthValue2")
                        .HasColumnType("bigint");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<int>("QuarterNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("SecondDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("SecondMonthValue1")
                        .HasColumnType("bigint");

                    b.Property<long>("SecondMonthValue2")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThirdDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ThirdMonthValue1")
                        .HasColumnType("bigint");

                    b.Property<long>("ThirdMonthValue2")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Apartments");
                });
#pragma warning restore 612, 618
        }
    }
}