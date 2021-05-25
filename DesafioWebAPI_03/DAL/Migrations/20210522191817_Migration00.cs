using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioWebAPI_03.DAL.Migrations
{
    public partial class Migration00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    IdResponsavel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.IdResponsavel);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    IdVideo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    URL = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    IdadeMin = table.Column<int>(type: "int", nullable: false),
                    IdResponsavel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.IdVideo);
                    table.ForeignKey(
                        name: "FK_Videos_Responsaveis_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Responsaveis",
                        principalColumn: "IdResponsavel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoCategorias",
                columns: table => new
                {
                    IdVideoCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVideo = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategorias", x => x.IdVideoCategoria);
                    table.ForeignKey(
                        name: "FK_VideoCategorias_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoCategorias_Videos_IdVideo",
                        column: x => x.IdVideo,
                        principalTable: "Videos",
                        principalColumn: "IdVideo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategorias_IdCategoria",
                table: "VideoCategorias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategorias_IdVideo",
                table: "VideoCategorias",
                column: "IdVideo");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_IdResponsavel",
                table: "Videos",
                column: "IdResponsavel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoCategorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Responsaveis");
        }
    }
}
