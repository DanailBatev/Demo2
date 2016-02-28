namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleHierarchy7 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RoleHierarchy", "ChildRoleID");
            CreateIndex("dbo.RoleHierarchy", "ParentRoleID");
            AddForeignKey("dbo.RoleHierarchy", "ChildRoleID", "dbo.Role", "ID", cascadeDelete: false);
            AddForeignKey("dbo.RoleHierarchy", "ParentRoleID", "dbo.Role", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleHierarchy", "ParentRoleID", "dbo.Role");
            DropForeignKey("dbo.RoleHierarchy", "ChildRoleID", "dbo.Role");
            DropIndex("dbo.RoleHierarchy", new[] { "ParentRoleID" });
            DropIndex("dbo.RoleHierarchy", new[] { "ChildRoleID" });
        }
    }
}
