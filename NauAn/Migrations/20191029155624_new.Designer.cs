﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NauAn.Models;

namespace NauAn.Migrations
{
    [DbContext(typeof(DBNAContext))]
    [Migration("20191029155624_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NauAn.Models.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ParrentId");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NauAn.Models.Entities.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<int>("PostID");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("NauAn.Models.Entities.Follow", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("NauAn.Models.Entities.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<string>("PostName")
                        .IsRequired();

                    b.Property<int?>("Rating");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("UserID");

                    b.Property<string>("Video");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("NauAn.Models.Entities.Rank", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<string>("RankName");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("NauAn.Models.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday");

                    b.Property<int?>("Gender");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NauAn.Models.Entities.Comment", b =>
                {
                    b.HasOne("NauAn.Models.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NauAn.Models.Entities.User", "CommentOfUser")
                        .WithMany("Comments")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("NauAn.Models.Entities.Follow", b =>
                {
                    b.HasOne("NauAn.Models.Entities.User", "User")
                        .WithMany("Follows")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NauAn.Models.Entities.Post", b =>
                {
                    b.HasOne("NauAn.Models.Entities.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NauAn.Models.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NauAn.Models.Entities.Rank", b =>
                {
                    b.HasOne("NauAn.Models.Entities.User", "User")
                        .WithMany("Ranks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
