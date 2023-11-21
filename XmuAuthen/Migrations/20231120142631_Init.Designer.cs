﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCourse.Framework.Database;

#nullable disable

namespace DotNetExp.Migrations
{
    [DbContext(typeof(NetContext))]
    [Migration("20231120142631_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("NetCourse.Framework.Database.EntityBase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("EntityBase", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("UserStores.Models.User", b =>
                {
                    b.HasBaseType("NetCourse.Framework.Database.EntityBase");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastLoginTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UserStores.Models.User", b =>
                {
                    b.HasOne("NetCourse.Framework.Database.EntityBase", null)
                        .WithOne()
                        .HasForeignKey("UserStores.Models.User", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
