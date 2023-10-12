using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostOffice.API.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MoneyServicePrice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zone_type_id = table.Column<int>(type: "int", nullable: false),
                    money_scope_id = table.Column<int>(type: "int", nullable: false),
                    fee = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyServicePrice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ParcelServicePrice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zone_type_id = table.Column<int>(type: "int", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    parcel_type_id = table.Column<int>(type: "int", nullable: false),
                    scope_weight_id = table.Column<int>(type: "int", nullable: false),
                    service_price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelServicePrice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pincodes",
                columns: table => new
                {
                    pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    city_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pincodes", x => x.pincode);
                    table.ForeignKey(
                        name: "FK_Pincodes_Areas_area_id",
                        column: x => x.area_id,
                        principalTable: "Areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyScope",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    min_value = table.Column<float>(type: "real", nullable: false),
                    max_value = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyScope", x => x.id);
                    table.ForeignKey(
                        name: "FK_MoneyScope_MoneyServicePrice_Priceid",
                        column: x => x.Priceid,
                        principalTable: "MoneyServicePrice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelService",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delivery_time = table.Column<int>(type: "int", nullable: false),
                    Priceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelService", x => x.id);
                    table.ForeignKey(
                        name: "FK_ParcelService_ParcelServicePrice_Priceid",
                        column: x => x.Priceid,
                        principalTable: "ParcelServicePrice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    max_length = table.Column<float>(type: "real", nullable: false),
                    max_width = table.Column<float>(type: "real", nullable: false),
                    max_height = table.Column<float>(type: "real", nullable: false),
                    max_weight = table.Column<float>(type: "real", nullable: false),
                    over_dimension_rate = table.Column<float>(type: "real", nullable: false),
                    Priceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelType", x => x.id);
                    table.ForeignKey(
                        name: "FK_ParcelType_ParcelServicePrice_Priceid",
                        column: x => x.Priceid,
                        principalTable: "ParcelServicePrice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeightScope",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    min_weight = table.Column<float>(type: "real", nullable: false),
                    max_weight = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightScope", x => x.id);
                    table.ForeignKey(
                        name: "FK_WeightScope_ParcelServicePrice_Priceid",
                        column: x => x.Priceid,
                        principalTable: "ParcelServicePrice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZoneType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zone_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneType", x => x.id);
                    table.ForeignKey(
                        name: "FK_ZoneType_ParcelServicePrice_Priceid",
                        column: x => x.Priceid,
                        principalTable: "ParcelServicePrice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_national_identity_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_national_identity_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transfer_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transfer_value = table.Column<float>(type: "real", nullable: false),
                    transfer_fee = table.Column<float>(type: "real", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    parcel_type_id = table.Column<int>(type: "int", nullable: false),
                    payer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    send_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    receive_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_charge = table.Column<float>(type: "real", nullable: false),
                    pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoneyServicePriceid = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_MoneyOrder_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MoneyOrder_MoneyServicePrice_MoneyServicePriceid",
                        column: x => x.MoneyServicePriceid,
                        principalTable: "MoneyServicePrice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoneyOrder_Pincodes_pincode",
                        column: x => x.pincode,
                        principalTable: "Pincodes",
                        principalColumn: "pincode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeBranchs",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    branch_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    district_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branch_phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeBranchs", x => x.id);
                    table.ForeignKey(
                        name: "FK_OfficeBranchs_Pincodes_pincode",
                        column: x => x.pincode,
                        principalTable: "Pincodes",
                        principalColumn: "pincode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parcel_length = table.Column<float>(type: "real", nullable: false),
                    parcel_height = table.Column<float>(type: "real", nullable: false),
                    parcel_width = table.Column<float>(type: "real", nullable: false),
                    parcel_weight = table.Column<float>(type: "real", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    parcel_type_id = table.Column<int>(type: "int", nullable: false),
                    payer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    send_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    receive_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vpp_value = table.Column<float>(type: "real", nullable: false),
                    total_charge = table.Column<float>(type: "real", nullable: false),
                    ParcelServiceid = table.Column<int>(type: "int", nullable: false),
                    ParcelTypeid = table.Column<int>(type: "int", nullable: false),
                    pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_ParcelOrder_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOrder_ParcelService_ParcelServiceid",
                        column: x => x.ParcelServiceid,
                        principalTable: "ParcelService",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelOrder_ParcelType_ParcelTypeid",
                        column: x => x.ParcelTypeid,
                        principalTable: "ParcelType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelOrder_Pincodes_pincode",
                        column: x => x.pincode,
                        principalTable: "Pincodes",
                        principalColumn: "pincode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOrder_AppUserId",
                table: "MoneyOrder",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOrder_MoneyServicePriceid",
                table: "MoneyOrder",
                column: "MoneyServicePriceid");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOrder_pincode",
                table: "MoneyOrder",
                column: "pincode");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyScope_Priceid",
                table: "MoneyScope",
                column: "Priceid");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeBranchs_pincode",
                table: "OfficeBranchs",
                column: "pincode");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_AppUserId",
                table: "ParcelOrder",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_ParcelServiceid",
                table: "ParcelOrder",
                column: "ParcelServiceid");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_ParcelTypeid",
                table: "ParcelOrder",
                column: "ParcelTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_pincode",
                table: "ParcelOrder",
                column: "pincode");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelService_Priceid",
                table: "ParcelService",
                column: "Priceid");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelType_Priceid",
                table: "ParcelType",
                column: "Priceid");

            migrationBuilder.CreateIndex(
                name: "IX_Pincodes_area_id",
                table: "Pincodes",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_WeightScope_Priceid",
                table: "WeightScope",
                column: "Priceid");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneType_Priceid",
                table: "ZoneType",
                column: "Priceid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "MoneyOrder");

            migrationBuilder.DropTable(
                name: "MoneyScope");

            migrationBuilder.DropTable(
                name: "OfficeBranchs");

            migrationBuilder.DropTable(
                name: "ParcelOrder");

            migrationBuilder.DropTable(
                name: "WeightScope");

            migrationBuilder.DropTable(
                name: "ZoneType");

            migrationBuilder.DropTable(
                name: "MoneyServicePrice");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "ParcelService");

            migrationBuilder.DropTable(
                name: "ParcelType");

            migrationBuilder.DropTable(
                name: "Pincodes");

            migrationBuilder.DropTable(
                name: "ParcelServicePrice");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
