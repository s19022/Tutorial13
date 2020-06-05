﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorial_13.Migrations
{
    public partial class AddOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAccepted = table.Column<DateTime>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    IdClient = table.Column<int>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: true),
                    IdEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdCustomer",
                table: "Order",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmployee",
                table: "Order",
                column: "IdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
