using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolService_Master.ViewModels
{
    public class GeoHierarchyViewModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int SupervisorId { get; set; }
        public string SupervisorName { get; set; }
        public string MarketingHierarchyUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<SchoolGeoHierarchyMappingViewModel> SchoolGeoHierarchyMappingViewModels { get; set; }
    }
}