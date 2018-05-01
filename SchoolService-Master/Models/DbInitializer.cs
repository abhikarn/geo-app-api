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
               new Users() { UserName = "abhi", UserPassword = "123", EmailId = "abhi.karn@gmail.com", FirstName = "Abhishek", LastName = "Karn", RoleId=1, CountryId=1, StateId=1, CityId=1, IsActive=true},
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
               new BranchMaster() {  BranchName="CENTRAL", ZoneId=1,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="EAST 1", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="EAST 2", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="EAST 3", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="EAST 4", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="EAST 5", ZoneId=2,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="LAGOS 1", ZoneId=3,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="LAGOS 2", ZoneId=3,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="NORTH 1", ZoneId=4,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="NORTH 2", ZoneId=4,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="S CENTRAL", ZoneId=5,  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="S WEST", ZoneId=6,  Created=DateTime.Now, Updated=DateTime.Now },
            };
            context.Branches.AddRange(branches);
            context.SaveChanges();

            List<ZoneMaster> zones = new List<ZoneMaster> {
               new ZoneMaster() { ZoneName="CENTRAL", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { ZoneName="EAST", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { ZoneName="LAGOS", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { ZoneName="NORTH", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { ZoneName="SOUTH CENTRAL", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { ZoneName="SOUTH WEST", CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { ZoneName="SOUTH ZONE", CountryId=1, Created=DateTime.Now, Updated=DateTime.Now }
            };
            context.Zones.AddRange(zones);
            context.SaveChanges();

            List<StateMaster> states = new List<StateMaster> {
               new StateMaster() { StateName = "ABUJA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "BIDA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "KEFFI", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "KONT", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "LAFIA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "MINNA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "MOKWA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "SULEJA", BranchId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "PHC", BranchId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ASABA", BranchId=3, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ONITSHA", BranchId=3, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "OWERRI", BranchId=3, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "AWKA", BranchId=3, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ABAKALIKI", BranchId=4, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ENUGU", BranchId=4, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "MAKURDI", BranchId=4, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "OTUKPO", BranchId=4, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ABA", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "CALABAR", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "UMUAHIA", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "UYO", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ORON", BranchId=5, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "WARRI", BranchId=6, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "YENEGOA", BranchId=6, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "LAGOS", BranchId=7, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "IKEJA", BranchId=8, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "BAUCHI", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "DAMA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "DUTSE", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "FUNTUA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "GOMBE", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "HADEJA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "JALINGO", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "JOS", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "KANO", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "KATSINA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "MAIDUGURI", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "YOLA", BranchId=9, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "GUSAU", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "KADUNA", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "KEBBI", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "SOKOTO", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ZARIA", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "FUNTUA", BranchId=10, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "BENIN", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "EDO UPCOUNTRY", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "KOGI UPCOUNTRY", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "LOKOJA", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "AUCHI", BranchId=11, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ABEOKUTA", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ADO EKITI", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "AKURE", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "EKITI", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "IBADAN", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "IJEBU", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "ILORIN", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "OGBOMOSO", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "OSHOGBO", BranchId=12, Created=DateTime.Now, Updated=DateTime.Now },
            };
            context.States.AddRange(states);
            context.SaveChanges();

            List<CountryMaster> countries = new List<CountryMaster> {
               new CountryMaster() { CountryrName = "INDIA", Created=DateTime.Now, Updated=DateTime.Now },
               new CountryMaster() { CountryrName = "NIGERIA", Created=DateTime.Now, Updated=DateTime.Now },
               new CountryMaster() { CountryrName = "USA", Created=DateTime.Now, Updated=DateTime.Now }
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