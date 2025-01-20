﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StatCollector.Data;

#nullable disable

namespace StatCollector.Migrations
{
    [DbContext(typeof(PipelineContext))]
    partial class PipelineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("serviceman")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StatCollector.Data.Caller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Login");

                    b.ToTable("users", "serviceman");
                });

            modelBuilder.Entity("StatCollector.Data.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildId")
                        .HasColumnType("integer")
                        .HasColumnName("build_id");

                    b.Property<int>("CallerId")
                        .HasColumnType("integer")
                        .HasColumnName("caller_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("Stages")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("stages");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("status");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("CallerId");

                    b.HasIndex("Name");

                    b.ToTable("pipelines", "serviceman");
                });

            modelBuilder.Entity("StatCollector.Data.Job", b =>
                {
                    b.HasOne("StatCollector.Data.Caller", "Caller")
                        .WithMany("ExecutedJobs")
                        .HasForeignKey("CallerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caller");
                });

            modelBuilder.Entity("StatCollector.Data.Caller", b =>
                {
                    b.Navigation("ExecutedJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
