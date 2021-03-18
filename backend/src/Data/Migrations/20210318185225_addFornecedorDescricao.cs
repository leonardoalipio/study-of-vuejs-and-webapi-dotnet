using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addFornecedorDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Fornecedores");
        }
    }
}
