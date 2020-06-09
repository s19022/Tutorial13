using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorial_13.Migrations
{
    public partial class AddConfectionery_OrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectionery_Order",
                columns: table => new
                {
                    IdConfectionary = table.Column<int>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_Order", x => new { x.IdConfectionary, x.IdOrder });
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Confectionery_IdConfectionary",
                        column: x => x.IdConfectionary,
                        principalTable: "Confectionery",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdOrder",
                table: "Confectionery_Order",
                column: "IdOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_Order");
        }
    }
}
