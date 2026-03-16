using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotMeals.Data.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "allergens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hot_meals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    recipe = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "enum('meat','veggie','vegan')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    unit_of_measurement = table.Column<string>(type: "enum('kg','l','')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parents",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.user_id);
                    table.ForeignKey(
                        name: "fk__parents__user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    role = table.Column<string>(type: "enum('kitchen','teaching','management')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.user_id);
                    table.ForeignKey(
                        name: "fk__staff__user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "children",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    class_id = table.Column<int>(type: "int(11)", nullable: false),
                    food_preference = table.Column<string>(type: "enum('meat','veggie','vegan')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.user_id);
                    table.ForeignKey(
                        name: "fk__children__class_id",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk__children__user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "scheduled_hot_meals",
                columns: table => new
                {
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    hot_meal_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.date, x.hot_meal_id });
                    table.ForeignKey(
                        name: "fk__scheduled_hot_meals__hot_meal_id",
                        column: x => x.hot_meal_id,
                        principalTable: "hot_meals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "allergen_presences",
                columns: table => new
                {
                    allergen_id = table.Column<int>(type: "int(11)", nullable: false),
                    ingredient_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.allergen_id, x.ingredient_id });
                    table.ForeignKey(
                        name: "fk__allergen_presences__allergen_id",
                        column: x => x.allergen_id,
                        principalTable: "allergens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk__allergen_presences__ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "meal_ingredients",
                columns: table => new
                {
                    hot_meal_id = table.Column<int>(type: "int(11)", nullable: false),
                    ingredient_id = table.Column<int>(type: "int(11)", nullable: false),
                    quantity = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.hot_meal_id, x.ingredient_id });
                    table.ForeignKey(
                        name: "fk__meal_ingredients__hot_meal_id",
                        column: x => x.hot_meal_id,
                        principalTable: "hot_meals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk__meal_ingredients__ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int(11)", nullable: false),
                    class_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.staff_id, x.class_id });
                    table.ForeignKey(
                        name: "fk__teachers__class_id",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk__teachers__staff_id",
                        column: x => x.staff_id,
                        principalTable: "staff",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "allergen_sensitivities",
                columns: table => new
                {
                    child_id = table.Column<int>(type: "int(11)", nullable: false),
                    allergen_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.child_id, x.allergen_id });
                    table.ForeignKey(
                        name: "fk__allergen_sensitivities__allergen_id",
                        column: x => x.allergen_id,
                        principalTable: "allergens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk__allergen_sensitivities__child_id",
                        column: x => x.child_id,
                        principalTable: "children",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "meal_choices",
                columns: table => new
                {
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    child_id = table.Column<int>(type: "int(11)", nullable: false),
                    choice = table.Column<string>(type: "enum('home','cold','hot')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.date, x.child_id });
                    table.ForeignKey(
                        name: "fk__meal_choices__child_id",
                        column: x => x.child_id,
                        principalTable: "children",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parental_relations",
                columns: table => new
                {
                    parent_id = table.Column<int>(type: "int(11)", nullable: false),
                    child_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.parent_id, x.child_id });
                    table.ForeignKey(
                        name: "fk__parental_relations__child_id",
                        column: x => x.child_id,
                        principalTable: "children",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk__parental_relations__parent_id",
                        column: x => x.parent_id,
                        principalTable: "parents",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hot_meal_choices",
                columns: table => new
                {
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    meal_choice_child_id = table.Column<int>(type: "int(11)", nullable: false),
                    hot_meal_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.date, x.meal_choice_child_id, x.hot_meal_id });
                    table.ForeignKey(
                        name: "fk__hot_meal_choices__meal_choice_composite",
                        columns: x => new { x.date, x.meal_choice_child_id },
                        principalTable: "meal_choices",
                        principalColumns: new[] { "date", "child_id" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk__hot_meal_choices__scheduled_hot_meal_composite",
                        columns: x => new { x.date, x.hot_meal_id },
                        principalTable: "scheduled_hot_meals",
                        principalColumns: new[] { "date", "hot_meal_id" },
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk__allergen_presences__allergen_id",
                table: "allergen_presences",
                column: "allergen_id");

            migrationBuilder.CreateIndex(
                name: "fk__allergen_presences__ingredient_id",
                table: "allergen_presences",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "fk__allergen_sensitivities__allergen_id",
                table: "allergen_sensitivities",
                column: "allergen_id");

            migrationBuilder.CreateIndex(
                name: "fk__allergen_sensitivities__child_id",
                table: "allergen_sensitivities",
                column: "child_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk__children__class_id",
                table: "children",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "fk__children__user_id",
                table: "children",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk__hot_meal_choices__hot_meal_id",
                table: "hot_meal_choices",
                column: "hot_meal_id");

            migrationBuilder.CreateIndex(
                name: "fk__hot_meal_choices__scheduled_hot_meal_composite",
                table: "hot_meal_choices",
                columns: new[] { "date", "hot_meal_id" });

            migrationBuilder.CreateIndex(
                name: "fk__meal_choices__child_id",
                table: "meal_choices",
                column: "child_id");

            migrationBuilder.CreateIndex(
                name: "fk__meal_ingredients__hot_meal_id",
                table: "meal_ingredients",
                column: "hot_meal_id");

            migrationBuilder.CreateIndex(
                name: "fk__meal_ingredients__ingredient_id",
                table: "meal_ingredients",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "fk__parental_relations__child_id",
                table: "parental_relations",
                column: "child_id");

            migrationBuilder.CreateIndex(
                name: "fk__parental_relations__parent_id",
                table: "parental_relations",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "fk__parents__user_id",
                table: "parents",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk__scheduled_hot_meals__hot_meal_id",
                table: "scheduled_hot_meals",
                column: "hot_meal_id");

            migrationBuilder.CreateIndex(
                name: "fk__staff__user_id",
                table: "staff",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk__teachers__class_id",
                table: "teachers",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "fk__teachers__staff_id",
                table: "teachers",
                column: "staff_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allergen_presences");

            migrationBuilder.DropTable(
                name: "allergen_sensitivities");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "hot_meal_choices");

            migrationBuilder.DropTable(
                name: "meal_ingredients");

            migrationBuilder.DropTable(
                name: "parental_relations");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "allergens");

            migrationBuilder.DropTable(
                name: "meal_choices");

            migrationBuilder.DropTable(
                name: "scheduled_hot_meals");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "parents");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "children");

            migrationBuilder.DropTable(
                name: "hot_meals");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
