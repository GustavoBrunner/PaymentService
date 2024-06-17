﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using payment_system.Entities.Db;

#nullable disable

namespace payment_system.Migrations
{
    [DbContext(typeof(TransactionsDbContext))]
    [Migration("20240617170221_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("payment_system.Entities.Transaction", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Value")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("TransactionId", "UserId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("UserId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("payment_system.Entities.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("payment_system.Entities.Transaction", b =>
                {
                    b.HasOne("payment_system.Entities.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("payment_system.Entities.User", "Payer")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payer");

                    b.Navigation("Receiver");
                });
#pragma warning restore 612, 618
        }
    }
}
