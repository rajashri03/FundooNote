using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositaryLayer.Migrations
{
    public partial class fundooproj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    LabelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(nullable: true),
                    Userid = table.Column<long>(nullable: false),
                    Noteid = table.Column<long>(nullable: false),
                    notesNoteID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_Labels_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Labels_Notes_notesNoteID",
                        column: x => x.notesNoteID,
                        principalTable: "Notes",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_Userid",
                table: "Labels",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_notesNoteID",
                table: "Labels",
                column: "notesNoteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Labels");
        }
    }
}
