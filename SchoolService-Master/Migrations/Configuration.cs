namespace SchoolService_Master.Migrations
{
    using SchoolService_Master.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolService_Master.Models.SchoolServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SchoolService_Master.Models.SchoolServiceContext";
        }

        protected override void Seed(SchoolService_Master.Models.SchoolServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(x => x.Id,
            new Users() { Id = 1, UserName = "abhi", UserPassword = "123", EmailId = "abhi.karn@gmail.com", FirstName = "Abhishek", LastName = "Karn", RoleId = 1, CountryId = 1, StateId = 1, CityId = 1, IsActive = true, DateOfBirth = DateTime.Now }
            );

            context.Branches.AddOrUpdate(x => x.Id,
               new BranchMaster() { Name = "CENTRAL", ZoneId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "EAST 1", ZoneId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "EAST 2", ZoneId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "EAST 3", ZoneId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "EAST 4", ZoneId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "EAST 5", ZoneId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "LAGOS 1", ZoneId = 3, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "LAGOS 2", ZoneId = 3, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "NORTH 1", ZoneId = 4, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "NORTH 2", ZoneId = 4, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "S CENTRAL", ZoneId = 5, Created = DateTime.Now, Updated = DateTime.Now },
               new BranchMaster() { Name = "S WEST", ZoneId = 6, Created = DateTime.Now, Updated = DateTime.Now }
           );

            context.Zones.AddOrUpdate(x => x.Id,
              new ZoneMaster() { Name = "CENTRAL", CountryId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new ZoneMaster() { Name = "EAST", CountryId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new ZoneMaster() { Name = "LAGOS", CountryId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new ZoneMaster() { Name = "NORTH", CountryId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new ZoneMaster() { Name = "SOUTH CENTRAL", CountryId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new ZoneMaster() { Name = "SOUTH WEST", CountryId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new ZoneMaster() { Name = "SOUTH ZONE", CountryId = 1, Created = DateTime.Now, Updated = DateTime.Now }
          );

            context.States.AddOrUpdate(x => x.Id,
              new StateMaster() { Name = "ABUJA", BranchId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "BIDA", BranchId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "KEFFI", BranchId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "KONT", BranchId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "LAFIA", BranchId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "MINNA", BranchId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "MOKWA", BranchId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "SULEJA", BranchId = 1, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "PHC", BranchId = 2, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ASABA", BranchId = 3, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ONITSHA", BranchId = 3, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "OWERRI", BranchId = 3, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "AWKA", BranchId = 3, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ABAKALIKI", BranchId = 4, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ENUGU", BranchId = 4, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "MAKURDI", BranchId = 4, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "OTUKPO", BranchId = 4, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ABA", BranchId = 5, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "CALABAR", BranchId = 5, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "UMUAHIA", BranchId = 5, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "UYO", BranchId = 5, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ORON", BranchId = 5, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "WARRI", BranchId = 6, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "YENEGOA", BranchId = 6, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "LAGOS", BranchId = 7, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "IKEJA", BranchId = 8, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "BAUCHI", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "DAMA", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "DUTSE", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "FUNTUA", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "GOMBE", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "HADEJA", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "JALINGO", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "JOS", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "KANO", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "KATSINA", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "MAIDUGURI", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "YOLA", BranchId = 9, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "GUSAU", BranchId = 10, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "KADUNA", BranchId = 10, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "KEBBI", BranchId = 10, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "SOKOTO", BranchId = 10, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ZARIA", BranchId = 10, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "FUNTUA", BranchId = 10, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "BENIN", BranchId = 11, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "EDO UPCOUNTRY", BranchId = 11, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "KOGI UPCOUNTRY", BranchId = 11, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "LOKOJA", BranchId = 11, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "AUCHI", BranchId = 11, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ABEOKUTA", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ADO EKITI", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "AKURE", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "EKITI", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "IBADAN", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "IJEBU", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "ILORIN", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "OGBOMOSO", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now },
               new StateMaster() { Name = "OSHOGBO", BranchId = 12, Created = DateTime.Now, Updated = DateTime.Now }
          );

            context.Countries.AddOrUpdate(x => x.Id,
               new CountryMaster() { Name = "INDIA", Created = DateTime.Now, Updated = DateTime.Now },
               new CountryMaster() { Name = "NIGERIA", Created = DateTime.Now, Updated = DateTime.Now },
               new CountryMaster() { Name = "USA", Created = DateTime.Now, Updated = DateTime.Now }
          );

            context.Roles.AddOrUpdate(x => x.Id,
               new Role() { Name = "Admin", Description = "Admin", RoleType = 1, IsActive = true },
               new Role() { Name = "Supervisor", Description = "Supervisor", RoleType = 5, IsActive = true },
               new Role() { Name = "Marketing User", Description = "Hierarchy user", RoleType = 6, IsActive = true },
               new Role() { Name = "Country Head", Description = "Country Head user", RoleType = 2, IsActive = true },
               new Role() { Name = "Zone Head", Description = "Zone user", RoleType = 3, IsActive = true },
               new Role() { Name = "Branch Head", Description = "Branch user", RoleType = 4, IsActive = true }
          );
        }
    }
}
