using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothingCollectionAPI.Migrations
{
    public partial class ModelosAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "Id", "IdColecao", "Layout", "NomeModelo", "Tipo" },
                values: new object[,]
                {
                    { 1, 1, "Liso", "Vestido Transpassado", "Vestido" },
                    { 2, 2, "Estampa", "Conjunto Rio'n", "Biquini" },
                    { 3, 3, "Liso", "Pantalona", "Calça" },
                    { 4, 4, "Liso", "Coturno", "Calçados" },
                    { 5, 5, "Bordado", "Vestido delicate", "Vestido" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
