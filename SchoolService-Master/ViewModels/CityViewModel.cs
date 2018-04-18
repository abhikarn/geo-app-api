using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public static implicit operator CityViewModel(CityMaster cityMaster)
        {
            return new CityViewModel
            {
                Id = cityMaster.Id,
                Name = cityMaster.CityName
            };
        }

        public static implicit operator CityMaster(CityViewModel cityViewModel)
        {
            return new CityMaster
            {
                Id = cityViewModel.Id,
                CityName = cityViewModel.Name
            };
        }
    }
}