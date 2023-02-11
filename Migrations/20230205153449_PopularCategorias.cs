using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceMVC.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) VALUES('Estoicos', 'Tomos de conhecimento estoico')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) VALUES('Mangás', 'Quadrinhos da cultura oriental')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) VALUES('Suplementos', 'Pra meter o shape')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
