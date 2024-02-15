using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week5CaseStudy.Migrations
{
    public partial class AddManualMappingTable_ManyToMany_Hashtag_Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashtagPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hashtag",
                table: "Hashtag");

            migrationBuilder.RenameTable(
                name: "Hashtag",
                newName: "Hashtags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hashtags",
                table: "Hashtags",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HashtagPostMap",
                columns: table => new
                {
                    Hashtag_Id = table.Column<int>(type: "int", nullable: false),
                    Post_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashtagPostMap", x => new { x.Hashtag_Id, x.Post_Id });
                    table.ForeignKey(
                        name: "FK_HashtagPostMap_Hashtags_Hashtag_Id",
                        column: x => x.Hashtag_Id,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HashtagPostMap_Posts_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HashtagPostMap_Post_Id",
                table: "HashtagPostMap",
                column: "Post_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashtagPostMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hashtags",
                table: "Hashtags");

            migrationBuilder.RenameTable(
                name: "Hashtags",
                newName: "Hashtag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hashtag",
                table: "Hashtag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HashtagPost",
                columns: table => new
                {
                    HashtagsId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashtagPost", x => new { x.HashtagsId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_HashtagPost_Hashtag_HashtagsId",
                        column: x => x.HashtagsId,
                        principalTable: "Hashtag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HashtagPost_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HashtagPost_PostsId",
                table: "HashtagPost",
                column: "PostsId");
        }
    }
}
