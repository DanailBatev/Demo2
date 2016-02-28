namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BossUserID = c.Int(),
                        RoleID = c.Int(nullable: false),
                        ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.BossUserID)
                .ForeignKey("dbo.Project", t => t.ProjectID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.BossUserID)
                .Index(t => t.RoleID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.ParentRoleID)
                .Index(t => t.ParentRoleID);
            
            CreateTable(
                "dbo.Salary",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salary", "UserId", "dbo.User");
            DropForeignKey("dbo.Employee", "UserID", "dbo.User");
            DropForeignKey("dbo.Role", "ParentRoleID", "dbo.Role");
            DropForeignKey("dbo.Employee", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Employee", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.Employee", "BossUserID", "dbo.User");
            DropForeignKey("dbo.User", "CityID", "dbo.City");
            DropIndex("dbo.Salary", new[] { "UserId" });
            DropIndex("dbo.Role", new[] { "ParentRoleID" });
            DropIndex("dbo.Employee", new[] { "ProjectID" });
            DropIndex("dbo.Employee", new[] { "RoleID" });
            DropIndex("dbo.Employee", new[] { "BossUserID" });
            DropIndex("dbo.Employee", new[] { "UserID" });
            DropIndex("dbo.User", new[] { "CityID" });
            DropTable("dbo.Salary");
            DropTable("dbo.Role");
            DropTable("dbo.Project");
            DropTable("dbo.Employee");
            DropTable("dbo.User");
            DropTable("dbo.City");
        }
    }
}
