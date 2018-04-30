using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class GeoHierarchyViewModel
    {
        public int Id { get; set; }
        [Required]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        [Required]
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        [Required]
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        [Required]
        public int StateId { get; set; }
        public string StateName { get; set; }
        [Required]
        public int SupervisorId { get; set; }
        public string SupervisorName { get; set; }
        [Required]
        public int MarketingHierarchyUserId { get; set; }
        public string MarketingHierarchyUserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        [Required]
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
                MarketingHierarchyUserId = geohierarchy.MarketingHierarchyUserId,
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
                MarketingHierarchyUserId = gvm.MarketingHierarchyUserId,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
        }
    }
}