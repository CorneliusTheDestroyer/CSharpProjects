﻿// <auto-generated />
using System;
using ComicBookApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComicBookApi.Migrations
{
    [DbContext(typeof(ComicDbContext))]
    [Migration("20250419074428_AddUserTable")]
    partial class AddUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComicBookApi.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("ComicBookApi.Models.Comic", b =>
                {
                    b.Property<int>("ComicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComicId"));

                    b.Property<string>("IssueNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComicId");

                    b.HasIndex("SeriesId");

                    b.ToTable("Comics");
                });

            modelBuilder.Entity("ComicBookApi.Models.ComicCharacter", b =>
                {
                    b.Property<int>("ComicId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComicId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("ComicCharacters");
                });

            modelBuilder.Entity("ComicBookApi.Models.ComicCreator", b =>
                {
                    b.Property<int>("ComicId")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.HasKey("ComicId", "CreatorId");

                    b.HasIndex("CreatorId");

                    b.ToTable("ComicCreators");
                });

            modelBuilder.Entity("ComicBookApi.Models.ComicEvent", b =>
                {
                    b.Property<int>("ComicId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("ComicId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("ComicEvents");
                });

            modelBuilder.Entity("ComicBookApi.Models.Creator", b =>
                {
                    b.Property<int>("CreatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreatorId"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreatorId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("ComicBookApi.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ComicBookApi.Models.Series", b =>
                {
                    b.Property<int>("SeriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeriesId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeriesId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("ComicBookApi.Models.Story", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoryId"));

                    b.Property<int>("ComicId")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoryId");

                    b.HasIndex("ComicId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("ComicBookApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ComicBookApi.Models.Comic", b =>
                {
                    b.HasOne("ComicBookApi.Models.Series", "Series")
                        .WithMany("Comics")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("ComicBookApi.Models.ComicCharacter", b =>
                {
                    b.HasOne("ComicBookApi.Models.Character", "Character")
                        .WithMany("ComicCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicBookApi.Models.Comic", "Comic")
                        .WithMany("ComicCharacters")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("ComicBookApi.Models.ComicCreator", b =>
                {
                    b.HasOne("ComicBookApi.Models.Comic", "Comic")
                        .WithMany("ComicCreators")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicBookApi.Models.Creator", "Creator")
                        .WithMany("ComicCreators")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ComicBookApi.Models.ComicEvent", b =>
                {
                    b.HasOne("ComicBookApi.Models.Comic", "Comic")
                        .WithMany("ComicEvents")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicBookApi.Models.Event", "Event")
                        .WithMany("ComicEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ComicBookApi.Models.Story", b =>
                {
                    b.HasOne("ComicBookApi.Models.Comic", "Comic")
                        .WithMany("Stories")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("ComicBookApi.Models.Character", b =>
                {
                    b.Navigation("ComicCharacters");
                });

            modelBuilder.Entity("ComicBookApi.Models.Comic", b =>
                {
                    b.Navigation("ComicCharacters");

                    b.Navigation("ComicCreators");

                    b.Navigation("ComicEvents");

                    b.Navigation("Stories");
                });

            modelBuilder.Entity("ComicBookApi.Models.Creator", b =>
                {
                    b.Navigation("ComicCreators");
                });

            modelBuilder.Entity("ComicBookApi.Models.Event", b =>
                {
                    b.Navigation("ComicEvents");
                });

            modelBuilder.Entity("ComicBookApi.Models.Series", b =>
                {
                    b.Navigation("Comics");
                });
#pragma warning restore 612, 618
        }
    }
}
