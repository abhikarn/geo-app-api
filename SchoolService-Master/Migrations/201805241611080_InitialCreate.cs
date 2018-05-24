namespace SchoolService_Master.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BranchMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        ZoneId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        StateId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CountryMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryrName = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeoHierarchies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        ZoneId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        SupervisorId = c.Int(nullable: false),
                        MarketingHierarchyUserId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        RoleType = c.Int(),
                        RoleStatusId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.SchoolGeoHierarchyMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeoHierarchyId = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(nullable: false),
                        HouseNumber = c.String(),
                        Street = c.String(),
                        Area = c.String(),
                        LGA = c.String(),
                        CityId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        ZoneId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        LandMark = c.String(),
                        GeoCoordinate = c.String(),
                        PrincipalName = c.String(),
                        PhoneNumber = c.String(),
                        SchoolPhoneNumber = c.String(),
                        SchoolType = c.String(nullable: false),
                        TotalPopulation = c.String(),
                        TotalEducationlevel = c.String(),
                        NursaryToPrimary3Population = c.String(),
                        PrincipalConcent = c.Boolean(nullable: false),
                        SingageAvailable = c.Boolean(nullable: false),
                        SignageStatus = c.String(),
                        IfBad = c.String(),
                        ClassRoomCorex = c.String(),
                        SchoolImage = c.Binary(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Source = c.String(),
                        Approved = c.Boolean(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StateMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        BranchId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupervisorMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupervisorName = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        EmailId = c.String(maxLength: 100),
                        UserPassword = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LastLoginDate = c.DateTime(),
                        DateOfBirth = c.DateTime(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Gender = c.Int(),
                        RoleId = c.Int(nullable: false),
                        Status = c.String(),
                        CountryId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        ZoneId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        NotFirstLogin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EmailId, unique: true);
            
            CreateTable(
                "dbo.ZoneMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZoneName = c.String(),
                        CountryId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "EmailId" });
            DropTable("dbo.ZoneMaster");
            DropTable("dbo.Users");
            DropTable("dbo.SupervisorMaster");
            DropTable("dbo.StateMaster");
            DropTable("dbo.SchoolMasters");
            DropTable("dbo.SchoolGeoHierarchyMappings");
            DropTable("dbo.Role");
            DropTable("dbo.GeoHierarchies");
            DropTable("dbo.CountryMaster");
            DropTable("dbo.CityMasters");
            DropTable("dbo.BranchMaster");
        }
    }
}
