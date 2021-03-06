﻿// <auto-generated />
using BO;
using DA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace DA.Migrations
{
    [DbContext(typeof(WWWingsContext))]
    [Migration("20171222203738_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BO.AircraftType", b =>
                {
                    b.Property<byte>("TypeID");

                    b.Property<int>("FlugzeugtypdetailID");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.HasKey("TypeID");

                    b.ToTable("AircraftType");
                });

            modelBuilder.Entity("BO.AircraftTypeDetail", b =>
                {
                    b.Property<byte>("AircraftTypeID");

                    b.Property<float?>("Length");

                    b.Property<string>("Memo");

                    b.Property<short?>("Tare");

                    b.Property<byte?>("TurbineCount");

                    b.HasKey("AircraftTypeID");

                    b.ToTable("AircraftTypeDetail");
                });

            modelBuilder.Entity("BO.Airline", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Code");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("BO.Booking", b =>
                {
                    b.Property<int>("FlightNo");

                    b.Property<int>("PassengerID");

                    b.HasKey("FlightNo");

                    b.HasAlternateKey("FlightNo", "PassengerID");

                    b.HasIndex("PassengerID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BO.DepartureGrouping", b =>
                {
                    b.Property<string>("Departure")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlightCount");

                    b.HasKey("Departure");

                    b.ToTable("DepartureGrouping");
                });

            modelBuilder.Entity("BO.Employee", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthday");

                    b.Property<int?>("DetailID");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("EMail");

                    b.Property<string>("GivenName");

                    b.Property<string>("PassportNumber")
                        .HasAnnotation("PropertyAccessMode", PropertyAccessMode.Field);

                    b.Property<float>("Salary");

                    b.Property<int?>("SupervisorPersonID");

                    b.Property<string>("Surname");

                    b.HasKey("PersonID");

                    b.HasIndex("DetailID");

                    b.HasIndex("SupervisorPersonID");

                    b.ToTable("Employee");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employee");
                });

            modelBuilder.Entity("BO.Flight", b =>
                {
                    b.Property<int>("FlightNo");

                    b.Property<byte?>("AircraftTypeID");

                    b.Property<string>("AirlineCode");

                    b.Property<int?>("CopilotId");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FlightDate")
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Departure")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("(offen)")
                        .HasMaxLength(50);

                    b.Property<string>("Destination")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("(offen)")
                        .HasMaxLength(50);

                    b.Property<short?>("FreeSeats");

                    b.Property<DateTime>("LastChange");

                    b.Property<string>("Memo")
                        .HasMaxLength(5000);

                    b.Property<bool?>("NonSmokingFlight");

                    b.Property<int>("PilotId");

                    b.Property<decimal?>("Price")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(123.45m);

                    b.Property<short?>("Seats")
                        .IsRequired();

                    b.Property<bool?>("Strikebound");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal?>("Utilization")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("100.0-(([FreeSeats]*1.0)/[Seats])*100.0");

                    b.HasKey("FlightNo");

                    b.HasIndex("AircraftTypeID");

                    b.HasIndex("AirlineCode");

                    b.HasIndex("CopilotId");

                    b.HasIndex("FreeSeats")
                        .HasName("Index_FreeSeats");

                    b.HasIndex("PilotId");

                    b.HasIndex("Departure", "Destination");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("BO.Passenger", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthday");

                    b.Property<DateTime?>("CustomerSince");

                    b.Property<int?>("DetailID");

                    b.Property<string>("EMail");

                    b.Property<string>("GivenName");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<string>("Surname");

                    b.HasKey("PersonID");

                    b.HasIndex("DetailID");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("BO.Persondetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(30);

                    b.Property<string>("Country")
                        .HasMaxLength(3);

                    b.Property<string>("Memo");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Postcode")
                        .HasMaxLength(8);

                    b.Property<string>("Street")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Persondetail");
                });

            modelBuilder.Entity("BO.Pilot", b =>
                {
                    b.HasBaseType("BO.Employee");

                    b.Property<int?>("FlightHours");

                    b.Property<string>("FlightSchool")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LicenseDate");

                    b.Property<int>("PilotLicenseType");

                    b.ToTable("Pilot");

                    b.HasDiscriminator().HasValue("Pilot");
                });

            modelBuilder.Entity("BO.AircraftTypeDetail", b =>
                {
                    b.HasOne("BO.AircraftType", "AircraftType")
                        .WithOne("Detail")
                        .HasForeignKey("BO.AircraftTypeDetail", "AircraftTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Booking", b =>
                {
                    b.HasOne("BO.Flight", "Flight")
                        .WithMany("BookingSet")
                        .HasForeignKey("FlightNo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Passenger", "Passenger")
                        .WithMany("BookingSet")
                        .HasForeignKey("PassengerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Employee", b =>
                {
                    b.HasOne("BO.Persondetail", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailID");

                    b.HasOne("BO.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorPersonID");
                });

            modelBuilder.Entity("BO.Flight", b =>
                {
                    b.HasOne("BO.AircraftType", "AircraftType")
                        .WithMany("FlightSet")
                        .HasForeignKey("AircraftTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BO.Airline", "Airline")
                        .WithMany("FlightSet")
                        .HasForeignKey("AirlineCode");

                    b.HasOne("BO.Pilot", "Copilot")
                        .WithMany("FlightAsCopilotSet")
                        .HasForeignKey("CopilotId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BO.Pilot", "Pilot")
                        .WithMany("FlightAsPilotSet")
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BO.Passenger", b =>
                {
                    b.HasOne("BO.Persondetail", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailID");
                });
#pragma warning restore 612, 618
        }
    }
}
