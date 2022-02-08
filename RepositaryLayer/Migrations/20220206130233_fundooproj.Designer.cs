﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositaryLayer.AppContext;

namespace RepositaryLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220206130233_fundooproj")]
    partial class fundooproj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepositaryLayer.Entities.CollabEntity", b =>
                {
                    b.Property<long>("CollabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollabEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Noteid")
                        .HasColumnType("bigint");

                    b.Property<long>("Userid")
                        .HasColumnType("bigint");

                    b.Property<long?>("notesNoteID")
                        .HasColumnType("bigint");

                    b.HasKey("CollabId");

                    b.HasIndex("Userid");

                    b.HasIndex("notesNoteID");

                    b.ToTable("Collaborator");
                });

            modelBuilder.Entity("RepositaryLayer.Entities.LabelEntity", b =>
                {
                    b.Property<long>("LabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LabelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Noteid")
                        .HasColumnType("bigint");

                    b.Property<long>("Userid")
                        .HasColumnType("bigint");

                    b.Property<long?>("notesNoteID")
                        .HasColumnType("bigint");

                    b.HasKey("LabelId");

                    b.HasIndex("Userid");

                    b.HasIndex("notesNoteID");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("RepositaryLayer.Entities.NoteEntity", b =>
                {
                    b.Property<long>("NoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTrash")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("NoteID");

                    b.HasIndex("userid");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("RepositaryLayer.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RepositaryLayer.Entities.CollabEntity", b =>
                {
                    b.HasOne("RepositaryLayer.Entities.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositaryLayer.Entities.NoteEntity", "notes")
                        .WithMany()
                        .HasForeignKey("notesNoteID");
                });

            modelBuilder.Entity("RepositaryLayer.Entities.LabelEntity", b =>
                {
                    b.HasOne("RepositaryLayer.Entities.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositaryLayer.Entities.NoteEntity", "notes")
                        .WithMany()
                        .HasForeignKey("notesNoteID");
                });

            modelBuilder.Entity("RepositaryLayer.Entities.NoteEntity", b =>
                {
                    b.HasOne("RepositaryLayer.Entities.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}