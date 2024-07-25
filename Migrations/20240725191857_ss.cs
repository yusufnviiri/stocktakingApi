using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace stocktakingApi.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    StockItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockAmount = table.Column<double>(type: "float", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.StockItemId);
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "StaffDescription", "StaffName", "StaffRole" },
                values: new object[,]
                {
                    { 1, "George is the CEO of the enterprise.His office is S001", "George Soros", "CEO" },
                    { 2, "Annet is the procurement manager.She has served the business for more than 8 solid years. Her Office is S009", "Dorcus Samatha", "Procurement Manager" },
                    { 3, "Yusuf serves as the technical director and business advisor. He has served  the business for more than 6 years", "Yusuf Nviiri", "Business Psychologist" },
                    { 4, "A competent Electrical Engineer, Martin is married to Suzan and a father of 3 beautiful girls", "Martin Sanders", "Maintainance manager" },
                    { 5, "Barbra specializes in Product Quality.She has served the company for more than 24 years ", "Barbra Walters", "Quality Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "StockItems",
                columns: new[] { "StockItemId", "Description", "Name", "StaffId", "StockAmount" },
                values: new object[,]
                {
                    { 1, "LaserJet Printers D426S with portable print head ", "LaserJet Printers", 1, 4.0 },
                    { 2, "Lenovo T430 model 2023 s/n= 2638JK23893MOS", "Lenovo laptop", 4, 87.0 },
                    { 3, "Dell D39 model 2022 s/n = P537X3672", "Dell Laptop ", 1, 27.0 },
                    { 4, "Kyocera Printers with mini paper cabins s/n Up673Jd", "Kyocera Printers", 1, 6.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "StockItems");
        }
    }
}
