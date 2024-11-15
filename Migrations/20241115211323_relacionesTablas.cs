using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerMotos.Migrations
{
    /// <inheritdoc />
    public partial class relacionesTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "ServiceOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MotorcycleId",
                table: "Repairs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceOrderId",
                table: "Repairs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId1",
                table: "Motorcycles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Buys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId1",
                table: "Buys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Buys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceOrderId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BillProduct",
                columns: table => new
                {
                    BillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillProduct", x => new { x.BillsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_BillProduct_Bills_BillsId",
                        column: x => x.BillsId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrderServiceType",
                columns: table => new
                {
                    ServiceOrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrderServiceType", x => new { x.ServiceOrdersId, x.ServiceTypesId });
                    table.ForeignKey(
                        name: "FK_ServiceOrderServiceType_ServiceOrders_ServiceOrdersId",
                        column: x => x.ServiceOrdersId,
                        principalTable: "ServiceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrderServiceType_ServiceTypes_ServiceTypesId",
                        column: x => x.ServiceTypesId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_EmployeeId",
                table: "ServiceOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_MotorcycleId",
                table: "Repairs",
                column: "MotorcycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ServiceOrderId",
                table: "Repairs",
                column: "ServiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_ClientId1",
                table: "Motorcycles",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buys_ClientId1",
                table: "Buys",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_ProductId",
                table: "Buys",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ServiceOrderId",
                table: "Bills",
                column: "ServiceOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillProduct_ProductsId",
                table: "BillProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderServiceType_ServiceTypesId",
                table: "ServiceOrderServiceType",
                column: "ServiceTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_ServiceOrders_ServiceOrderId",
                table: "Bills",
                column: "ServiceOrderId",
                principalTable: "ServiceOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Clients_ClientId1",
                table: "Buys",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Products_ProductId",
                table: "Buys",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Clients_ClientId1",
                table: "Motorcycles",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Motorcycles_MotorcycleId",
                table: "Repairs",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_ServiceOrders_ServiceOrderId",
                table: "Repairs",
                column: "ServiceOrderId",
                principalTable: "ServiceOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Employees_EmployeeId",
                table: "ServiceOrders",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_ServiceOrders_ServiceOrderId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Clients_ClientId1",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Products_ProductId",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Clients_ClientId1",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Motorcycles_MotorcycleId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_ServiceOrders_ServiceOrderId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Employees_EmployeeId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "BillProduct");

            migrationBuilder.DropTable(
                name: "ServiceOrderServiceType");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_EmployeeId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_MotorcycleId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_ServiceOrderId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_ClientId1",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Buys_ClientId1",
                table: "Buys");

            migrationBuilder.DropIndex(
                name: "IX_Buys_ProductId",
                table: "Buys");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ServiceOrderId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "MotorcycleId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "ServiceOrderId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "ServiceOrderId",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId1",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId1",
                table: "Users",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeId1",
                table: "Users",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
