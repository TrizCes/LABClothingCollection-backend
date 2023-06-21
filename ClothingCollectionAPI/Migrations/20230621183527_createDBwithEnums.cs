using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothingCollectionAPI.Migrations
{
    public partial class createDBwithEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colecoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeColecao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdResponsavel = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Orcamento = table.Column<double>(type: "float", nullable: false),
                    AnoLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estacao = table.Column<int>(type: "int", nullable: false),
                    EstadoSistema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    StatusUsuario = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CpfOuCnpj = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeModelo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdColecao = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Colecoes_IdColecao",
                        column: x => x.IdColecao,
                        principalTable: "Colecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colecoes",
                columns: new[] { "Id", "AnoLancamento", "Estacao", "EstadoSistema", "IdResponsavel", "Marca", "NomeColecao", "Orcamento" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 1, "Brasília Fashion", "Floresta Urbana", 2000.0 },
                    { 2, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, 2, "Rio Style", "Tropical Vibes", 1500.0 },
                    { 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, "São Paulo Couture", "Retro Chic", 3000.0 },
                    { 4, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 4, "Gothic Glam", "Dark Elegance", 2500.0 },
                    { 5, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 5, "Bahia Bohemia", "Boho Dreams", 1800.0 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CpfOuCnpj", "DataNascimento", "Email", "Genero", "NomeCompleto", "StatusUsuario", "Telefone", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "123.456.789-00", new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@mail.com", "Feminino", "Maria Clara Soares", 0, "(47) 98895-7456", 1 },
                    { 2, "987.654.321-00", new DateTime(1988, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao@mail.com", "Masculino", "João da Silva", 0, "(47) 97777-1234", 2 },
                    { 3, "111.222.333-44", new DateTime(1990, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana@mail.com", "Feminino", "Ana Oliveira", 0, "(47) 94444-5678", 3 },
                    { 4, "555.666.777-88", new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro@mail.com", "Masculino", "Pedro Santos", 1, "(47) 93333-9876", 0 },
                    { 5, "999.888.777-66", new DateTime(1985, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "carolina@mail.com", "Feminino", "Carolina Fernandes", 0, "(47) 91111-2222", 0 }
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id", "IdColecao", "Layout", "NomeModelo", "Tipo" },
                values: new object[,]
                {
                    { 1, 1, 2, "Saia Transpassada", 8 },
                    { 2, 2, 0, "Conjunto Rio'n", 1 },
                    { 3, 3, 2, "Pantalona", 4 },
                    { 4, 4, 2, "Coturno", 5 },
                    { 5, 5, 1, "Delicate", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdColecao",
                table: "Modelos",
                column: "IdColecao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Colecoes");
        }
    }
}
