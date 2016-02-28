namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeChnage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "BossUserID", "dbo.User");
            DropIndex("dbo.Employee", new[] { "BossUserID" });
            AddColumn("dbo.Employee", "BossEmployeeID", c => c.Int());
            CreateIndex("dbo.Employee", "BossEmployeeID");
            AddForeignKey("dbo.Employee", "BossEmployeeID", "dbo.Employee", "ID");
            DropColumn("dbo.Employee", "BossUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "BossUserID", c => c.Int());
            DropForeignKey("dbo.Employee", "BossEmployeeID", "dbo.Employee");
            DropIndex("dbo.Employee", new[] { "BossEmployeeID" });
            DropColumn("dbo.Employee", "BossEmployeeID");
            CreateIndex("dbo.Employee", "BossUserID");
            AddForeignKey("dbo.Employee", "BossUserID", "dbo.User", "ID");
        }
    }
}
