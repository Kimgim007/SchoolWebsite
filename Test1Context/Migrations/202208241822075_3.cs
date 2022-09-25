namespace Test1Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GameDTOes", newName: "GameDTO");
            RenameTable(name: "dbo.UserDTOes", newName: "UserDTO");
            RenameTable(name: "dbo.TeamDTOes", newName: "TeamDTO");
            RenameTable(name: "dbo.UserDTOGameDTOes", newName: "UserGame");
            RenameTable(name: "dbo.TeamDTOUserDTOes", newName: "TeamDTOUserDTO");
            RenameColumn(table: "dbo.UserGame", name: "UserDTO_Id", newName: "UserId");
            RenameColumn(table: "dbo.UserGame", name: "GameDTO_Id", newName: "GameId");
            RenameIndex(table: "dbo.UserGame", name: "IX_UserDTO_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserGame", name: "IX_GameDTO_Id", newName: "IX_GameId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserGame", name: "IX_GameId", newName: "IX_GameDTO_Id");
            RenameIndex(table: "dbo.UserGame", name: "IX_UserId", newName: "IX_UserDTO_Id");
            RenameColumn(table: "dbo.UserGame", name: "GameId", newName: "GameDTO_Id");
            RenameColumn(table: "dbo.UserGame", name: "UserId", newName: "UserDTO_Id");
            RenameTable(name: "dbo.TeamDTOUserDTO", newName: "TeamDTOUserDTOes");
            RenameTable(name: "dbo.UserGame", newName: "UserDTOGameDTOes");
            RenameTable(name: "dbo.TeamDTO", newName: "TeamDTOes");
            RenameTable(name: "dbo.UserDTO", newName: "UserDTOes");
            RenameTable(name: "dbo.GameDTO", newName: "GameDTOes");
        }
    }
}
