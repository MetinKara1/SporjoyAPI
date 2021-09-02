using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubName = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    DescribeClub = table.Column<string>(nullable: true),
                    ManCoachCount = table.Column<int>(nullable: false),
                    WomenCoachCount = table.Column<int>(nullable: false),
                    TrainingTime = table.Column<DateTime>(nullable: false),
                    AgeGroups = table.Column<string>(nullable: true),
                    isAvailableForDisabled = table.Column<bool>(nullable: false),
                    havePrivateLesson = table.Column<bool>(nullable: false),
                    Due = table.Column<int>(nullable: false),
                    tryLessonPrice = table.Column<int>(nullable: false),
                    haveParking = table.Column<bool>(nullable: false),
                    haveShower = table.Column<bool>(nullable: false),
                    SaloonMeters = table.Column<float>(nullable: false),
                    TrainingCountPerWeek = table.Column<int>(nullable: false),
                    Photos = table.Column<string>(nullable: true),
                    Videos = table.Column<string>(nullable: true),
                    PeymentType = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    MembershipType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(nullable: true),
                    Allowed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Club = table.Column<string>(nullable: true),
                    Trainer = table.Column<string>(nullable: true),
                    MemberType = table.Column<string>(nullable: true),
                    DateEntered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerName = table.Column<string>(nullable: true),
                    TrainerSurname = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffTrainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClubProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(nullable: true),
                    PropertyValue = table.Column<string>(nullable: true),
                    ClubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubProperties_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserComment = table.Column<string>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    Commenter = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    ClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubProperties_ClubId",
                table: "ClubProperties",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ClubId",
                table: "Comments",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubProperties");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "StaffTrainers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
