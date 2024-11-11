using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class Project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhaCungCap_SanPham_SanPhamId",
                table: "NhaCungCap");

            migrationBuilder.DropIndex(
                name: "IX_NhaCungCap_SanPhamId",
                table: "NhaCungCap");

            migrationBuilder.DropColumn(
                name: "SanPhamId",
                table: "NhaCungCap");

            migrationBuilder.AddColumn<int>(
                name: "NhaCungCapId",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_NhaCungCapId",
                table: "SanPham",
                column: "NhaCungCapId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_NhaCungCap_NhaCungCapId",
                table: "SanPham",
                column: "NhaCungCapId",
                principalTable: "NhaCungCap",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_NhaCungCap_NhaCungCapId",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_NhaCungCapId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "NhaCungCapId",
                table: "SanPham");

            migrationBuilder.AddColumn<int>(
                name: "SanPhamId",
                table: "NhaCungCap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCap_SanPhamId",
                table: "NhaCungCap",
                column: "SanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhaCungCap_SanPham_SanPhamId",
                table: "NhaCungCap",
                column: "SanPhamId",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
