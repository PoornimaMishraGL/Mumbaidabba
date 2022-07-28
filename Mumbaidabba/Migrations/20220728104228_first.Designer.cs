﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mumbaidabba.Models;

#nullable disable

namespace Mumbaidabba.Migrations
{
    [DbContext(typeof(DabbaContext))]
    [Migration("20220728104228_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Mumbaidabba.Models.Booking", b =>
                {
                    b.Property<int>("BookingDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingDetailsId"), 1L, 1);

                    b.Property<string>("BookingNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DbCtgId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("usrid")
                        .HasColumnType("int");

                    b.HasKey("BookingDetailsId");

                    b.HasIndex("DbCtgId");

                    b.ToTable("booking");
                });

            modelBuilder.Entity("Mumbaidabba.Models.Carts", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<int>("DbCtgId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("usrid")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("DbCtgId");

                    b.HasIndex("usrid");

                    b.ToTable("carts");
                });

            modelBuilder.Entity("Mumbaidabba.Models.Contact", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("contact");
                });

            modelBuilder.Entity("Mumbaidabba.Models.DabbaCategory", b =>
                {
                    b.Property<int>("DabbaCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DabbaCategoryId"), 1L, 1);

                    b.Property<string>("DabbaCategoryDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DabbaCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DabbaCategoryId");

                    b.ToTable("dabbaCategory");
                });

            modelBuilder.Entity("Mumbaidabba.Models.Dabbawala", b =>
                {
                    b.Property<int>("dabbawalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("dabbawalaId"), 1L, 1);

                    b.Property<int>("IdNumber")
                        .HasColumnType("int");

                    b.Property<string>("IdProof")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dabbawalaDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dabbawalaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("dabbawalaId");

                    b.ToTable("dabbawala");
                });

            modelBuilder.Entity("Mumbaidabba.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UserType")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Mumbaidabba.Models.Booking", b =>
                {
                    b.HasOne("Mumbaidabba.Models.DabbaCategory", "dabbaCategory")
                        .WithMany()
                        .HasForeignKey("DbCtgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dabbaCategory");
                });

            modelBuilder.Entity("Mumbaidabba.Models.Carts", b =>
                {
                    b.HasOne("Mumbaidabba.Models.DabbaCategory", "dabbaCategory")
                        .WithMany()
                        .HasForeignKey("DbCtgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mumbaidabba.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("usrid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dabbaCategory");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
