using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class ZoneMasterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public static implicit operator ZoneMasterViewModel(ZoneMaster zoneMaster)
        {
            return new ZoneMasterViewModel
            {
                Id = zoneMaster.Id,
                Name = zoneMaster.ZoneName,
                CountryId = zoneMaster.CountryId
            };
        }

        public static implicit operator ZoneMaster(ZoneMasterViewModel zoneMasterViewModel)
        {
            return new ZoneMaster
            {
                Id = zoneMasterViewModel.Id,
                ZoneName = zoneMasterViewModel.Name,
                CountryId = zoneMasterViewModel.CountryId
            };
        }
    }
}