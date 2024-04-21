using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Infrastructure.Migrations
{
    public partial class profileupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("131e8b31-59a7-4c80-9b71-08b60e951e5c"),
                column: "ConcurrencyStamp",
                value: "87c51114f8b543089540c8fd8acb6865");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7"),
                column: "ConcurrencyStamp",
                value: "84ffe2c44efe460aa07beae4a88a677b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4369778-9dda-41b1-b0a2-ba96984f7fe3", "AQAAAAEAACcQAAAAEAk7JQR0C8+W5fOpYmRG96NO/ahvVaXcR8gXlIzRp/mfiJJN5xqGVLpPNgcLvwf5ug==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d58c75-18bc-4868-b54d-0a1fdf8fe94d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03eab80a-929c-41cd-95e5-3f5f073fda9c", "AQAAAAEAACcQAAAAEO7+74rswDfFK9OzjAMBFkqQ3arJCj/fcmh+8ia13d6zD/LVFwDrzS33Hk4H0CnWcQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("131e8b31-59a7-4c80-9b71-08b60e951e5c"),
                column: "ConcurrencyStamp",
                value: "a551ba5443d24fccb1bca53b63d7ca4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7"),
                column: "ConcurrencyStamp",
                value: "304cd6d9378b4cfbbbe4b52d89dfc7be");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba8271c4-3db7-4161-bf2d-50dcde6fb7ec", "AQAAAAEAACcQAAAAELIazT5OD8QBJzWXvCgmPV/lPyKWyxNV3wPmyH97smGCcdYgsFWUf/XN7Fr0t4DXRg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d58c75-18bc-4868-b54d-0a1fdf8fe94d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "15cac0ad-5cb8-43b9-9a66-c5ba03d5acee", "AQAAAAEAACcQAAAAENOItd0mZ0WuwE8Q0MDo2ExWE9T8YmXeWxVmKrIfxXviOBDdGWx81mvN3XXZKT1P1g==" });
        }
    }
}
