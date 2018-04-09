using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class SchoolGeoHierarchyMappingViewModel
    {
        public int SchoolGeoHierarchyMappingId { get; set; }
        public int GeoHierarchyId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public static implicit operator SchoolGeoHierarchyMappingViewModel(SchoolGeoHierarchyMapping schoolGeoHierarchyMapping)
        {
            return new SchoolGeoHierarchyMappingViewModel
            {
                Id = schoolGeoHierarchyMapping.SchoolId,
                GeoHierarchyId = schoolGeoHierarchyMapping.GeoHierarchyId
            };
        }

        public static implicit operator SchoolGeoHierarchyMapping(SchoolGeoHierarchyMappingViewModel shoolGeoHierarchyMappingViewModel)
        {
            return new SchoolGeoHierarchyMapping
            {
                SchoolId = shoolGeoHierarchyMappingViewModel.Id,
                GeoHierarchyId = shoolGeoHierarchyMappingViewModel.GeoHierarchyId
            };
        }
    }
}