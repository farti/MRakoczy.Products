using Microsoft.EntityFrameworkCore.Migrations;

namespace MRakoczy.Application.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Price) VALUES ('Tomato', 1.00)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Price) VALUES ('Beetroot', 2.00)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Price) VALUES ('Garlic', 2.40)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Price) VALUES ('Fungi', 3.11)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Price) VALUES ('Pumpkin', 1.20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
