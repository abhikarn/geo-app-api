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


            List<SchoolMaster> Schools = new List<SchoolMaster> {
               new SchoolMaster() { SchoolName = "DAV", HouseNumber = "12", Street = "test", Area = "Test", LGA = "Test", CityId=1, StateId=1, CountryId=1, Created=DateTime.Now, Updated=DateTime.Now },
               new SchoolMaster() { SchoolName = "DPS", HouseNumber = "187", Street = "test2", Area = "Test2", LGA = "Test2", CityId=2, StateId=2, CountryId=2, Created=DateTime.Now, Updated=DateTime.Now },
               new SchoolMaster() { SchoolName = "StJohns", HouseNumber = "123", Street = "test1", Area = "Test1", LGA = "Test1", CityId=3, StateId=3, CountryId=3, Created=DateTime.Now, Updated=DateTime.Now }
            };
            context.Schools.AddRange(Schools);
            context.SaveChanges();

            List<SupervisorMaster> supervisors = new List<SupervisorMaster> {
               new SupervisorMaster() { SupervisorName="Sper1",  Created=DateTime.Now, Updated=DateTime.Now },
               new SupervisorMaster() {  SupervisorName="Sper2",  Created=DateTime.Now, Updated=DateTime.Now },
               new SupervisorMaster() {  SupervisorName="Sper3",  Created=DateTime.Now, Updated=DateTime.Now  }
            };
            context.Supervisors.AddRange(supervisors);
            context.SaveChanges();

            List<BranchMaster> branches = new List<BranchMaster> {
               new BranchMaster() {  BranchName="Branch1",  Created=DateTime.Now, Updated=DateTime.Now },
               new BranchMaster() {  BranchName="Branch2",  Created=DateTime.Now, Updated=DateTime.Now  },
               new BranchMaster() {  BranchName="Branch3",  Created=DateTime.Now, Updated=DateTime.Now  }
            };
            context.Branches.AddRange(branches);
            context.SaveChanges();

            List<ZoneMaster> zones = new List<ZoneMaster> {
               new ZoneMaster() { ZoneName="Zone1", Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { ZoneName="Zone2", Created=DateTime.Now, Updated=DateTime.Now },
               new ZoneMaster() { ZoneName="Zone3", Created=DateTime.Now, Updated=DateTime.Now }
            };
            context.Zones.AddRange(zones);
            context.SaveChanges();

            List<StateMaster> states = new List<StateMaster> {
               new StateMaster() { StateName = "Jharkhand", Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "Solna", Created=DateTime.Now, Updated=DateTime.Now },
               new StateMaster() { StateName = "LA", Created=DateTime.Now, Updated=DateTime.Now }
            };
            context.States.AddRange(states);
            context.SaveChanges();

            List<CountryMaster> countries = new List<CountryMaster> {
               new CountryMaster() { CountryrName = "India", Created=DateTime.Now, Updated=DateTime.Now },
               new CountryMaster() { CountryrName = "Norway", Created=DateTime.Now, Updated=DateTime.Now },
               new CountryMaster() { CountryrName = "USA", Created=DateTime.Now, Updated=DateTime.Now }
            };
            context.Countries.AddRange(countries);
            context.SaveChanges();

            List<Role> roles = new List<Role> {
               new Role() { Name = "Admin", Description="Admin", IsActive=true },
               new Role() { Name = "Supervisor", Description="Supervisor", IsActive=true},
               new Role() { Name = "Marketing User", Description="Hierarchy user", IsActive=true }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();

            List<CityMaster> city = new List<CityMaster> {
               new CityMaster() { CityName = "Madrid", Created=DateTime.Now, Updated=DateTime.Now },
               new CityMaster() { CityName = "Istambul", Created=DateTime.Now, Updated=DateTime.Now},
               new CityMaster() { CityName = "Edinburgh", Created=DateTime.Now, Updated=DateTime.Now }
            };
            context.City.AddRange(city);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}