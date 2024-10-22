using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AddressBook.data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    LocationLat = table.Column<double>(type: "REAL", nullable: false),
                    LocationLon = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressBooks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AddressBooks",
                columns: new[] { "Id", "Address", "FirstName", "ImageName", "LastName", "LocationLat", "LocationLon", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Ploiesti", "Adrian", "1.jpg", "Cretu", 44.940087766853466, 26.024721381603694, "0770390979" },
                    { 2, "București", "Maria", "2.jpg", "Ionescu", 44.426767400000003, 26.1025384, "0741234567" },
                    { 3, "Cluj-Napoca", "Ion", "3.jpg", "Popescu", 46.771210099999998, 23.6236353, "0732233444" },
                    { 4, "Iași", "Elena", "4.jpg", "Vasilescu", 47.156944000000003, 27.590278000000001, "0722233444" },
                    { 5, "Timișoara", "Mihai", "5.jpg", "Georgescu", 45.748871600000001, 21.2086793, "0711234567" },
                    { 6, "Brașov", "Ana", "6.jpg", "Radu", 45.657974600000003, 25.601198199999999, "0765234567" },
                    { 7, "Constanța", "Cristian", "7.jpg", "Marin", 44.159799999999997, 28.634799999999998, "0701234567" },
                    { 8, "Craiova", "Diana", "8.jpg", "Tudor", 44.330199999999998, 23.794899999999998, "0751234567" },
                    { 9, "Galați", "Victor", "9.jpg", "Grigore", 45.435299999999998, 28.0077, "0781234567" },
                    { 10, "Oradea", "Monica", "10.jpg", "Dumitrescu", 47.046500000000002, 21.918900000000001, "0791234567" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressBooks");
        }
    }
}
