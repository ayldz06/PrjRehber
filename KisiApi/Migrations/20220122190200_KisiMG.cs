using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KisiApi.Migrations
{
    public partial class KisiMG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    uuid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    soyad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    firma = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "KisiBilgileri",
                columns: table => new
                {
                    iletisimid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    telefonno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    konum = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    bilgiicerigi = table.Column<string>(type: "text", nullable: true),
                    uuid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiBilgileri", x => x.iletisimid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kisi");

            migrationBuilder.DropTable(
                name: "KisiBilgileri");
        }
    }
}
