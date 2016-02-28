namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleHierarchy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Role", "ParentRoleID", "dbo.Role");
            DropIndex("dbo.Role", new[] { "ParentRoleID" });
            DropColumn("dbo.Role", "ParentRoleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "ParentRoleID", c => c.Int());
            CreateIndex("dbo.Role", "ParentRoleID");
            AddForeignKey("dbo.Role", "ParentRoleID", "dbo.Role", "ID");
        }
    }
}
