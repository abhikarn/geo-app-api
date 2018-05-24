using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<SchoolServiceContext>
    {
        protected override void Seed(SchoolServiceContext context)
        {

            List<Users> users = new List<Users> {
               new Users() { UserName = "abhi", UserPassword = "123", EmailId = "abhi.karn@gmail.com", FirstName = "Abhishek", LastName = "Karn", RoleId=1, CountryId=1, StateId=1, CityId=1, IsActive=true, DateOfBirth=DateTime.Now},
            };
            context.Users.AddRange(users);
            context.SaveChanges();


            //List<SchoolMaster> Schools = new List<SchoolMaster> {
            //   new SchoolMaster() { SchoolName = "DAV", HouseNumber = "12", Street = "test", Area = "Test", LGA = "Test", CityId=1, StateId=1, CountryId=1, Created=DateTime.Now, Updated=DateTime.Now },
            //   new SchoolMaster() { SchoolName = "DPS", HouseNumber = "187", Street = "test2", Area = "Test2", LGA = "Test2", CityId=2, StateId=2, CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
            //   new SchoolMaster() { SchoolName = "StJohns", HouseNumber = "123", Street = "test1", Area = "Test1", LGA = "Test1", CityId=3, StateId=3, CountryId=3, Created=DateTime.Now, Updated=DateTime.Now }
            //};
            //context.Schools.AddRange(Schools);
            //context.SaveChanges();

            //List<SupervisorMaster> supervisors = new List<SupervisorMaster> {
            //   new SupervisorMaster() { SupervisorName="Sper1",  Created=DateTime.Now, Updated=DateTime.Now },
            //   new SupervisorMaster() {  SupervisorName="Sper2",  Created=DateTime.Now, Updated=DateTime.Now },
            //   new SupervisorMaster() {  SupervisorName="Sper3",  Created=DateTime.Now, Updated=DateTime.Now  }
            //};
            //context.Supervisors.AddRange(supervisors);
            //context.SaveChanges();

            List<BranchMaster> branches = new List<BranchMaster> {
               new BranchMaster() {  Name="CENTRAL", ZoneId=1,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="EAST 1", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="EAST 2", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="EAST 3", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="EAST 4", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="EAST 5", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="LAGOS 1", ZoneId=3,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="LAGOS 2", ZoneId=3,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="NORTH 1", ZoneId=4,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="NORTH 2", ZoneId=4,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="S CENTRAL", ZoneId=5,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  Name="S WEST", ZoneId=6,  Created=DateTime.Now, Updated=DateTime.Now },
            };
            context.Branches.AddRange(branches);
            context.SaveChanges();

            List<ZoneMaster> zones = new List<ZoneMaster> {
               new ZoneMaster() { Name="CENTRAL", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { Name="EAST", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { Name="LAGOS", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { Name="NORTH", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { Name="SOUTH CENTRAL", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { Name="SOUTH WEST", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { Name="SOUTH ZONE", CountryId=1, Created=DateTime.Now, Updated=DateTime.Now }
            };
            context.Zones.AddRange(zones);
            context.SaveChanges();

            List<StateMaster> states = new List<StateMaster> {
               new StateMaster() { Name = "ABUJA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "BIDA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "KEFFI", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "KONT", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "LAFIA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "MINNA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "MOKWA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "SULEJA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "PHC", BranchId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ASABA", BranchId=3, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ONITSHA", BranchId=3, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "OWERRI", BranchId=3, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "AWKA", BranchId=3, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ABAKALIKI", BranchId=4, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ENUGU", BranchId=4, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "MAKURDI", BranchId=4, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "OTUKPO", BranchId=4, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ABA", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "CALABAR", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "UMUAHIA", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "UYO", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ORON", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "WARRI", BranchId=6, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "YENEGOA", BranchId=6, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "LAGOS", BranchId=7, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "IKEJA", BranchId=8, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "BAUCHI", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "DAMA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "DUTSE", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "FUNTUA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "GOMBE", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "HADEJA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "JALINGO", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "JOS", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "KANO", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "KATSINA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "MAIDUGURI", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "YOLA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "GUSAU", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "KADUNA", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "KEBBI", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "SOKOTO", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ZARIA", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "FUNTUA", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "BENIN", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "EDO UPCOUNTRY", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "KOGI UPCOUNTRY", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "LOKOJA", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "AUCHI", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ABEOKUTA", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ADO EKITI", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "AKURE", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "EKITI", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "IBADAN", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "IJEBU", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "ILORIN", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "OGBOMOSO", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { Name = "OSHOGBO", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
            };
            context.States.AddRange(states);
            context.SaveChanges();

            List<CountryMaster> countries = new List<CountryMaster> {
               new CountryMaster() { Name = "INDIA", Created=DateTime.Now, Updated=DateTime.Now },
               new CountryMaster() { Name = "NIGERIA", Created=DateTime.Now, Updated=DateTime.Now },
               new CountryMaster() { Name = "USA", Created=DateTime.Now, Updated=DateTime.Now }
            };
            context.Countries.AddRange(countries);
            context.SaveChanges();

            List<Role> roles = new List<Role> {
               new Role() { Name = "Admin", Description="Admin", IsActive=true },
               new Role() { Name = "Supervisor", Description="Supervisor", IsActive=true},
               new Role() { Name = "Marketing User", Description="Hierarchy user", IsActive=true },
               new Role() { Name = "Country Head", Description="Country Head user", IsActive=true },
               new Role() { Name = "Zone Head", Description="Zone user", IsActive=true },
               new Role() { Name = "Branch Head", Description="Branch user", IsActive=true }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();

            //List<CityMaster> city = new List<CityMaster> {
            //   new CityMaster() { CityName = "Madrid", Created=DateTime.Now, Updated=DateTime.Now },
            //   new CityMaster() { CityName = "Istambul", Created=DateTime.Now, Updated=DateTime.Now},
            //   new CityMaster() { CityName = "Edinburgh", Created=DateTime.Now, Updated=DateTime.Now }
            //};
            //context.City.AddRange(city);
            //context.SaveChanges();

            base.Seed(context);
        }
    }
}