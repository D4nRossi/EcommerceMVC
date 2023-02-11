using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceMVC.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId, DescricaoCurta, DescricaoDetalhada,EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsProdutoPreferido, Nome, Preco) VALUES(1, 'Manual de Epicteto', 'Livro escrito por um dos pais do estoicismo, mostrando seus aspectos', 1, 'https://m.media-amazon.com/images/I/41vnLEUgHKL.jpg', 'https://m.media-amazon.com/images/I/41vnLEUgHKL.jpg', 1, 'Manual de Estoicismo', 50.30)");

            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId, DescricaoCurta, DescricaoDetalhada,EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsProdutoPreferido, Nome, Preco) VALUES(1, 'Meditações de Marco Aurelio', 'Livro escrito por um dos principais estoicos, mostrando um pouco de seus pensamentos', 1, 'https://m.media-amazon.com/images/I/41SnQ3axbOS.jpg', 'https://m.media-amazon.com/images/I/41SnQ3axbOS.jpg', 0, 'Meditações de Marco Aurelio', 55.90)");

            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId, DescricaoCurta, DescricaoDetalhada,EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsProdutoPreferido, Nome, Preco) VALUES(1, 'Diário Estoico', 'Algumas lições estoicas para você aplicar em sua vida mundana', 1, 'https://m.media-amazon.com/images/I/4167lJqrRXL.jpg', 'https://m.media-amazon.com/images/I/4167lJqrRXL.jpg', 0, 'Diário Estoico', 20.00)");

            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId, DescricaoCurta, DescricaoDetalhada,EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsProdutoPreferido, Nome, Preco) VALUES(1, 'Sobre a Brevidade da Vida', 'Livro escrito por um dos principais filosofos estoicos, mostrando um pouco de seus pensamentos', 1, 'https://m.media-amazon.com/images/I/41gvrsY+AEL.jpg', 'https://m.media-amazon.com/images/I/41gvrsY+AEL.jpg', 0, 'Sobre a brevidade da vida', 30.50)");

            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId, DescricaoCurta, DescricaoDetalhada,EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsProdutoPreferido, Nome, Preco) VALUES(1, 'Berserk', 'Melhor Seinen de todos os tempos, apenas', 1, 'https://m.media-amazon.com/images/I/5191HKIfUPL.jpg', 'https://m.media-amazon.com/images/I/5191HKIfUPL.jpg', 1, 'Berserk', 25.90)");

            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId, DescricaoCurta, DescricaoDetalhada,EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsProdutoPreferido, Nome, Preco) VALUES(3, 'Pré-treino', 'Pra tomar um scoop e subir as paredes da acdemia', 1, 'https://www.jacaresuplementos.com/media/product/1bd/jack-3d-advanced-usplabs-45-doses-usplabs-3be.jpg', 'https://www.jacaresuplementos.com/media/product/1bd/jack-3d-advanced-usplabs-45-doses-usplabs-3be.jpg', 1, 'Jack3D', 190.00)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
