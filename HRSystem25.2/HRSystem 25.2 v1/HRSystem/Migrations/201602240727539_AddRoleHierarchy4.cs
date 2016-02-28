namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleHierarchy4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleHierarchy",
                c => new
                    {
                        ChildRoleID = c.Int(nullable: false),
                        ParentRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChildRoleID, t.ParentRoleID });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoleHierarchy");
        }
    }
}
