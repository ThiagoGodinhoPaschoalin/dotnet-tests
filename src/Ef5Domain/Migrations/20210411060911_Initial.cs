using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ef5Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_Id", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_Account_Document", x => x.Document);
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile_Id", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "account_profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProfile_Id", x => x.Id);
                    table.UniqueConstraint("AK_AccountProfile_AccountIdProfileId", x => new { x.AccountId, x.ProfileId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_account_profile_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_account_profile_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "Id", "Document", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { new Guid("def31d5b-dcb0-46fa-89c7-aba0bcfdb55c"), "491.265.159-11", "Maitê", (byte)1, "Baptista" },
                    { new Guid("3950a3b2-47ab-459e-bf44-f1c3065e0dfb"), "086.198.466-80", "Débora", (byte)1, "Clarice" },
                    { new Guid("52675719-09be-458e-8d0f-ae05d8629ec2"), "378.952.762-98", "Ayla", (byte)1, "Ribeiro" },
                    { new Guid("3762db4a-8681-44d4-9ca6-bd9e0540d74f"), "139.582.121-66", "Pietra", (byte)1, "Conceição" },
                    { new Guid("8cd6bcf9-53a7-49ac-aa0d-f230b0e05afe"), "408.435.312-40", "Gabrielly", (byte)1, "Viana" },
                    { new Guid("c6da9a85-e385-455b-a217-aff60a26c122"), "876.283.990-02", "Thiago", (byte)0, "Godinho" },
                    { new Guid("8108185d-caf6-47b9-bd83-187a51f2c9c2"), "166.169.248-66", "Marcos", (byte)0, "Sebastião" },
                    { new Guid("d6cd8238-873a-4b7a-a4b8-72c298b69e41"), "654.928.314-02", "André", (byte)0, "Cunha" },
                    { new Guid("d48e1805-c298-4059-9fc3-8c8326a52f3a"), "732.599.674-86", "Thomas", (byte)0, "Rodrigues" },
                    { new Guid("7ba1b661-db11-4058-8a3e-1494c7fb9891"), "084.356.860-78", "Kaique", (byte)0, "Almada" },
                    { new Guid("b61d5d4d-c1f9-41c2-8323-2b11d9f64f52"), "529.480.900-16", "Benício", (byte)0, "Paschoalin" }
                });

            migrationBuilder.InsertData(
                table: "profile",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10fae454-f200-41ce-b18f-112977ac18c1"), "Aluno" },
                    { new Guid("957f86a0-fb9a-4c2f-9f25-945ef4538ce5"), "Professor" },
                    { new Guid("f732b923-4be5-4a05-876f-aa7cbf38bfa6"), "Gestor" }
                });

            migrationBuilder.InsertData(
                table: "account_profile",
                columns: new[] { "Id", "AccountId", "ProfileId" },
                values: new object[,]
                {
                    { new Guid("d1c0db63-fed6-431e-a6c0-3c2d5e853e30"), new Guid("8108185d-caf6-47b9-bd83-187a51f2c9c2"), new Guid("10fae454-f200-41ce-b18f-112977ac18c1") },
                    { new Guid("4b64c960-cfeb-4268-be7c-d9fa1f98347b"), new Guid("d6cd8238-873a-4b7a-a4b8-72c298b69e41"), new Guid("10fae454-f200-41ce-b18f-112977ac18c1") },
                    { new Guid("d1832a87-4786-4684-8b62-4d785e0cf566"), new Guid("d48e1805-c298-4059-9fc3-8c8326a52f3a"), new Guid("10fae454-f200-41ce-b18f-112977ac18c1") },
                    { new Guid("b78fd645-eef1-4d8d-9066-44438f23766c"), new Guid("7ba1b661-db11-4058-8a3e-1494c7fb9891"), new Guid("10fae454-f200-41ce-b18f-112977ac18c1") },
                    { new Guid("db3a7515-ef0a-42c3-8306-26b22dcb752d"), new Guid("def31d5b-dcb0-46fa-89c7-aba0bcfdb55c"), new Guid("957f86a0-fb9a-4c2f-9f25-945ef4538ce5") },
                    { new Guid("92817be0-e69f-4ec2-9a9a-9236ac7fa257"), new Guid("3950a3b2-47ab-459e-bf44-f1c3065e0dfb"), new Guid("957f86a0-fb9a-4c2f-9f25-945ef4538ce5") },
                    { new Guid("ebd4b227-d0c3-4b9b-bc61-2299284d0752"), new Guid("52675719-09be-458e-8d0f-ae05d8629ec2"), new Guid("957f86a0-fb9a-4c2f-9f25-945ef4538ce5") },
                    { new Guid("879ec6cb-80cd-4525-80ec-1fc86ed24a99"), new Guid("3762db4a-8681-44d4-9ca6-bd9e0540d74f"), new Guid("957f86a0-fb9a-4c2f-9f25-945ef4538ce5") },
                    { new Guid("d723a151-f605-4097-b25a-2b892170d453"), new Guid("8cd6bcf9-53a7-49ac-aa0d-f230b0e05afe"), new Guid("957f86a0-fb9a-4c2f-9f25-945ef4538ce5") },
                    { new Guid("78213aef-d461-4837-9248-af2d03267e15"), new Guid("c6da9a85-e385-455b-a217-aff60a26c122"), new Guid("f732b923-4be5-4a05-876f-aa7cbf38bfa6") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_profile_ProfileId",
                table: "account_profile",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_profile");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "profile");
        }
    }
}
