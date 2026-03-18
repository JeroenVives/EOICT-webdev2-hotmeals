using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotMeals.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "fk__teachers__staff_id",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "fk__staff__user_id",
                table: "staff");

            migrationBuilder.DropIndex(
                name: "fk__parents__user_id",
                table: "parents");

            migrationBuilder.DropIndex(
                name: "fk__parental_relations__parent_id",
                table: "parental_relations");

            migrationBuilder.DropIndex(
                name: "fk__meal_ingredients__hot_meal_id",
                table: "meal_ingredients");

            migrationBuilder.DropIndex(
                name: "fk__children__user_id",
                table: "children");

            migrationBuilder.DropIndex(
                name: "fk__allergen_sensitivities__child_id",
                table: "allergen_sensitivities");

            migrationBuilder.DropIndex(
                name: "fk__allergen_presences__allergen_id",
                table: "allergen_presences");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "9e02a3fd-164a-4273-8425-e482213cd140", "teacher@vives.be", false, "Anna", "Bossuyt", false, null, "TEACHER@VIVES.BE", "TEACHER@VIVES.BE", "AQAAAAIAAYagAAAAEHBUrJ2jhL5filbL/N90R/iWHiy9yHywdwTPAPYAk8fRDHLF6VmouJOhLJKkA3N1UA==", null, false, "61da5a1f-73e4-4440-95c1-aed9c37e3855", false, "teacher@vives.be" },
                    { 2, 0, "9a5caf55-697c-4b23-8417-a80ab32216f2", "manager@vives.be", false, "Chris", "De Donder", false, null, "MANAGER@VIVES.BE", "MANAGER@VIVES.BE", "AQAAAAIAAYagAAAAEM3ybG6LT6XE894AgpLySGsmzSJEEJsDtmdugaKR7v0adJNiV+FnVN0GDN61jWglLA==", null, false, "e4df9218-b795-4713-8e21-bd82d795aadb", false, "manager@vives.be" }
                });

            migrationBuilder.InsertData(
                table: "staff",
                columns: new[] { "user_id", "role" },
                values: new object[,]
                {
                    { 1, "teaching" },
                    { 2, "management" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "staff",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "staff",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateIndex(
                name: "fk__teachers__staff_id",
                table: "teachers",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "fk__staff__user_id",
                table: "staff",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk__parents__user_id",
                table: "parents",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk__parental_relations__parent_id",
                table: "parental_relations",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "fk__meal_ingredients__hot_meal_id",
                table: "meal_ingredients",
                column: "hot_meal_id");

            migrationBuilder.CreateIndex(
                name: "fk__children__user_id",
                table: "children",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk__allergen_sensitivities__child_id",
                table: "allergen_sensitivities",
                column: "child_id");

            migrationBuilder.CreateIndex(
                name: "fk__allergen_presences__allergen_id",
                table: "allergen_presences",
                column: "allergen_id");
        }
    }
}
