namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentRoleNUllable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Role", new[] { "ParentRoleID" });
            AlterColumn("dbo.Role", "ParentRoleID", c => c.Int());
            CreateIndex("dbo.Role", "ParentRoleID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Role", new[] { "ParentRoleID" });
            AlterColumn("dbo.Role", "ParentRoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Role", "ParentRoleID");
        }
    }
}
