using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

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

        public static implicit operator GeoHierarchyViewModel(GeoHierarchy geohierarchy)
        {
            return new GeoHierarchyViewModel
            {
                Id = geohierarchy.Id,
                CountryId = geohierarchy.CountryId,
                StateId = geohierarchy.StateId,
                ZoneId = geohierarchy.ZoneId,
                BranchId = geohierarchy.BranchId,
                SupervisorId = geohierarchy.SupervisorId,
                MarketingHierarchyUser = geohierarchy.MarketingHierarchyUser,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
        }

        public static implicit operator GeoHierarchy(GeoHierarchyViewModel gvm)
        {
            return new GeoHierarchy
            {
                Id = gvm.Id,
                CountryId = gvm.CountryId,
                StateId = gvm.StateId,
                ZoneId = gvm.ZoneId,
                BranchId = gvm.BranchId,
                SupervisorId = gvm.SupervisorId,
                MarketingHierarchyUser = gvm.MarketingHierarchyUser,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
        }
    }
}