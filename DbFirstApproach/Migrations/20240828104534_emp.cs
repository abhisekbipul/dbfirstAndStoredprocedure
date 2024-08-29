using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbFirstApproach.Migrations
{
    /// <inheritdoc />
    public partial class emp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emps", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Mycart",
            //    columns: table => new
            //    {
            //        Pid = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Pname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Pcat = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Price = table.Column<double>(type: "float", nullable: false),
            //        Suser = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Mycart", x => x.Pid);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "myproducts",
            //    columns: table => new
            //    {
            //        Pid = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Pname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Pcat = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Price = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_myproducts", x => x.Pid);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "user",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_user", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emps");

            //migrationBuilder.DropTable(
            //    name: "Mycart");

            //migrationBuilder.DropTable(
            //    name: "myproducts");

            //migrationBuilder.DropTable(
            //    name: "user");
        }
    }
}
