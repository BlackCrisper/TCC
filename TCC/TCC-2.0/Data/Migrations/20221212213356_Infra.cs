using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_2._0.Data.Migrations
{
    public partial class Infra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    CATID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATDESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.CATID);
                });

            migrationBuilder.CreateTable(
                name: "ENTRADA",
                columns: table => new
                {
                    ENTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTDATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTORIGEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENTOBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTRADA", x => x.ENTID);
                });

            migrationBuilder.CreateTable(
                name: "SAIDA",
                columns: table => new
                {
                    SAIID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAIDATA = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAIDA", x => x.SAIID);
                });

            migrationBuilder.CreateTable(
                name: "TIPO",
                columns: table => new
                {
                    TIPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPNOME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO", x => x.TIPID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    PROID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATID = table.Column<int>(type: "int", nullable: false),
                    PRODESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PROIMAGEM = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.PROID);
                    table.ForeignKey(
                        name: "FK_PRODUTO_CATEGORIA_CATID",
                        column: x => x.CATID,
                        principalTable: "CATEGORIA",
                        principalColumn: "CATID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROTIPO",
                columns: table => new
                {
                    PTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROID = table.Column<int>(type: "int", nullable: false),
                    TIPID = table.Column<int>(type: "int", nullable: true),
                    PTMINIMO = table.Column<int>(type: "int", nullable: false),
                    PTMAXIMO = table.Column<int>(type: "int", nullable: false),
                    PTESTOQUE = table.Column<int>(type: "int", nullable: false),
                    PTIMAGEM = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROTIPO", x => x.PTID);
                    table.ForeignKey(
                        name: "FK_PROTIPO_PRODUTO_PROID",
                        column: x => x.PROID,
                        principalTable: "PRODUTO",
                        principalColumn: "PROID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROTIPO_TIPO_TIPID",
                        column: x => x.TIPID,
                        principalTable: "TIPO",
                        principalColumn: "TIPID");
                });

            migrationBuilder.CreateTable(
                name: "ITENSENTRADA",
                columns: table => new
                {
                    ITEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTID = table.Column<int>(type: "int", nullable: false),
                    PTID = table.Column<int>(type: "int", nullable: false),
                    ITEQUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    ITEPRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITENSENTRADA", x => x.ITEID);
                    table.ForeignKey(
                        name: "FK_ITENSENTRADA_ENTRADA_ENTID",
                        column: x => x.ENTID,
                        principalTable: "ENTRADA",
                        principalColumn: "ENTID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENSENTRADA_PROTIPO_PTID",
                        column: x => x.PTID,
                        principalTable: "PROTIPO",
                        principalColumn: "PTID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITENSSAIDA",
                columns: table => new
                {
                    ITSID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAIID = table.Column<int>(type: "int", nullable: false),
                    PTID = table.Column<int>(type: "int", nullable: false),
                    ITSQUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    ITSPRECO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITENSSAIDA", x => x.ITSID);
                    table.ForeignKey(
                        name: "FK_ITENSSAIDA_PROTIPO_PTID",
                        column: x => x.PTID,
                        principalTable: "PROTIPO",
                        principalColumn: "PTID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENSSAIDA_SAIDA_SAIID",
                        column: x => x.SAIID,
                        principalTable: "SAIDA",
                        principalColumn: "SAIID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITENSENTRADA_ENTID",
                table: "ITENSENTRADA",
                column: "ENTID");

            migrationBuilder.CreateIndex(
                name: "IX_ITENSENTRADA_PTID",
                table: "ITENSENTRADA",
                column: "PTID");

            migrationBuilder.CreateIndex(
                name: "IX_ITENSSAIDA_PTID",
                table: "ITENSSAIDA",
                column: "PTID");

            migrationBuilder.CreateIndex(
                name: "IX_ITENSSAIDA_SAIID",
                table: "ITENSSAIDA",
                column: "SAIID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_CATID",
                table: "PRODUTO",
                column: "CATID");

            migrationBuilder.CreateIndex(
                name: "IX_PROTIPO_PROID",
                table: "PROTIPO",
                column: "PROID");

            migrationBuilder.CreateIndex(
                name: "IX_PROTIPO_TIPID",
                table: "PROTIPO",
                column: "TIPID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITENSENTRADA");

            migrationBuilder.DropTable(
                name: "ITENSSAIDA");

            migrationBuilder.DropTable(
                name: "ENTRADA");

            migrationBuilder.DropTable(
                name: "PROTIPO");

            migrationBuilder.DropTable(
                name: "SAIDA");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "TIPO");

            migrationBuilder.DropTable(
                name: "CATEGORIA");
        }
    }
}
