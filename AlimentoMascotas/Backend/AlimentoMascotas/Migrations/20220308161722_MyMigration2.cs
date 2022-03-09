using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlimentoMascotas.Migrations
{
    public partial class MyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QuantityGra",
                table: "AnaliticoEnAlimento",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.UpdateData(
                table: "Alimento",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdate",
                value: new DateTime(2022, 3, 8, 16, 17, 21, 785, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.InsertData(
                table: "AnaliticoEnAlimento",
                columns: new[] { "AlimentoId", "AnaliticoId", "QuantityGra", "QuantityPer" },
                values: new object[,]
                {
                    { 1, 1, 0m, 21m },
                    { 1, 2, 0m, 9m },
                    { 1, 4, 0m, 3.5m },
                    { 1, 3, 0m, 10m },
                    { 1, 7, 0m, 12m },
                    { 1, 8, 0m, 2m },
                    { 1, 9, 0m, 1.3m },
                    { 1, 10, 3200m, 0m }
                });

            migrationBuilder.InsertData(
                table: "SizeEnAlimento",
                columns: new[] { "AlimentoId", "SizeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnaliticoEnAlimento",
                keyColumns: new[] { "AlimentoId", "AnaliticoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AnaliticoEnAlimento",
                keyColumns: new[] { "AlimentoId", "AnaliticoId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AnaliticoEnAlimento",
                keyColumns: new[] { "AlimentoId", "AnaliticoId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AnaliticoEnAlimento",
                keyColumns: new[] { "AlimentoId", "AnaliticoId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AnaliticoEnAlimento",
                keyColumns: new[] { "AlimentoId", "AnaliticoId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "AnaliticoEnAlimento",
                keyColumns: new[] { "AlimentoId", "AnaliticoId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "AnaliticoEnAlimento",
                keyColumns: new[] { "AlimentoId", "AnaliticoId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "AnaliticoEnAlimento",
                keyColumns: new[] { "AlimentoId", "AnaliticoId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "SizeEnAlimento",
                keyColumns: new[] { "AlimentoId", "SizeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SizeEnAlimento",
                keyColumns: new[] { "AlimentoId", "SizeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SizeEnAlimento",
                keyColumns: new[] { "AlimentoId", "SizeId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "SizeEnAlimento",
                keyColumns: new[] { "AlimentoId", "SizeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "SizeEnAlimento",
                keyColumns: new[] { "AlimentoId", "SizeId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.AlterColumn<decimal>(
                name: "QuantityGra",
                table: "AnaliticoEnAlimento",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.UpdateData(
                table: "Alimento",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdate",
                value: new DateTime(2022, 3, 8, 15, 18, 40, 153, DateTimeKind.Utc).AddTicks(116));
        }
    }
}
