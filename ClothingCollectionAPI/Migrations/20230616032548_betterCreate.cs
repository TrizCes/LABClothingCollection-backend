using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothingCollectionAPI.Migrations
{
    public partial class betterCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StatusUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                    Estacao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EstadoSistema = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colecoes_Usuarios_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CpfOuCnpj", "DataNascimento", "Email", "Genero", "NomeCompleto", "StatusUsuario", "Telefone", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "123.456.789-00", new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@mail.com", "Feminino", "Maria Clara Soares", "Ativo", "(47) 98895-7456", "Gerente" },
                    { 2, "987.654.321-00", new DateTime(1988, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao@mail.com", "Masculino", "João da Silva", "Ativo", "(47) 97777-1234", "Criador" },
                    { 3, "111.222.333-44", new DateTime(1990, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana@mail.com", "Feminino", "Ana Oliveira", "Ativo", "(47) 94444-5678", "Administrador" },
                    { 4, "555.666.777-88", new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro@mail.com", "Masculino", "Pedro Santos", "Inativo", "(47) 93333-9876", "Outro" },
                    { 5, "999.888.777-66", new DateTime(1985, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "carolina@mail.com", "Feminino", "Carolina Fernandes", "Ativo", "(47) 91111-2222", "Outro" }
                });

            migrationBuilder.InsertData(
                table: "Colecoes",
                columns: new[] { "Id", "AnoLancamento", "Estacao", "EstadoSistema", "IdResponsavel", "Marca", "NomeColecao", "Orcamento" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inverno", "Ativa", 1, "Brasília Fashion", "Floresta Urbana", 2000.0 },
                    { 2, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verão", "Ativa", 2, "Rio Style", "Tropical Vibes", 1500.0 },
                    { 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primavera", "Ativa", 3, "São Paulo Couture", "Retro Chic", 3000.0 },
                    { 4, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outono", "Ativa", 4, "Gothic Glam", "Dark Elegance", 2500.0 },
                    { 5, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verão", "Ativa", 5, "Bahia Bohemia", "Boho Dreams", 1800.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_IdResponsavel",
                table: "Colecoes",
                column: "IdResponsavel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colecoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
