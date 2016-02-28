namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Salary", "UserId", "dbo.User");
            DropIndex("dbo.Salary", new[] { "UserId" });
            AddColumn("dbo.Employee", "SalaryAmount", c => c.Int(nullable: false));
            DropTable("dbo.Salary");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Salary",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Employee", "SalaryAmount");
            CreateIndex("dbo.Salary", "UserId");
            AddForeignKey("dbo.Salary", "UserId", "dbo.User", "ID", cascadeDelete: true);
        }
    }
}
