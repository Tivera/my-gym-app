namespace MyGymApplication.Migrations.MyGym
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "PackageName", c => c.String(nullable: false));
            AddColumn("dbo.Member", "MembershipPackage_MemPackageID", c => c.Int());
            CreateIndex("dbo.Member", "MembershipPackage_MemPackageID");
            AddForeignKey("dbo.Member", "MembershipPackage_MemPackageID", "dbo.MembershipPackage", "MemPackageID");
            DropColumn("dbo.Member", "MembershipPackage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "MembershipPackage", c => c.String(nullable: false));
            DropForeignKey("dbo.Member", "MembershipPackage_MemPackageID", "dbo.MembershipPackage");
            DropIndex("dbo.Member", new[] { "MembershipPackage_MemPackageID" });
            DropColumn("dbo.Member", "MembershipPackage_MemPackageID");
            DropColumn("dbo.Member", "PackageName");
        }
    }
}
