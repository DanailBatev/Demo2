namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoleHier1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleHierarchy", "ParentRoleID", "dbo.Role");
            DropIndex("dbo.RoleHierarchy", new[] { "ParentRoleID" });
            DropPrimaryKey("dbo.RoleHierarchy");
            AddColumn("dbo.RoleHierarchy", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.RoleHierarchy", "ParentRoleID", c => c.Int());
            AddPrimaryKey("dbo.RoleHierarchy", "ID");
            CreateIndex("dbo.RoleHierarchy", "ParentRoleID");
            AddForeignKey("dbo.RoleHierarchy", "ParentRoleID", "dbo.Role", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleHierarchy", "ParentRoleID", "dbo.Role");
            DropIndex("dbo.RoleHierarchy", new[] { "ParentRoleID" });
            DropPrimaryKey("dbo.RoleHierarchy");
            AlterColumn("dbo.RoleHierarchy", "ParentRoleID", c => c.Int(nullable: false));
            DropColumn("dbo.RoleHierarchy", "ID");
            AddPrimaryKey("dbo.RoleHierarchy", new[] { "ChildRoleID", "ParentRoleID" });
            CreateIndex("dbo.RoleHierarchy", "ParentRoleID");
            AddForeignKey("dbo.RoleHierarchy", "ParentRoleID", "dbo.Role", "ID", cascadeDelete: true);
        }
    }
}
