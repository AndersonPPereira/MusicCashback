using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicCashback.Infra.Data.Migrations
{
    public partial class AdicionadoColunaCashbackTabelaVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cashback",
                table: "ItemVenda",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cashback",
                table: "ItemVenda");
        }
    }
}
