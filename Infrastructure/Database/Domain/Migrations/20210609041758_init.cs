using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Domain.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProductTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Level", "Name", "ParentId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "FA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "流行時尚", "", null, null },
                    { "ME16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "汽車", "ME", null, null },
                    { "CA15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "運動休閒", "CA", null, null },
                    { "CA14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "玩具", "CA", null, null },
                    { "CA13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "零食", "CA", null, null },
                    { "CA12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "寵物用品", "CA", null, null },
                    { "CA11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "單眼攝影", "CA", null, null },
                    { "TE10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "手機平板", "TE", null, null },
                    { "TE09", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "電腦3C", "TE", null, null },
                    { "LI08", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "居家生活", "LI", null, null },
                    { "ME17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "汽機車零件", "ME", null, null },
                    { "LI07", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "家電用品", "LI", null, null },
                    { "LI05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "圖書", "LI", null, null },
                    { "FA04", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "名牌精品", "FA", null, null },
                    { "FA03", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "美妝保養", "FA", null, null },
                    { "FA02", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "女士時尚", "FA", null, null },
                    { "FA01", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "男士時尚", "FA", null, null },
                    { "ME", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "汽車房屋", "", null, null },
                    { "CA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "休閒良品", "", null, null },
                    { "TE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "科技", "", null, null },
                    { "LI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "生活家居", "", null, null },
                    { "LI06", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "親子用品", "LI", null, null },
                    { "ME18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "機車", "ME", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "OriginalPrice", "ProductTypeId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("277fd4d8-c3d9-489c-ac4f-1819a172f51e"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3500.0, "FA02", 1, "Product2", null, null },
                    { new Guid("44750262-47c5-49d9-b311-2dd7d4b16726"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4400.0, "CA11", 0, "Product12", null, null },
                    { new Guid("ae38dbfc-c227-41eb-bcf5-e4bf01954589"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 700.0, "CA11", 2, "Product13", null, null },
                    { new Guid("088a0f2d-64d7-4209-9641-c8f5951c1829"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2800.0, "CA11", 1, "Product26", null, null },
                    { new Guid("b8d19f96-4c1d-409c-a492-35c3d826de5e"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2400.0, "CA11", 0, "Product45", null, null },
                    { new Guid("2d707c44-ba6c-4443-9df0-a6045054bb27"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2600.0, "CA12", 2, "Product10", null, null },
                    { new Guid("2ea26976-5676-4d39-9d82-7d4dcb1fd78e"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4200.0, "CA12", 1, "Product11", null, null },
                    { new Guid("10d825bb-7eb9-44ea-8766-cccaa6b27520"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1900.0, "CA12", 0, "Product18", null, null },
                    { new Guid("a7169f6e-6d0a-4a75-a3d2-d8ce264392de"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3500.0, "CA13", 2, "Product6", null, null },
                    { new Guid("384c84bc-b447-4837-af75-d844d9db0f59"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 300.0, "CA14", 0, "Product30", null, null },
                    { new Guid("828b688f-2bd7-47ff-9530-b0c390b0f78f"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 800.0, "CA14", 2, "Product33", null, null },
                    { new Guid("31f487b4-306e-4f99-a725-aac443df8555"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2100.0, "CA14", 2, "Product37", null, null },
                    { new Guid("95d1de73-59e6-4799-9e10-f450cdc503f8"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2300.0, "CA15", 2, "Product24", null, null },
                    { new Guid("0fa28613-c8e0-4786-aa98-9b6c57c8a759"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1600.0, "CA15", 0, "Product27", null, null },
                    { new Guid("cf43402d-02d6-4dd1-933e-987c15f108dd"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 500.0, "CA15", 0, "Product36", null, null },
                    { new Guid("a495a080-ec1e-4dc4-902b-17f8ad45171d"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4000.0, "ME16", 1, "Product20", null, null },
                    { new Guid("1299f268-2e7e-4d69-9963-56f5a1255834"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4100.0, "ME16", 2, "Product22", null, null },
                    { new Guid("651ec06a-f339-4276-a212-e5bf9d0e6cd1"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 5000.0, "ME17", 1, "Product8", null, null },
                    { new Guid("56c6baa8-25a3-4ee2-9a3e-998cbe01593c"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4100.0, "ME17", 2, "Product14", null, null },
                    { new Guid("b6b2664d-e580-4006-b565-e38da1bfdc39"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3900.0, "ME17", 0, "Product21", null, null },
                    { new Guid("90a79af8-5806-41b2-9424-e4f0d66e58a3"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2200.0, "ME17", 1, "Product35", null, null },
                    { new Guid("4c3e8b28-2304-4e1c-bed9-52da6b6e6921"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4000.0, "ME17", 2, "Product42", null, null },
                    { new Guid("76ca08d3-1948-499b-a55a-cc80d35c270c"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3000.0, "TE10", 1, "Product47", null, null },
                    { new Guid("30c5e90c-ef4c-4ae8-ac62-7306fb26f787"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2800.0, "TE10", 2, "Product41", null, null },
                    { new Guid("5c2fe472-af86-4ff2-bdd8-90ee19e89457"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4900.0, "TE10", 2, "Product40", null, null },
                    { new Guid("dbf71e8b-fc91-4197-83c7-e2d4aba39559"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1200.0, "TE10", 2, "Product31", null, null },
                    { new Guid("289b0815-7915-437f-a465-e72f7fed1c5d"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1700.0, "FA02", 2, "Product34", null, null },
                    { new Guid("c061a95d-486d-42b7-9809-947664491d2e"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1300.0, "FA02", 1, "Product44", null, null },
                    { new Guid("08b24b4f-c5b3-4f88-89ce-16e377307b0a"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 5000.0, "FA03", 1, "Product29", null, null },
                    { new Guid("70f179cb-63f4-44c2-b2f6-2f2f9da559de"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 900.0, "FA03", 0, "Product39", null, null },
                    { new Guid("f0f447b2-07ce-4025-867b-5baaef290bc1"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1700.0, "FA04", 2, "Product1", null, null },
                    { new Guid("d2f4f3e0-3868-4ae3-bbce-9fd6e06453f0"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 300.0, "FA04", 2, "Product4", null, null },
                    { new Guid("89ea543f-5668-4428-b521-5f5b923e8099"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 200.0, "FA04", 0, "Product9", null, null },
                    { new Guid("f96a2f0c-ac8f-4c6c-a5d3-2251d5a89961"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 800.0, "FA04", 2, "Product15", null, null },
                    { new Guid("373a2a4a-5964-48e1-8d9c-39efc1e47797"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1000.0, "FA04", 2, "Product28", null, null },
                    { new Guid("2a62f12c-fe51-4497-a769-c8a162b0052d"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4900.0, "FA04", 2, "Product43", null, null },
                    { new Guid("c19fb81f-990d-4306-a2f0-f6c0f5f2fe84"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2900.0, "ME18", 2, "Product5", null, null },
                    { new Guid("e7fc3b52-9811-42bb-9180-5f92b75b90a2"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 900.0, "FA04", 2, "Product50", null, null },
                    { new Guid("e78dd793-8f0b-4a04-8a93-8bbc070c15c5"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2100.0, "LI05", 1, "Product17", null, null },
                    { new Guid("28c47902-d780-4cb5-9baf-91ff5aadff3b"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 400.0, "LI06", 2, "Product19", null, null },
                    { new Guid("8c3e4a62-b5c6-4963-b977-0af45e53d5f1"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1300.0, "LI06", 2, "Product25", null, null },
                    { new Guid("8146c09f-bbae-4c6f-98a8-0b05ebb6f6d7"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3200.0, "LI06", 2, "Product32", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "OriginalPrice", "ProductTypeId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4bb32d43-278e-4014-bbc1-af755d957aab"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2300.0, "LI06", 1, "Product38", null, null },
                    { new Guid("a93c9da0-c004-4a94-b693-c805c342135b"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3700.0, "LI06", 0, "Product48", null, null },
                    { new Guid("60861ea1-709e-4bb7-9113-62c018fc5036"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 500.0, "LI08", 0, "Product3", null, null },
                    { new Guid("453c846e-3709-41c4-af22-cece1c99ed50"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2900.0, "LI08", 2, "Product46", null, null },
                    { new Guid("42ace2ea-a0d1-432f-b93a-c5ceff781e33"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 900.0, "LI08", 2, "Product49", null, null },
                    { new Guid("b562aea4-22ec-4eca-8d90-ff42826b57dd"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3700.0, "TE09", 2, "Product23", null, null },
                    { new Guid("c5180b08-675b-402d-99df-d78895fcb1d3"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 700.0, "LI05", 2, "Product16", null, null },
                    { new Guid("34c55eb8-97c6-47f0-9f4d-388e9be9a4b8"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1200.0, "ME18", 2, "Product7", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("277fd4d8-c3d9-489c-ac4f-1819a172f51e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("10d825bb-7eb9-44ea-8766-cccaa6b27520"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("10d825bb-7eb9-44ea-8766-cccaa6b27520"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("10d825bb-7eb9-44ea-8766-cccaa6b27520"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("10d825bb-7eb9-44ea-8766-cccaa6b27520"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("10d825bb-7eb9-44ea-8766-cccaa6b27520"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a7169f6e-6d0a-4a75-a3d2-d8ce264392de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a7169f6e-6d0a-4a75-a3d2-d8ce264392de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a7169f6e-6d0a-4a75-a3d2-d8ce264392de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a7169f6e-6d0a-4a75-a3d2-d8ce264392de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a7169f6e-6d0a-4a75-a3d2-d8ce264392de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a7169f6e-6d0a-4a75-a3d2-d8ce264392de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("384c84bc-b447-4837-af75-d844d9db0f59"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("384c84bc-b447-4837-af75-d844d9db0f59"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("384c84bc-b447-4837-af75-d844d9db0f59"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("384c84bc-b447-4837-af75-d844d9db0f59"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("828b688f-2bd7-47ff-9530-b0c390b0f78f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("828b688f-2bd7-47ff-9530-b0c390b0f78f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("828b688f-2bd7-47ff-9530-b0c390b0f78f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("828b688f-2bd7-47ff-9530-b0c390b0f78f"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("31f487b4-306e-4f99-a725-aac443df8555"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("31f487b4-306e-4f99-a725-aac443df8555"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2ea26976-5676-4d39-9d82-7d4dcb1fd78e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("31f487b4-306e-4f99-a725-aac443df8555"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2ea26976-5676-4d39-9d82-7d4dcb1fd78e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2ea26976-5676-4d39-9d82-7d4dcb1fd78e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("76ca08d3-1948-499b-a55a-cc80d35c270c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("76ca08d3-1948-499b-a55a-cc80d35c270c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("44750262-47c5-49d9-b311-2dd7d4b16726"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("44750262-47c5-49d9-b311-2dd7d4b16726"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("44750262-47c5-49d9-b311-2dd7d4b16726"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("44750262-47c5-49d9-b311-2dd7d4b16726"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ae38dbfc-c227-41eb-bcf5-e4bf01954589"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ae38dbfc-c227-41eb-bcf5-e4bf01954589"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ae38dbfc-c227-41eb-bcf5-e4bf01954589"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ae38dbfc-c227-41eb-bcf5-e4bf01954589"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("088a0f2d-64d7-4209-9641-c8f5951c1829"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("088a0f2d-64d7-4209-9641-c8f5951c1829"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("088a0f2d-64d7-4209-9641-c8f5951c1829"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("088a0f2d-64d7-4209-9641-c8f5951c1829"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b8d19f96-4c1d-409c-a492-35c3d826de5e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b8d19f96-4c1d-409c-a492-35c3d826de5e"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b8d19f96-4c1d-409c-a492-35c3d826de5e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b8d19f96-4c1d-409c-a492-35c3d826de5e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d707c44-ba6c-4443-9df0-a6045054bb27"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d707c44-ba6c-4443-9df0-a6045054bb27"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d707c44-ba6c-4443-9df0-a6045054bb27"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2ea26976-5676-4d39-9d82-7d4dcb1fd78e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("76ca08d3-1948-499b-a55a-cc80d35c270c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("31f487b4-306e-4f99-a725-aac443df8555"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("95d1de73-59e6-4799-9e10-f450cdc503f8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("56c6baa8-25a3-4ee2-9a3e-998cbe01593c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b6b2664d-e580-4006-b565-e38da1bfdc39"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b6b2664d-e580-4006-b565-e38da1bfdc39"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b6b2664d-e580-4006-b565-e38da1bfdc39"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b6b2664d-e580-4006-b565-e38da1bfdc39"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b6b2664d-e580-4006-b565-e38da1bfdc39"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("90a79af8-5806-41b2-9424-e4f0d66e58a3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("90a79af8-5806-41b2-9424-e4f0d66e58a3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("90a79af8-5806-41b2-9424-e4f0d66e58a3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("90a79af8-5806-41b2-9424-e4f0d66e58a3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4c3e8b28-2304-4e1c-bed9-52da6b6e6921"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4c3e8b28-2304-4e1c-bed9-52da6b6e6921"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4c3e8b28-2304-4e1c-bed9-52da6b6e6921"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c19fb81f-990d-4306-a2f0-f6c0f5f2fe84"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c19fb81f-990d-4306-a2f0-f6c0f5f2fe84"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c19fb81f-990d-4306-a2f0-f6c0f5f2fe84"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c19fb81f-990d-4306-a2f0-f6c0f5f2fe84"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("34c55eb8-97c6-47f0-9f4d-388e9be9a4b8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("34c55eb8-97c6-47f0-9f4d-388e9be9a4b8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("34c55eb8-97c6-47f0-9f4d-388e9be9a4b8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("34c55eb8-97c6-47f0-9f4d-388e9be9a4b8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("56c6baa8-25a3-4ee2-9a3e-998cbe01593c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("95d1de73-59e6-4799-9e10-f450cdc503f8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("56c6baa8-25a3-4ee2-9a3e-998cbe01593c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("56c6baa8-25a3-4ee2-9a3e-998cbe01593c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("95d1de73-59e6-4799-9e10-f450cdc503f8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("95d1de73-59e6-4799-9e10-f450cdc503f8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("95d1de73-59e6-4799-9e10-f450cdc503f8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0fa28613-c8e0-4786-aa98-9b6c57c8a759"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0fa28613-c8e0-4786-aa98-9b6c57c8a759"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0fa28613-c8e0-4786-aa98-9b6c57c8a759"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("cf43402d-02d6-4dd1-933e-987c15f108dd"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("cf43402d-02d6-4dd1-933e-987c15f108dd"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("cf43402d-02d6-4dd1-933e-987c15f108dd"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("cf43402d-02d6-4dd1-933e-987c15f108dd"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a495a080-ec1e-4dc4-902b-17f8ad45171d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a495a080-ec1e-4dc4-902b-17f8ad45171d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a495a080-ec1e-4dc4-902b-17f8ad45171d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a495a080-ec1e-4dc4-902b-17f8ad45171d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a495a080-ec1e-4dc4-902b-17f8ad45171d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1299f268-2e7e-4d69-9963-56f5a1255834"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1299f268-2e7e-4d69-9963-56f5a1255834"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1299f268-2e7e-4d69-9963-56f5a1255834"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1299f268-2e7e-4d69-9963-56f5a1255834"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1299f268-2e7e-4d69-9963-56f5a1255834"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("651ec06a-f339-4276-a212-e5bf9d0e6cd1"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("56c6baa8-25a3-4ee2-9a3e-998cbe01593c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("30c5e90c-ef4c-4ae8-ac62-7306fb26f787"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("30c5e90c-ef4c-4ae8-ac62-7306fb26f787"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("30c5e90c-ef4c-4ae8-ac62-7306fb26f787"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d2f4f3e0-3868-4ae3-bbce-9fd6e06453f0"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d2f4f3e0-3868-4ae3-bbce-9fd6e06453f0"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("89ea543f-5668-4428-b521-5f5b923e8099"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("89ea543f-5668-4428-b521-5f5b923e8099"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("89ea543f-5668-4428-b521-5f5b923e8099"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("89ea543f-5668-4428-b521-5f5b923e8099"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f96a2f0c-ac8f-4c6c-a5d3-2251d5a89961"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f96a2f0c-ac8f-4c6c-a5d3-2251d5a89961"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f96a2f0c-ac8f-4c6c-a5d3-2251d5a89961"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f96a2f0c-ac8f-4c6c-a5d3-2251d5a89961"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f96a2f0c-ac8f-4c6c-a5d3-2251d5a89961"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("373a2a4a-5964-48e1-8d9c-39efc1e47797"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("373a2a4a-5964-48e1-8d9c-39efc1e47797"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2a62f12c-fe51-4497-a769-c8a162b0052d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2a62f12c-fe51-4497-a769-c8a162b0052d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2a62f12c-fe51-4497-a769-c8a162b0052d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e7fc3b52-9811-42bb-9180-5f92b75b90a2"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e7fc3b52-9811-42bb-9180-5f92b75b90a2"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e7fc3b52-9811-42bb-9180-5f92b75b90a2"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c5180b08-675b-402d-99df-d78895fcb1d3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c5180b08-675b-402d-99df-d78895fcb1d3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d2f4f3e0-3868-4ae3-bbce-9fd6e06453f0"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c5180b08-675b-402d-99df-d78895fcb1d3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0f447b2-07ce-4025-867b-5baaef290bc1"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0f447b2-07ce-4025-867b-5baaef290bc1"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("277fd4d8-c3d9-489c-ac4f-1819a172f51e"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("277fd4d8-c3d9-489c-ac4f-1819a172f51e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("277fd4d8-c3d9-489c-ac4f-1819a172f51e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("289b0815-7915-437f-a465-e72f7fed1c5d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("289b0815-7915-437f-a465-e72f7fed1c5d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("289b0815-7915-437f-a465-e72f7fed1c5d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("289b0815-7915-437f-a465-e72f7fed1c5d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c061a95d-486d-42b7-9809-947664491d2e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c061a95d-486d-42b7-9809-947664491d2e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c061a95d-486d-42b7-9809-947664491d2e"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c061a95d-486d-42b7-9809-947664491d2e"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("08b24b4f-c5b3-4f88-89ce-16e377307b0a"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("08b24b4f-c5b3-4f88-89ce-16e377307b0a"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("08b24b4f-c5b3-4f88-89ce-16e377307b0a"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("08b24b4f-c5b3-4f88-89ce-16e377307b0a"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("70f179cb-63f4-44c2-b2f6-2f2f9da559de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("70f179cb-63f4-44c2-b2f6-2f2f9da559de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("70f179cb-63f4-44c2-b2f6-2f2f9da559de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("70f179cb-63f4-44c2-b2f6-2f2f9da559de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("70f179cb-63f4-44c2-b2f6-2f2f9da559de"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0f447b2-07ce-4025-867b-5baaef290bc1"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0f447b2-07ce-4025-867b-5baaef290bc1"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c5180b08-675b-402d-99df-d78895fcb1d3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c5180b08-675b-402d-99df-d78895fcb1d3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e78dd793-8f0b-4a04-8a93-8bbc070c15c5"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("60861ea1-709e-4bb7-9113-62c018fc5036"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("60861ea1-709e-4bb7-9113-62c018fc5036"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("60861ea1-709e-4bb7-9113-62c018fc5036"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("453c846e-3709-41c4-af22-cece1c99ed50"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("453c846e-3709-41c4-af22-cece1c99ed50"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("453c846e-3709-41c4-af22-cece1c99ed50"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("42ace2ea-a0d1-432f-b93a-c5ceff781e33"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("42ace2ea-a0d1-432f-b93a-c5ceff781e33"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b562aea4-22ec-4eca-8d90-ff42826b57dd"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b562aea4-22ec-4eca-8d90-ff42826b57dd"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b562aea4-22ec-4eca-8d90-ff42826b57dd"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b562aea4-22ec-4eca-8d90-ff42826b57dd"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("dbf71e8b-fc91-4197-83c7-e2d4aba39559"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("dbf71e8b-fc91-4197-83c7-e2d4aba39559"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("dbf71e8b-fc91-4197-83c7-e2d4aba39559"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("dbf71e8b-fc91-4197-83c7-e2d4aba39559"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5c2fe472-af86-4ff2-bdd8-90ee19e89457"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5c2fe472-af86-4ff2-bdd8-90ee19e89457"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5c2fe472-af86-4ff2-bdd8-90ee19e89457"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5c2fe472-af86-4ff2-bdd8-90ee19e89457"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("30c5e90c-ef4c-4ae8-ac62-7306fb26f787"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("60861ea1-709e-4bb7-9113-62c018fc5036"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("60861ea1-709e-4bb7-9113-62c018fc5036"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a93c9da0-c004-4a94-b693-c805c342135b"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a93c9da0-c004-4a94-b693-c805c342135b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e78dd793-8f0b-4a04-8a93-8bbc070c15c5"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e78dd793-8f0b-4a04-8a93-8bbc070c15c5"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e78dd793-8f0b-4a04-8a93-8bbc070c15c5"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e78dd793-8f0b-4a04-8a93-8bbc070c15c5"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e78dd793-8f0b-4a04-8a93-8bbc070c15c5"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("28c47902-d780-4cb5-9baf-91ff5aadff3b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("28c47902-d780-4cb5-9baf-91ff5aadff3b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("28c47902-d780-4cb5-9baf-91ff5aadff3b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("28c47902-d780-4cb5-9baf-91ff5aadff3b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("28c47902-d780-4cb5-9baf-91ff5aadff3b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("34c55eb8-97c6-47f0-9f4d-388e9be9a4b8"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8c3e4a62-b5c6-4963-b977-0af45e53d5f1"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8c3e4a62-b5c6-4963-b977-0af45e53d5f1"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8c3e4a62-b5c6-4963-b977-0af45e53d5f1"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8146c09f-bbae-4c6f-98a8-0b05ebb6f6d7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8146c09f-bbae-4c6f-98a8-0b05ebb6f6d7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8146c09f-bbae-4c6f-98a8-0b05ebb6f6d7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8146c09f-bbae-4c6f-98a8-0b05ebb6f6d7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4bb32d43-278e-4014-bbc1-af755d957aab"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4bb32d43-278e-4014-bbc1-af755d957aab"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4bb32d43-278e-4014-bbc1-af755d957aab"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4bb32d43-278e-4014-bbc1-af755d957aab"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8c3e4a62-b5c6-4963-b977-0af45e53d5f1"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("34c55eb8-97c6-47f0-9f4d-388e9be9a4b8"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
