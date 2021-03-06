﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeuFinesse.Data.Repository;

namespace NeuFinesse.Data.Migrations
{
    [DbContext(typeof(NeuFinesseContext))]
    [Migration("20190430050644_NeuFinesse.Data.DataManager.Item")]
    partial class NeuFinesseDataDataManagerItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NeuFinesse.Data.Model.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("DateOfDelivery");

                    b.Property<DateTime>("DateOfPurchase");

                    b.Property<int>("StatusId");

                    b.Property<string>("UserId");

                    b.HasKey("BillId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserId");

                    b.HasKey("CartId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterestImage");

                    b.Property<string>("InterestName");

                    b.HasKey("InterestId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details");

                    b.Property<int>("InterestId");

                    b.Property<string>("ItemImage");

                    b.Property<string>("ItemName");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("Type");

                    b.Property<decimal>("Weight");

                    b.HasKey("ItemId");

                    b.HasIndex("InterestId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillId");

                    b.Property<int>("ItemId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId");

                    b.HasIndex("BillId");

                    b.HasIndex("ItemId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.ReviewRating", b =>
                {
                    b.Property<int>("ReviewRatingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<string>("UserId");

                    b.HasKey("ReviewRatingId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewRating");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.SellerDetail", b =>
                {
                    b.Property<int>("SellerDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.Property<string>("SellerImage");

                    b.Property<string>("UserId");

                    b.HasKey("SellerDetailId");

                    b.HasIndex("UserId");

                    b.ToTable("SellerDetail");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.SellerItem", b =>
                {
                    b.Property<int>("SellerItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItemId");

                    b.Property<string>("UserId");

                    b.HasKey("SellerItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("SellerItem");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.SellerSkill", b =>
                {
                    b.Property<int>("SellerSkillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Endorsement");

                    b.Property<int>("InterestId");

                    b.Property<string>("UserId");

                    b.HasKey("SellerSkillId");

                    b.HasIndex("InterestId");

                    b.HasIndex("UserId");

                    b.ToTable("SellerSkill");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("Role");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new { UserId = "123", Email = "surajdma@gmail.com", Role = 0, UserName = "suraj" }
                    );
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.UserInterest", b =>
                {
                    b.Property<int>("UserInterestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestId");

                    b.Property<string>("UserId");

                    b.HasKey("UserInterestId");

                    b.HasIndex("InterestId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInterest");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.WishList", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("UserId");

                    b.HasKey("CartId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Bill", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeuFinesse.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Cart", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeuFinesse.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Item", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.Order", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeuFinesse.Data.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.ReviewRating", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeuFinesse.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.SellerDetail", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.SellerItem", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("NeuFinesse.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.SellerSkill", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeuFinesse.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.UserInterest", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeuFinesse.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NeuFinesse.Data.Model.WishList", b =>
                {
                    b.HasOne("NeuFinesse.Data.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeuFinesse.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
