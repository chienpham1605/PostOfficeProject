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
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "MoneyScope",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    min_value = table.Column<float>(type: "real", nullable: false),
                    max_value = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyScope", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ParcelServices",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    delivery_time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelServices", x => x.service_id);
                });

            migrationBuilder.CreateTable(
                name: "ParcelType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    max_length = table.Column<float>(type: "real", nullable: false),
                    max_width = table.Column<float>(type: "real", nullable: false),
                    max_height = table.Column<float>(type: "real", nullable: false),
                    over_dimension_rate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WeightScope",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    min_weight = table.Column<float>(type: "real", nullable: false),
                    max_weight = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightScope", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ZoneTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zone_description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneTypes", x => x.id);
                });

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
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AppUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AppUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_MoneyServicePrice_MoneyScope_money_scope_id",
                        column: x => x.money_scope_id,
                        principalTable: "MoneyScope",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoneyServicePrice_ZoneTypes_zone_type_id",
                        column: x => x.zone_type_id,
                        principalTable: "ZoneTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelServicePrice",
                columns: table => new
                {
                    parcel_price_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zone_type_id = table.Column<int>(type: "int", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    parcel_type_id = table.Column<int>(type: "int", nullable: false),
                    scope_weight_id = table.Column<int>(type: "int", nullable: false),
                    service_price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelServicePrice", x => x.parcel_price_id);
                    table.ForeignKey(
                        name: "FK_ParcelServicePrice_ParcelServices_service_id",
                        column: x => x.service_id,
                        principalTable: "ParcelServices",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelServicePrice_ParcelType_parcel_type_id",
                        column: x => x.parcel_type_id,
                        principalTable: "ParcelType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelServicePrice_WeightScope_scope_weight_id",
                        column: x => x.scope_weight_id,
                        principalTable: "WeightScope",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelServicePrice_ZoneTypes_zone_type_id",
                        column: x => x.zone_type_id,
                        principalTable: "ZoneTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sender_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sender_pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sender_address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    sender_phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    sender_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_national_identity_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    receiver_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    receiver_pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    receiver_address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    receiver_phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    receiver_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_national_identity_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    transfer_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    transfer_value = table.Column<float>(type: "real", nullable: false),
                    transfer_fee = table.Column<float>(type: "real", nullable: false),
                    payer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    send_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    receive_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    total_charge = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_MoneyOrder_AppUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoneyOrder_Pincodes_receiver_pincode",
                        column: x => x.receiver_pincode,
                        principalTable: "Pincodes",
                        principalColumn: "pincode");
                    table.ForeignKey(
                        name: "FK_MoneyOrder_Pincodes_sender_pincode",
                        column: x => x.sender_pincode,
                        principalTable: "Pincodes",
                        principalColumn: "pincode");
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
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sender_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sender_pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sender_address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    sender_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    sender_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    receiver_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    receiver_pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    receiver_address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    receiver_phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    receiver_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    order_status = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    parcel_length = table.Column<float>(type: "real", nullable: false),
                    parcel_height = table.Column<float>(type: "real", nullable: false),
                    parcel_width = table.Column<float>(type: "real", nullable: false),
                    parcel_weight = table.Column<float>(type: "real", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    parcel_type_id = table.Column<int>(type: "int", nullable: false),
                    payer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    send_date = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: true),
                    receive_date = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: true),
                    vpp_value = table.Column<float>(type: "real", nullable: false),
                    total_charge = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_ParcelOrder_AppUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelOrder_ParcelServices_service_id",
                        column: x => x.service_id,
                        principalTable: "ParcelServices",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelOrder_ParcelType_parcel_type_id",
                        column: x => x.parcel_type_id,
                        principalTable: "ParcelType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelOrder_Pincodes_receiver_pincode",
                        column: x => x.receiver_pincode,
                        principalTable: "Pincodes",
                        principalColumn: "pincode");
                    table.ForeignKey(
                        name: "FK_ParcelOrder_Pincodes_sender_pincode",
                        column: x => x.sender_pincode,
                        principalTable: "Pincodes",
                        principalColumn: "pincode");
                });

            migrationBuilder.CreateTable(
                name: "TrackHistories",
                columns: table => new
                {
                    track_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    new_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    new_location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackHistories", x => x.track_id);
                    table.ForeignKey(
                        name: "FK_TrackHistories_ParcelOrder_order_id",
                        column: x => x.order_id,
                        principalTable: "ParcelOrder",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryEmployees",
                columns: table => new
                {
                    track_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryEmployees", x => new { x.employee_id, x.track_id });
                    table.ForeignKey(
                        name: "FK_HistoryEmployees_AppUsers_employee_id",
                        column: x => x.employee_id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryEmployees_TrackHistories_track_id",
                        column: x => x.track_id,
                        principalTable: "TrackHistories",
                        principalColumn: "track_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0d04dce2-969a-435d-bba4-df3f325983dc"), "48dfc5cb-49f7-44b6-ae1d-69a2bad71b12", "Customer role", "customer", "CUSTOMER" },
                    { new Guid("79bd714f-9576-45ba-b5b7-f00649be00de"), "81c8c541-521a-4f10-b809-9ed8e010bf6c", "Employee role", "employee", "EMPLOYEE" },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "5fa87506-cb95-45a9-9a09-853d5f37faba", "Administrator role", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Create_date", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("49bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, "2fae0b30-1ead-49e7-bcfd-664c27238894", new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoanguyen@gmail.com", true, "Nguyen", "Hoa", false, null, "hoanguyen@gmail.com", "HOANG", "AQAAAAEAACcQAAAAEDj99hi9w25I1mcfqFDCGm0C12R1gF/dM9c6O+8QpRkH8/4oC/O6y/28PEkqyIw94A==", null, false, "", null, false, "hoang" },
                    { new Guid("59bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, "38211eed-842c-42c0-99a6-ea55bfe35195", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenphuonghoa0709@gmail.com", true, "Nguyen", "Phuong Hoa", false, null, "nguyenphuonghoa0709@gmail.com", "HOANP", "AQAAAAEAACcQAAAAECLruET+9yPPQ24hnffNBnqewkHEo2CX51gu3g6DbazBN9B/4A+xT+DVQw2tMeRwAQ==", null, false, "", null, false, "hoanp" },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, "8e895fa1-6546-4c8c-995b-8fe28af66ae8", new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "onlinepostofficegroup4@gmail.com", true, "Pham", "Chien", false, null, "onlinepostofficegroup4@gmail.com", "admin", "AQAAAAEAACcQAAAAEIBw2Zv0V+hNoUCl3oxZi7kbzhVGA9XQUUownIS/gJFHG2gHWmJNsmyFa5ipnCxiyw==", null, false, "", null, false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "id", "area_name" },
                values: new object[,]
                {
                    { 1, "Local" },
                    { 2, "Regional" },
                    { 3, "National" }
                });

            migrationBuilder.InsertData(
                table: "MoneyScope",
                columns: new[] { "id", "description", "max_value", "min_value" },
                values: new object[,]
                {
                    { 1, "Under one million", 1000000f, 1f },
                    { 2, "1 - 5 million", 5000000f, 1000001f },
                    { 3, "5 -20 million", 20000000f, 50000000f },
                    { 4, "20 -50 million", 500000000f, 200000000f },
                    { 5, "Over 50 million", 1E+09f, 500000000f }
                });

            migrationBuilder.InsertData(
                table: "ParcelServices",
                columns: new[] { "service_id", "delivery_time", "description", "name", "status" },
                values: new object[,]
                {
                    { 1, 3, "These services are cost-effective but might take longer for delivery, especially for longer distances.", "Economy", true },
                    { 2, 1, "Fast delivery services that promise quick delivery, often within one day or overnight, regardless of distance.", "Express", true }
                });

            migrationBuilder.InsertData(
                table: "ParcelType",
                columns: new[] { "id", "description", "max_height", "max_length", "max_width", "name", "over_dimension_rate" },
                values: new object[,]
                {
                    { 1, "Document", 100f, 100f, 100f, "Document", 10f },
                    { 2, "Merchandise", 300f, 300f, 300f, "Merchandise", 15f }
                });

            migrationBuilder.InsertData(
                table: "WeightScope",
                columns: new[] { "id", "description", "max_weight", "min_weight" },
                values: new object[,]
                {
                    { 1, "0 - 250g", 250f, 1f },
                    { 2, "250 - 1kg", 1000f, 251f },
                    { 3, "1kg - 10kg", 10000f, 1001f },
                    { 4, "10kg - 30kg", 30000f, 10001f },
                    { 5, "Over 30kg", 100000f, 30001f }
                });

            migrationBuilder.InsertData(
                table: "ZoneTypes",
                columns: new[] { "id", "zone_description" },
                values: new object[,]
                {
                    { 1, "The North" },
                    { 2, "The Central" },
                    { 3, "The South" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("49bd714f-9576-45ba-b5b7-f00649be00de") },
                    { new Guid("79bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("59bd714f-9576-45ba-b5b7-f00649be00de") },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") }
                });

            migrationBuilder.InsertData(
                table: "MoneyServicePrice",
                columns: new[] { "id", "fee", "money_scope_id", "zone_type_id" },
                values: new object[,]
                {
                    { 1, 100000f, 1, 1 },
                    { 2, 150000f, 1, 2 },
                    { 3, 220000f, 1, 3 },
                    { 4, 230000f, 2, 1 },
                    { 5, 270000f, 2, 2 },
                    { 6, 300000f, 2, 3 },
                    { 7, 300000f, 3, 1 },
                    { 8, 340000f, 3, 2 },
                    { 9, 440000f, 3, 3 },
                    { 10, 500000f, 4, 1 },
                    { 11, 550000f, 4, 2 },
                    { 12, 590000f, 4, 3 },
                    { 13, 600000f, 5, 1 },
                    { 14, 660000f, 5, 2 },
                    { 15, 700000f, 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "ParcelServicePrice",
                columns: new[] { "parcel_price_id", "parcel_type_id", "scope_weight_id", "service_id", "service_price", "zone_type_id" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 100000f, 1 },
                    { 2, 1, 1, 1, 150000f, 2 },
                    { 3, 1, 1, 1, 220000f, 3 },
                    { 4, 1, 2, 1, 230000f, 1 },
                    { 5, 1, 2, 1, 270000f, 2 },
                    { 6, 1, 2, 1, 300000f, 3 },
                    { 7, 1, 3, 1, 300000f, 1 },
                    { 8, 1, 3, 1, 340000f, 2 },
                    { 9, 1, 3, 1, 440000f, 3 },
                    { 10, 1, 4, 1, 500000f, 1 },
                    { 11, 1, 4, 1, 550000f, 2 },
                    { 12, 1, 4, 1, 590000f, 3 },
                    { 13, 1, 5, 1, 600000f, 1 },
                    { 14, 1, 5, 1, 660000f, 2 },
                    { 15, 1, 5, 1, 700000f, 3 }
                });

            migrationBuilder.InsertData(
                table: "Pincodes",
                columns: new[] { "pincode", "area_id", "city_name" },
                values: new object[,]
                {
                    { "01000", 1, "Quảng Ninh" },
                    { "03000", 1, "Hải Dương" },
                    { "04000", 1, "Hải Phòng" },
                    { "06000", 1, "Thái Bình" },
                    { "07000", 1, "Nam Định" },
                    { "08000", 1, "Ninh Bình" },
                    { "10000", 1, "Hà Nội" },
                    { "15000", 1, "Vĩnh Phúc" },
                    { "16000", 1, "Bắc Ninh" }
                });

            migrationBuilder.InsertData(
                table: "Pincodes",
                columns: new[] { "pincode", "area_id", "city_name" },
                values: new object[,]
                {
                    { "17000", 1, "Hưng Yên" },
                    { "18000", 1, "Hà Nam" },
                    { "20000", 1, "Hà Giang" },
                    { "21000", 1, "Cao Bằng" },
                    { "22000", 1, "Tuyên Quang" },
                    { "23000", 1, "Bắc Kạn" },
                    { "24000", 1, "Thái Nguyên" },
                    { "25000", 1, "Lạng Sơn" },
                    { "26000", 1, "Bắc Giang" },
                    { "30000", 1, "Lai Châu" },
                    { "31000", 1, "Lào Cai" },
                    { "32000", 1, "Điện Biên" },
                    { "33000", 1, "Yên Bái" },
                    { "34000", 1, "Sơn La" },
                    { "35000", 1, "Phú Thọ" },
                    { "36000", 1, "Hòa Bình" },
                    { "40000", 1, "Thanh Hóa" },
                    { "43000", 1, "Nghệ An" },
                    { "45000", 1, "Hà Tĩnh" },
                    { "47000", 1, "Quảng Bình" },
                    { "48000", 2, "Quảng Trị" },
                    { "49000", 2, "Thừa Thiên–Huế" },
                    { "50000", 2, "Đà Nẵng" },
                    { "51000", 2, "Quảng Nam" },
                    { "53000", 2, "Quảng Ngãi" },
                    { "55000", 2, "Bình Định" },
                    { "56000", 2, "Phú Yên" },
                    { "57000", 2, "Khánh Hòa" },
                    { "59000", 2, "Ninh Thuận" },
                    { "60000", 3, "Kon Tum" },
                    { "61000", 3, "Gia Lai" },
                    { "63000", 3, "Đắk Lắk" },
                    { "65000", 3, "Đắk Nông" },
                    { "66000", 3, "Lâm Đồng" },
                    { "67000", 3, "Bình Phước" },
                    { "70000", 3, "Hồ Chí Minh (TP)" },
                    { "75000", 3, "Bình Dương" },
                    { "76000", 3, "Đồng Nai" },
                    { "77000", 2, "Bình Thuận" },
                    { "78000", 3, "Bà Rịa–Vũng Tàu" },
                    { "80000", 3, "Tây Ninh" },
                    { "81000", 3, "Đồng Tháp" }
                });

            migrationBuilder.InsertData(
                table: "Pincodes",
                columns: new[] { "pincode", "area_id", "city_name" },
                values: new object[,]
                {
                    { "82000", 3, "Long An" },
                    { "84000", 3, "Tiền Giang" },
                    { "85000", 3, "Vĩnh Long" },
                    { "86000", 3, "Bến Tre" },
                    { "87000", 3, "Trà Vinh" },
                    { "90000", 3, "An Giang" },
                    { "91000", 3, "Kiên Giang" },
                    { "94000", 3, "Cần Thơ" },
                    { "95000", 3, "Hậu Giang" },
                    { "96000", 3, "Sóc Trăng" },
                    { "97000", 3, "Bạc Liêu" },
                    { "98000", 3, "Cà Mau" }
                });

            migrationBuilder.InsertData(
                table: "MoneyOrder",
                columns: new[] { "id", "note", "payer", "receive_date", "receiver_address", "receiver_email", "receiver_name", "receiver_national_identity_number", "receiver_phone", "receiver_pincode", "send_date", "sender_address", "sender_email", "sender_name", "sender_national_identity_number", "sender_phone", "sender_pincode", "total_charge", "transfer_fee", "transfer_status", "transfer_value", "user_id" },
                values: new object[] { 1, "pay for home rental", "sender", null, "105 Cong Hoa, Tan Binh District", "lvbay@gmail.com", "Le Van Bay", "0789262637", "055591370", "70000", new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "40 Nguyen Ba Ngoc, Ba Dinh District", "ttbinh@gmail.com", "Tran Thi Binh", "0256214637", "023591330", "40000", 30015000f, 15000f, "pending", 30000000f, new Guid("49bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "OfficeBranchs",
                columns: new[] { "id", "address", "branch_name", "branch_phone", "district_name", "pincode" },
                values: new object[,]
                {
                    { "716040", "60 Phuoc Binh", "Phuoc Binh", "37281646", "Distric 9", "70000" },
                    { "720300", "23 Xo Viet Nghe Tinh, Ward 17", "Thi Nghe", "37281646", "Binh Thanh District", "70000" }
                });

            migrationBuilder.InsertData(
                table: "ParcelOrder",
                columns: new[] { "id", "description", "note", "order_status", "parcel_height", "parcel_length", "parcel_type_id", "parcel_weight", "parcel_width", "payer", "payment_method", "receiver_address", "receiver_email", "receiver_name", "receiver_phone", "receiver_pincode", "sender_address", "sender_email", "sender_name", "sender_phone", "sender_pincode", "service_id", "total_charge", "user_id", "vpp_value" },
                values: new object[] { 1, "2 books, 5 pencils", "birthday presents", 2, 25f, 20f, 2, 0f, 30f, "sender", "Cash", "100 Truong Chinh, Ward 11, Tan Binh District", "lvbay@gmail.com", "Le Van Bay", "097631370", "70000", "40 Nguyen Ba Ngoc, Ward 5, Ba Dinh District", "ttbinh@gmail.com", "Tran Van Quang", "023591330", "40000", 1, 36000f, new Guid("49bd714f-9576-45ba-b5b7-f00649be00de"), 0f });

            migrationBuilder.InsertData(
                table: "TrackHistories",
                columns: new[] { "track_id", "employee_id", "new_location", "new_status", "order_id", "update_time" },
                values: new object[] { 1, new Guid("59bd714f-9576-45ba-b5b7-f00649be00de"), "Nha Trang", "on delivery", 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEmployees_track_id",
                table: "HistoryEmployees",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOrder_receiver_pincode",
                table: "MoneyOrder",
                column: "receiver_pincode");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOrder_sender_pincode",
                table: "MoneyOrder",
                column: "sender_pincode");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOrder_user_id",
                table: "MoneyOrder",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyServicePrice_money_scope_id",
                table: "MoneyServicePrice",
                column: "money_scope_id");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyServicePrice_zone_type_id",
                table: "MoneyServicePrice",
                column: "zone_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeBranchs_pincode",
                table: "OfficeBranchs",
                column: "pincode");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_parcel_type_id",
                table: "ParcelOrder",
                column: "parcel_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_receiver_pincode",
                table: "ParcelOrder",
                column: "receiver_pincode");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_sender_pincode",
                table: "ParcelOrder",
                column: "sender_pincode");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_service_id",
                table: "ParcelOrder",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOrder_user_id",
                table: "ParcelOrder",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelServicePrice_parcel_type_id",
                table: "ParcelServicePrice",
                column: "parcel_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelServicePrice_scope_weight_id",
                table: "ParcelServicePrice",
                column: "scope_weight_id");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelServicePrice_service_id",
                table: "ParcelServicePrice",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelServicePrice_zone_type_id",
                table: "ParcelServicePrice",
                column: "zone_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pincodes_area_id",
                table: "Pincodes",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrackHistories_order_id",
                table: "TrackHistories",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "HistoryEmployees");

            migrationBuilder.DropTable(
                name: "MoneyOrder");

            migrationBuilder.DropTable(
                name: "MoneyServicePrice");

            migrationBuilder.DropTable(
                name: "OfficeBranchs");

            migrationBuilder.DropTable(
                name: "ParcelServicePrice");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "TrackHistories");

            migrationBuilder.DropTable(
                name: "MoneyScope");

            migrationBuilder.DropTable(
                name: "WeightScope");

            migrationBuilder.DropTable(
                name: "ZoneTypes");

            migrationBuilder.DropTable(
                name: "ParcelOrder");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "ParcelServices");

            migrationBuilder.DropTable(
                name: "ParcelType");

            migrationBuilder.DropTable(
                name: "Pincodes");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
