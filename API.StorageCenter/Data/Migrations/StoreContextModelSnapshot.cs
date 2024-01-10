﻿// <auto-generated />
using System;
using API.StorageCenter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.StorageCenter.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Models.OrderAggregate.DeliveryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMethods");
                });

            modelBuilder.Entity("API.Models.OrderAggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BuyerEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("DeliveryMethodId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Models.OrderAggregate.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductBrandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductBrandId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.Models.ProductBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ProductBrands");
                });

            modelBuilder.Entity("API.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("API.Models.OrderAggregate.Order", b =>
                {
                    b.HasOne("API.Models.OrderAggregate.DeliveryMethod", "DeliveryMethod")
                        .WithMany()
                        .HasForeignKey("DeliveryMethodId");

                    b.OwnsOne("API.Models.OrderAggregate.Address", "ShipToAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("FirstName")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<string>("LastName")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("State")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Street")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });
                });

            modelBuilder.Entity("API.Models.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("API.Models.OrderAggregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("API.Models.OrderAggregate.ProductItemOrdered", "ItemOrdered", b1 =>
                        {
                            b1.Property<int>("OrderItemId")
                                .HasColumnType("int");

                            b1.Property<int>("ProductItemId")
                                .HasColumnType("int");

                            b1.Property<string>("ProductName")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("ProductUrl")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItems");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.HasOne("API.Models.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}