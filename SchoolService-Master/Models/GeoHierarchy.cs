using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    public class GeoHierarchy
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int ZoneId { get; set; }
        public int BranchId { get; set; }
        public int StateId { get; set; }
        public int SupervisorId { get; set; }
        public string MarketingHierarchyUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}