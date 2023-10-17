﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudySystem.Data.EF;

#nullable disable

namespace StudySystem.Data.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231016024838_v10")]
    partial class v10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudySystem.Data.Entites.AdministrativeRegions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("code_name");

                    b.Property<string>("CodeNameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("code_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name_en");

                    b.HasKey("Id");

                    b.ToTable("administrative_regions");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.AdministrativeUnits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("code_name");

                    b.Property<string>("CodeNameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("code_name_en");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name_en");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("short_name");

                    b.Property<string>("ShortNameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("short_name_en");

                    b.HasKey("Id");

                    b.ToTable("administrative_units");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.Districts", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("code");

                    b.Property<int>("AdministrativeUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("administrative_unit_id");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("code_name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name_en");

                    b.Property<string>("ProvinceCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("province_code");

                    b.HasKey("Code");

                    b.HasIndex("AdministrativeUnitId")
                        .HasDatabaseName("idx_districts_unit");

                    b.HasIndex("ProvinceCode")
                        .HasDatabaseName("idx_districts_province");

                    b.ToTable("districts");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.Provinces", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("code");

                    b.Property<int>("AdministrativeRegionId")
                        .HasColumnType("integer")
                        .HasColumnName("administrative_region_id");

                    b.Property<int?>("AdministrativeRegionsId1")
                        .HasColumnType("integer");

                    b.Property<int>("AdministrativeUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("administrative_unit_id");

                    b.Property<int?>("AdministrativeUnitsId")
                        .HasColumnType("integer");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("code_name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name_en");

                    b.HasKey("Code");

                    b.HasIndex("AdministrativeRegionId")
                        .HasDatabaseName("idx_provinces_region");

                    b.HasIndex("AdministrativeRegionsId1");

                    b.HasIndex("AdministrativeUnitId")
                        .HasDatabaseName("idx_provinces_unit");

                    b.HasIndex("AdministrativeUnitsId");

                    b.ToTable("provinces");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.UserDetail", b =>
                {
                    b.Property<string>("UserID")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.UserToken", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpireTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExpireTimeOnline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.VerificationOTP", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpireTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserID");

                    b.ToTable("VerificationOTPs");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.Ward", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("code");

                    b.Property<int>("AdministrativeUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("administrative_unit_id");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("code_name");

                    b.Property<string>("DistrictCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("district_code");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name_en");

                    b.HasKey("Code");

                    b.HasIndex("AdministrativeUnitId")
                        .HasDatabaseName("idx_wards_unit");

                    b.HasIndex("DistrictCode")
                        .HasDatabaseName("idx_wards_district");

                    b.ToTable("wards");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.Districts", b =>
                {
                    b.HasOne("StudySystem.Data.Entites.AdministrativeUnits", "AdministrativeUnits")
                        .WithMany("Districts")
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudySystem.Data.Entites.Provinces", "Provinces")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdministrativeUnits");

                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.Provinces", b =>
                {
                    b.HasOne("StudySystem.Data.Entites.AdministrativeRegions", "AdministrativeRegions")
                        .WithMany()
                        .HasForeignKey("AdministrativeRegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudySystem.Data.Entites.AdministrativeRegions", null)
                        .WithMany("Provinces")
                        .HasForeignKey("AdministrativeRegionsId1");

                    b.HasOne("StudySystem.Data.Entites.AdministrativeUnits", "AdministrativeUnits")
                        .WithMany()
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudySystem.Data.Entites.AdministrativeUnits", null)
                        .WithMany("Provinces")
                        .HasForeignKey("AdministrativeUnitsId");

                    b.Navigation("AdministrativeRegions");

                    b.Navigation("AdministrativeUnits");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.Ward", b =>
                {
                    b.HasOne("StudySystem.Data.Entites.AdministrativeUnits", "AdministrativeUnits")
                        .WithMany("Wards")
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudySystem.Data.Entites.Districts", "Districts")
                        .WithMany("Wards")
                        .HasForeignKey("DistrictCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdministrativeUnits");

                    b.Navigation("Districts");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.AdministrativeRegions", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.AdministrativeUnits", b =>
                {
                    b.Navigation("Districts");

                    b.Navigation("Provinces");

                    b.Navigation("Wards");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.Districts", b =>
                {
                    b.Navigation("Wards");
                });

            modelBuilder.Entity("StudySystem.Data.Entites.Provinces", b =>
                {
                    b.Navigation("Districts");
                });
#pragma warning restore 612, 618
        }
    }
}
