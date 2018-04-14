using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    public class SchoolServiceContext : DbContext
    {
        public SchoolServiceContext()
            : base("name=SchoolServiceConnection")
        {
            Database.SetInitializer(new DbInitializer());
        }
        public virtual DbSet<SchoolMaster> Schools { get; set; }
        public virtual DbSet<SupervisorMaster> Supervisors { get; set; }
        public virtual DbSet<BranchMaster> Branches { get; set; }
        public virtual DbSet<ZoneMaster> Zones { get; set; }
        public virtual DbSet<StateMaster> States { get; set; }
        public virtual DbSet<CountryMaster> Countries { get; set; }
        public virtual DbSet<GeoHierarchy> GeoHierarchies { get; set; }
        public virtual DbSet<SchoolGeoHierarchyMapping> SchoolGeoHierarchyMapping { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

    }
}