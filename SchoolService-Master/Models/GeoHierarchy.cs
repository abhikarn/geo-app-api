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
        public int id { get; set; }
        public int countryId { get; set; }
        public int zoneId { get; set; }
        public int branchId { get; set; }
        public int stateId { get; set; }
        public int supervisorId { get; set; }
        public string marketingHierarchyUser { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }
}