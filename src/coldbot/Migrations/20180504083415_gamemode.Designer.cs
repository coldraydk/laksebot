﻿// <auto-generated />
using System;
using ColdBot.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ColdBot.Migrations
{
    [DbContext(typeof(MagicLeagueContext))]
    [Migration("20180504083415_gamemode")]
    partial class gamemode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview2-30571");

            modelBuilder.Entity("ColdBot.Models.League", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameMode");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("ID");

                    b.ToTable("League");
                });

            modelBuilder.Entity("ColdBot.Models.MatchResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoserName");

                    b.Property<int>("RatingChange");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("WinnerName");

                    b.HasKey("ID");

                    b.HasIndex("LoserName");

                    b.HasIndex("WinnerName");

                    b.ToTable("MatchResults");
                });

            modelBuilder.Entity("ColdBot.Models.Player", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.HasKey("Name");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ColdBot.Models.MatchResult", b =>
                {
                    b.HasOne("ColdBot.Models.Player", "Loser")
                        .WithMany()
                        .HasForeignKey("LoserName");

                    b.HasOne("ColdBot.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerName");
                });
#pragma warning restore 612, 618
        }
    }
}
