using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlimentoMascotas.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aditivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aditivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Analitico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analitico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etapa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    EspecieId = table.Column<int>(type: "int", nullable: false),
                    EtapaId = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimento_Especie_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alimento_Etapa_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alimento_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AditivoEnAlimento",
                columns: table => new
                {
                    AditivoId = table.Column<int>(type: "int", nullable: false),
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    QuantityUI = table.Column<int>(type: "int", nullable: false),
                    QuantityGra = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AditivoEnAlimento", x => new { x.AditivoId, x.AlimentoId });
                    table.ForeignKey(
                        name: "FK_AditivoEnAlimento_Aditivo_AditivoId",
                        column: x => x.AditivoId,
                        principalTable: "Aditivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AditivoEnAlimento_Alimento_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnaliticoEnAlimento",
                columns: table => new
                {
                    AnaliticoId = table.Column<int>(type: "int", nullable: false),
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    QuantityPer = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    QuantityGra = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaliticoEnAlimento", x => new { x.AnaliticoId, x.AlimentoId });
                    table.ForeignKey(
                        name: "FK_AnaliticoEnAlimento_Alimento_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnaliticoEnAlimento_Analitico_AnaliticoId",
                        column: x => x.AnaliticoId,
                        principalTable: "Analitico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteEnAlimento",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(type: "int", nullable: false),
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    QuantityPer = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteEnAlimento", x => new { x.IngredienteId, x.AlimentoId });
                    table.ForeignKey(
                        name: "FK_IngredienteEnAlimento_Alimento_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteEnAlimento_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeEnAlimento",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    AlimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeEnAlimento", x => new { x.SizeId, x.AlimentoId });
                    table.ForeignKey(
                        name: "FK_SizeEnAlimento_Alimento_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SizeEnAlimento_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aditivo",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vitamina A" },
                    { 2, "Vitamina D3" },
                    { 3, "E1 (Hierro)" },
                    { 4, "E2 (Yodo)" },
                    { 5, "E4 (Cobre)" },
                    { 6, "E5 (Manganeso)" },
                    { 7, "E6 (Zinc)" },
                    { 8, "E8 (Selenio)" },
                    { 9, "Conservantes" },
                    { 10, "Antioxidantes" }
                });

            migrationBuilder.InsertData(
                table: "Analitico",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Energía" },
                    { 8, "Calcio" },
                    { 7, "Humedad" },
                    { 6, "EPA/DHA" },
                    { 9, "Fósforo" },
                    { 4, "Fibras" },
                    { 3, "Ceniza" },
                    { 2, "Grasa" },
                    { 1, "Proteina" },
                    { 5, "Ácidos grasos omega" }
                });

            migrationBuilder.InsertData(
                table: "Especie",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gato" },
                    { 2, "Perro" }
                });

            migrationBuilder.InsertData(
                table: "Etapa",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adulto" },
                    { 2, "Cachorro" },
                    { 3, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 16, null, "Grasas animales" },
                    { 17, null, "Proteina de cerdi deshidratada" },
                    { 18, null, "Hidrolizado de proteinas animales" },
                    { 19, null, "Pulpa de remolacha" },
                    { 20, null, "Gluten de maíz" },
                    { 25, "Fuente de glucosamina", "Hidrolizado de crustáceo" },
                    { 22, null, "Aceite de pescado" },
                    { 23, null, "Aceite de soja" },
                    { 24, null, "Levaduras" },
                    { 26, "Fuente de codroitina", "Hidrolizado de cartílago" },
                    { 15, null, "Harina de maíz" },
                    { 21, null, "Minerales" },
                    { 14, null, "Proteina de ave deshidratada" },
                    { 4, null, "Cerdo" },
                    { 12, null, "Subproducto de cerdo" },
                    { 11, null, "Subproducto de salmón" },
                    { 10, null, "Subproducto de pollo" }
                });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 9, null, "Subproducto de res" },
                    { 8, null, "Harina de cerdo" },
                    { 7, null, "Harina de salmón" },
                    { 6, null, "Harina de pollo" },
                    { 5, null, "Harina de res" },
                    { 13, null, "Maíz" },
                    { 3, null, "Salmón" },
                    { 2, null, "Pollo" },
                    { 1, null, "Res" }
                });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Raza" });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { 3, 8m },
                    { 4, 15m },
                    { 1, 1.5m },
                    { 2, 3m },
                    { 5, 21m }
                });

            migrationBuilder.InsertData(
                table: "Alimento",
                columns: new[] { "Id", "EspecieId", "EtapaId", "LastUpdate", "MarcaId", "Name" },
                values: new object[] { 1, 2, 1, new DateTime(2022, 3, 8, 15, 18, 40, 153, DateTimeKind.Utc).AddTicks(116), 1, "Alimento Raza para perros adultos sabor Pollo, Carne, Cereales y Arroz" });

            migrationBuilder.CreateIndex(
                name: "IX_AditivoEnAlimento_AlimentoId",
                table: "AditivoEnAlimento",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_EspecieId",
                table: "Alimento",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_EtapaId",
                table: "Alimento",
                column: "EtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_MarcaId",
                table: "Alimento",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnaliticoEnAlimento_AlimentoId",
                table: "AnaliticoEnAlimento",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteEnAlimento_AlimentoId",
                table: "IngredienteEnAlimento",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeEnAlimento_AlimentoId",
                table: "SizeEnAlimento",
                column: "AlimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AditivoEnAlimento");

            migrationBuilder.DropTable(
                name: "AnaliticoEnAlimento");

            migrationBuilder.DropTable(
                name: "IngredienteEnAlimento");

            migrationBuilder.DropTable(
                name: "SizeEnAlimento");

            migrationBuilder.DropTable(
                name: "Aditivo");

            migrationBuilder.DropTable(
                name: "Analitico");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
