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
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int ZoneId { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int SupervisorId { get; set; }
        [Required]
        public int MarketingHierarchyUserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}