﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RandoWebService.Data;

namespace RandoWebService.Migrations
{
    [DbContext(typeof(GlobalEliteContext))]
    partial class GlobalEliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("RandoWebService.Data.Models.EliteData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("SomeDateTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("SomeDouble")
                        .HasColumnType("REAL");

                    b.Property<int>("SomeInt")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SomeRefId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SomeRefId");

                    b.ToTable("EliteDatas");
                });

            modelBuilder.Entity("RandoWebService.Data.Models.EliteRef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EliteRefId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("SomeDateTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("SomeDouble")
                        .HasColumnType("REAL");

                    b.Property<int>("SomeInt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EliteRefId");

                    b.ToTable("EliteRefs");
                });

            modelBuilder.Entity("RandoWebService.Data.Models.EliteData", b =>
                {
                    b.HasOne("RandoWebService.Data.Models.EliteRef", "SomeRef")
                        .WithMany("SomeElites")
                        .HasForeignKey("SomeRefId");

                    b.Navigation("SomeRef");
                });

            modelBuilder.Entity("RandoWebService.Data.Models.EliteRef", b =>
                {
                    b.HasOne("RandoWebService.Data.Models.EliteRef", null)
                        .WithMany("OtherRefs")
                        .HasForeignKey("EliteRefId");
                });

            modelBuilder.Entity("RandoWebService.Data.Models.EliteRef", b =>
                {
                    b.Navigation("OtherRefs");

                    b.Navigation("SomeElites");
                });
#pragma warning restore 612, 618
        }
    }
}
