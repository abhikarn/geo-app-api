using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    public class SchoolGeoHierarchyMapping
    {
        [Key]
        public int Id { get; set; }
        public int GeoHierarchyId { get; set; }
        public int SchoolId { get; set; }
    }
}