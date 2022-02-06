using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositaryLayer.Migrations
{
    public partial class collab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    CollabId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollabEmail = table.Column<string>(nullable: true),
                    Userid = table.Column<long>(nullable: false),
                    Noteid = table.Column<long>(nullable: false),
                    notesNoteID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.CollabId);
                    table.ForeignKey(
                        name: "FK_Collaborator_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborator_Notes_notesNoteID",
                        column: x => x.notesNoteID,
                        principalTable: "Notes",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_Userid",
                table: "Collaborator",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_notesNoteID",
                table: "Collaborator",
                column: "notesNoteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborator");
        }
    }
}
