using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c934bc32-f2c1-428b-a84d-ece62febf08d", "3a0f3375-d7ef-49d0-8386-6f5acad90a3c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "fullName" },
                values: new object[] { "1", 0, "ecf869c1-9f7a-4064-bcb2-612e451b093d", "ApplicationUser", "some-admin-email@nonce.fake", true, false, null, "some-admin-email@nonce.fake", "admin", "AQAAAAEAACcQAAAAEJ/13rqc+BXeRMYp0VB+YRAHTNLBBoHa9IEf3Zpqw2x5dqh14is3DScVZlmxSgQxYQ==", null, false, "", false, "admin", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Body", "DateCreated", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 733, DateTimeKind.Utc).AddTicks(863), "https://picsum.photos/id/1011/5472/3648", "article system" },
                    { 2, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1315), "https://picsum.photos/id/1012/3973/2639", "article system post" },
                    { 3, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1546), "https://picsum.photos/id/1019/5472/3648", "article system post" },
                    { 4, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1587), "https://picsum.photos/id/1/5616/3744", "article system post" },
                    { 5, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1625), "https://picsum.photos/id/1001/5616/3744", "article system post" },
                    { 6, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1723), "https://picsum.photos/id/1003/1181/1772", "article system post" },
                    { 7, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1754), "https://picsum.photos/id/1005/5760/3840", "article system post" },
                    { 8, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1787), "https://picsum.photos/id/1026/4621/3070", "article system post" },
                    { 9, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1815), "https://picsum.photos/id/1038/3914/5863", "article system post" },
                    { 10, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1844), "https://picsum.photos/id/1068/7117/4090", "article system post" },
                    { 11, null, "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.", new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1908), "https://picsum.photos/id/1076/4835/3223", "article system post" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
