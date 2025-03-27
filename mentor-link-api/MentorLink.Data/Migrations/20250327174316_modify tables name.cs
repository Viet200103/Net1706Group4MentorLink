using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorLink.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifytablesname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_CategoryId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskBoards_CapstoneWorkspaces_CapstoneWorkspaceId",
                table: "TaskBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_TaskBoards_TaskBoardId",
                table: "TaskLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLists",
                table: "TaskLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskBoards",
                table: "TaskBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsCategories",
                table: "NewsCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CapstoneWorkspaces",
                table: "CapstoneWorkspaces");

            migrationBuilder.RenameTable(
                name: "TaskLists",
                newName: "TaskList");

            migrationBuilder.RenameTable(
                name: "TaskBoards",
                newName: "TaskBoard");

            migrationBuilder.RenameTable(
                name: "NewsCategories",
                newName: "NewsCategory");

            migrationBuilder.RenameTable(
                name: "CapstoneWorkspaces",
                newName: "CapstoneWorkspace");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLists_TaskBoardId",
                table: "TaskList",
                newName: "IX_TaskList_TaskBoardId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskBoards_CapstoneWorkspaceId",
                table: "TaskBoard",
                newName: "IX_TaskBoard_CapstoneWorkspaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList",
                column: "TaskListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskBoard",
                table: "TaskBoard",
                column: "TaskBoardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsCategory",
                table: "NewsCategory",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CapstoneWorkspace",
                table: "CapstoneWorkspace",
                column: "CapstoneWorkspaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategory_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "NewsCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskBoard_CapstoneWorkspace_CapstoneWorkspaceId",
                table: "TaskBoard",
                column: "CapstoneWorkspaceId",
                principalTable: "CapstoneWorkspace",
                principalColumn: "CapstoneWorkspaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_TaskBoard_TaskBoardId",
                table: "TaskList",
                column: "TaskBoardId",
                principalTable: "TaskBoard",
                principalColumn: "TaskBoardId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategory_CategoryId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskBoard_CapstoneWorkspace_CapstoneWorkspaceId",
                table: "TaskBoard");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_TaskBoard_TaskBoardId",
                table: "TaskList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskBoard",
                table: "TaskBoard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsCategory",
                table: "NewsCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CapstoneWorkspace",
                table: "CapstoneWorkspace");

            migrationBuilder.RenameTable(
                name: "TaskList",
                newName: "TaskLists");

            migrationBuilder.RenameTable(
                name: "TaskBoard",
                newName: "TaskBoards");

            migrationBuilder.RenameTable(
                name: "NewsCategory",
                newName: "NewsCategories");

            migrationBuilder.RenameTable(
                name: "CapstoneWorkspace",
                newName: "CapstoneWorkspaces");

            migrationBuilder.RenameIndex(
                name: "IX_TaskList_TaskBoardId",
                table: "TaskLists",
                newName: "IX_TaskLists_TaskBoardId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskBoard_CapstoneWorkspaceId",
                table: "TaskBoards",
                newName: "IX_TaskBoards_CapstoneWorkspaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLists",
                table: "TaskLists",
                column: "TaskListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskBoards",
                table: "TaskBoards",
                column: "TaskBoardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsCategories",
                table: "NewsCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CapstoneWorkspaces",
                table: "CapstoneWorkspaces",
                column: "CapstoneWorkspaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "NewsCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskBoards_CapstoneWorkspaces_CapstoneWorkspaceId",
                table: "TaskBoards",
                column: "CapstoneWorkspaceId",
                principalTable: "CapstoneWorkspaces",
                principalColumn: "CapstoneWorkspaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_TaskBoards_TaskBoardId",
                table: "TaskLists",
                column: "TaskBoardId",
                principalTable: "TaskBoards",
                principalColumn: "TaskBoardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
