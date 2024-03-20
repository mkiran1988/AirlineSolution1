using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Airline.API.Data.Repositories.Contexts;

#nullable disable

namespace Airline.API.Data.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240319185434_AddSearchHistory")]
    partial class AddSearchHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Airline.API.Models.Models.Domain.FlightSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AircraftType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ArrivalAirport")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureAirport")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("FlightSchedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AircraftType = "Boeing 737",
                            Airline = "Example Airlines",
                            ArrivalAirport = "DEL",
                            ArrivalTime = new DateTime(2024, 3, 20, 5, 24, 31, 826, DateTimeKind.Local).AddTicks(1515),
                            DepartureAirport = "JAK",
                            DepartureTime = new DateTime(2024, 3, 20, 0, 24, 31, 826, DateTimeKind.Local).AddTicks(1502),
                            Duration = new TimeSpan(0, 5, 0, 0, 0),
                            FlightNumber = "ABC123",
                            Price = 500.00m
                        },
                        new
                        {
                            Id = 2,
                            AircraftType = "Airbus A320",
                            Airline = "Another Airlines",
                            ArrivalAirport = "KOCHI",
                            ArrivalTime = new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1532),
                            DepartureAirport = "HYD",
                            DepartureTime = new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1531),
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            FlightNumber = "XYZ456",
                            Price = 350.00m
                        },
                        new
                        {
                            Id = 3,
                            AircraftType = "Airbus A320",
                            Airline = "Another Airlines",
                            ArrivalAirport = "HWD",
                            ArrivalTime = new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1536),
                            DepartureAirport = "LHR",
                            DepartureTime = new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1535),
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            FlightNumber = "XYZ440",
                            Price = 350.00m
                        },
                        new
                        {
                            Id = 4,
                            AircraftType = "Airbus A320",
                            Airline = "Another Airlines",
                            ArrivalAirport = "AHM",
                            ArrivalTime = new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1539),
                            DepartureAirport = "BANG",
                            DepartureTime = new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1539),
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            FlightNumber = "XYZ300",
                            Price = 350.00m
                        },
                        new
                        {
                            Id = 5,
                            AircraftType = "Boeing 737",
                            Airline = "Another Airlines",
                            ArrivalAirport = "BBSR",
                            ArrivalTime = new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1543),
                            DepartureAirport = "MUM",
                            DepartureTime = new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1542),
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            FlightNumber = "ABC456",
                            Price = 350.00m
                        },
                        new
                        {
                            Id = 6,
                            AircraftType = "Airbus A320",
                            Airline = "Another Airlines",
                            ArrivalAirport = "CDG",
                            ArrivalTime = new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1546),
                            DepartureAirport = "HYD",
                            DepartureTime = new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1545),
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            FlightNumber = "AFG250",
                            Price = 350.00m
                        });
                });

            modelBuilder.Entity("Airline.API.Models.Models.Domain.SearchHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Criteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.Property<int>("PageSize")
                        .HasColumnType("int");

                    b.Property<string>("SearchTerm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SearchTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SortBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SearchHistory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("eClaimsService.Models.DTO.Domain.CustomerDetails", b =>
                {
                    b.Property<int>("CustomerDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerDetailID"));

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerDetailID");

                    b.HasIndex("UserId");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("Airline.API.Models.Models.Domain.SearchHistory", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eClaimsService.Models.DTO.Domain.CustomerDetails", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
