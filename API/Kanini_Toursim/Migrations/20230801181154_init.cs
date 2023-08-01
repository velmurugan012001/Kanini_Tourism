using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanini_Toursim.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivitiesId);
                });

            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodType = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BedType = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotalId);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    TravelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Facilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Itinerary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.TravelId);
                });

            migrationBuilder.CreateTable(
                name: "AdminImageGalleries",
                columns: table => new
                {
                    AdminImgsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminImageGalleries", x => x.AdminImgsId);
                    table.ForeignKey(
                        name: "FK_AdminImageGalleries_AdminUsers_Id",
                        column: x => x.Id,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelerId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    OfferingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    Totaldays = table.Column<int>(type: "int", nullable: false),
                    ItineraryDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotalId = table.Column<int>(type: "int", nullable: false),
                    TravelId = table.Column<int>(type: "int", nullable: false),
                    ActivitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageID);
                    table.ForeignKey(
                        name: "FK_Packages_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "ActivitiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_AdminUsers_Id",
                        column: x => x.Id,
                        principalTable: "AdminUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Hotels_HotalId",
                        column: x => x.HotalId,
                        principalTable: "Hotels",
                        principalColumn: "HotalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "TravelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    PackageID = table.Column<int>(type: "int", nullable: true),
                    DateOfTravel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_AdminUsers_Id",
                        column: x => x.Id,
                        principalTable: "AdminUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "PackageID");
                });

            migrationBuilder.CreateTable(
                name: "BillingDetails",
                columns: table => new
                {
                    BillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PackageID = table.Column<int>(type: "int", nullable: true),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingDetails", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_BillingDetails_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillingDetails_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "PackageID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminImageGalleries_Id",
                table: "AdminImageGalleries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_BookingId",
                table: "BillingDetails",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_PackageID",
                table: "BillingDetails",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Id",
                table: "Bookings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PackageID",
                table: "Bookings",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_HotelId",
                table: "Feedback",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ActivitiesId",
                table: "Packages",
                column: "ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_HotalId",
                table: "Packages",
                column: "HotalId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Id",
                table: "Packages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TravelId",
                table: "Packages",
                column: "TravelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminImageGalleries");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "BillingDetails");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Travels");
        }
    }
}
