using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ef5Domain.Migrations
{
    public partial class EmailInAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "account",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("3762db4a-8681-44d4-9ca6-bd9e0540d74f"),
                column: "Email",
                value: "pietra@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("3950a3b2-47ab-459e-bf44-f1c3065e0dfb"),
                column: "Email",
                value: "debora@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("52675719-09be-458e-8d0f-ae05d8629ec2"),
                column: "Email",
                value: "ayla@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("7ba1b661-db11-4058-8a3e-1494c7fb9891"),
                column: "Email",
                value: "kaique@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("8108185d-caf6-47b9-bd83-187a51f2c9c2"),
                column: "Email",
                value: "marcos@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("8cd6bcf9-53a7-49ac-aa0d-f230b0e05afe"),
                column: "Email",
                value: "gabrielly@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("b61d5d4d-c1f9-41c2-8323-2b11d9f64f52"),
                column: "Email",
                value: "benicio@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("c6da9a85-e385-455b-a217-aff60a26c122"),
                column: "Email",
                value: "thiago@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("d48e1805-c298-4059-9fc3-8c8326a52f3a"),
                column: "Email",
                value: "thomas@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("d6cd8238-873a-4b7a-a4b8-72c298b69e41"),
                column: "Email",
                value: "andre@godinho.com.br");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "Id",
                keyValue: new Guid("def31d5b-dcb0-46fa-89c7-aba0bcfdb55c"),
                column: "Email",
                value: "maite@godinho.com.br");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "account");
        }
    }
}
