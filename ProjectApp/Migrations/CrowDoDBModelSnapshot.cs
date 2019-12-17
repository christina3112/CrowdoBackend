﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectApp.Database;

namespace ProjectApp.Migrations
{
    [DbContext(typeof(CrowDoDB))]
    partial class CrowDoDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Funding", b =>
                {
                    b.Property<int>("FundingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfPackages")
                        .HasColumnType("int");

                    b.Property<string>("PackageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectItemId")
                        .HasColumnType("int");

                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FundingId");

                    b.HasIndex("ProjectItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Fundings");
                });

            modelBuilder.Entity("Entities.PackageItemAsking", b =>
                {
                    b.Property<int>("PackageItemAskingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectItemId")
                        .HasColumnType("int");

                    b.Property<string>("Rewards")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackageItemAskingId");

                    b.HasIndex("ProjectItemId");

                    b.ToTable("PackagesAsking");
                });

            modelBuilder.Entity("Entities.PackageItemReceived", b =>
                {
                    b.Property<int>("PackageItemReceivedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PackageItemAskingId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectItemId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PackageItemReceivedId");

                    b.HasIndex("PackageItemAskingId");

                    b.HasIndex("ProjectItemId");

                    b.HasIndex("UserId");

                    b.ToTable("PackagesReceived");
                });

            modelBuilder.Entity("Entities.ProjectItem", b =>
                {
                    b.Property<int>("ProjectItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfRequestedPackages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAskingFunds")
                        .HasColumnType("float");

                    b.Property<double>("TotalReceivingFunds")
                        .HasColumnType("float");

                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Funding", b =>
                {
                    b.HasOne("Entities.ProjectItem", "ProjectItem")
                        .WithMany()
                        .HasForeignKey("ProjectItemId");

                    b.HasOne("Entities.User", "User")
                        .WithMany("ProjectFunding")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Entities.PackageItemAsking", b =>
                {
                    b.HasOne("Entities.ProjectItem", null)
                        .WithMany("PackagesAsking")
                        .HasForeignKey("ProjectItemId");
                });

            modelBuilder.Entity("Entities.PackageItemReceived", b =>
                {
                    b.HasOne("Entities.PackageItemAsking", "PackageItemAsking")
                        .WithMany()
                        .HasForeignKey("PackageItemAskingId");

                    b.HasOne("Entities.ProjectItem", "ProjectItem")
                        .WithMany("PackagesReceived")
                        .HasForeignKey("ProjectItemId");

                    b.HasOne("Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Entities.ProjectItem", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("ProjectCreations")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
